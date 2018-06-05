using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLibrary.Models;

namespace WebApplicationLibrary.Controllers
{
    public class OrderController : Controller
    {
        IOrderManager orderService;
        IBookManager bookService;
        IClientManager clientService;

        public OrderController(IOrderManager serv, IBookManager servBook, IClientManager servClient)
        {
            orderService = serv;
            bookService = servBook;
            clientService = servClient;
        }

        // GET: Order
        public ActionResult Index()
        {
            IEnumerable<OrderDTO> orderDtos = orderService.GetOrders();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderViewModel>>(orderDtos);
            for(int i=0;i< orders.Count;i++)
            {
                orders[i].BookTitle = bookService.GetBook(orders[i].Book_Id).Title;
                orders[i].ClientFullName = clientService.GetClient(orders[i].Client_Id).FullName;
            }
            return View(orders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var listBooksDto = bookService.GetBooks().Where(b => b.IsReturned == true);
            var mapperBook = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            var clientsDto = clientService.GetClients();
            var mapperClient = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientViewModel>()).CreateMapper();
            var order = new OrderViewModel()
                {
                    Books = mapperBook.Map<IEnumerable<BookDTO>, List<BookViewModel>>(listBooksDto),
                    Clients = mapperClient.Map<IEnumerable<ClientDTO>, List<ClientViewModel>>(clientsDto)
                };
            if(order.Books.Count == 0 || order.Clients.Count == 0)
                return RedirectToAction("Index");
            else
                return View(order);
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(OrderViewModel order)
        {
            try
            {
                if (order.SelectedBookId.Count == 0 || order.SelectedClientId == 0)
                    throw new Exception();
                var books = new List<BookDTO>();
                for (int i = 0; i < order.SelectedBookId.Count; i++)
                    books.Add(bookService.GetBook(order.SelectedBookId[i]));
                var orderCreate = new OrderDTO()
                {
                    Client_Id = order.SelectedClientId,
                    OrderDate = DateTime.Now.Date,
                };
                orderService.Create(orderCreate, books);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int bookId, int clientId, DateTime time)
        {
            var order = orderService.GetOrder(bookId, clientId, time);
            var viewModel = new OrderViewModel()
            {
                Book_Id = order.Book_Id,
                Client_Id = order.Client_Id,
                OrderDate = order.OrderDate,
                IsCompleted = order.IsCompleted,
            };
            return View(viewModel);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderViewModel order)
        {
            var orderOld = orderService.GetOrder(order.Book_Id, order.Client_Id, order.OrderDate);
            try
            {
                var orderUpdate = new OrderDTO()
                {
                    Book_Id = order.Book_Id,
                    Client_Id = order.Client_Id,
                    OrderDate = order.OrderDate,
                    IsCompleted = order.IsCompleted,
                };
                orderService.Update(orderUpdate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
