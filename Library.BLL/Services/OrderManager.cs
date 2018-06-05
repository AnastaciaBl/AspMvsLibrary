using Library.BLL.Interfaces;
using System.Collections.Generic;
using Library.BLL.DTO;
using Library.DAL.Interfaces;
using AutoMapper;
using Library.DAL.Entities;
using System;
using System.Linq;

namespace Library.BLL.Services
{
    public class OrderManager : IOrderManager
    {
        IUnitOfWork Database { get; set; }

        public OrderManager(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(OrderDTO order, List<BookDTO> books)
        {
            for (int i = 0; i < books.Count; i++)
            {
                var orderCreate = new Order()
                {
                    Book_Id = books[i].Id,
                    Client_Id = order.Client_Id,
                    OrderDate = order.OrderDate,
                    ReturnDate = order.OrderDate.AddDays(14),
                    IsCompleted = false
                };
                Database.Orders.Create(orderCreate);
                Book bookUpdate = Database.Books.Get(books[i].Id);
                bookUpdate.IsReturned = false;
                Database.Books.Update(bookUpdate);
            }
        }

        public OrderDTO GetOrder(int bookId, int clientId, DateTime orderDate)
        {
            Order orderResult = getOrderByKeyField(bookId, clientId, orderDate);
            var orderDtoReturn = new OrderDTO()
            {
                Book_Id = orderResult.Book_Id,
                Client_Id = orderResult.Client_Id,
                OrderDate = orderResult.OrderDate,
                ReturnDate = orderResult.ReturnDate,
                IsCompleted = orderResult.IsCompleted,
                ActualPenalty = countPenalty(orderResult.OrderDate, orderResult.ReturnDate, orderResult.Book_Id, orderResult.IsCompleted)
            };
            return orderDtoReturn;
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(Database.Orders.GetAll()).ToList();
            for (int i = 0; i < orders.Count; i++)
                orders[i].ActualPenalty = countPenalty(orders[i].OrderDate, orders[i].ReturnDate, orders[i].Book_Id, orders[i].IsCompleted);
            return orders;
        }

        public void Update(OrderDTO order)
        {
            var updateOrder = getOrderByKeyField(order.Book_Id, order.Client_Id, order.OrderDate);
            updateOrder.IsCompleted = order.IsCompleted;
            Database.Orders.Update(updateOrder);
            if (order.IsCompleted == true)
            {
                var updateBook = Database.Books.Get(order.Book_Id);
                updateBook.IsReturned = true;
                Database.Books.Update(updateBook);
            }
            else
            {
                var updateBook = Database.Books.Get(order.Book_Id);
                updateBook.IsReturned = false;
                Database.Books.Update(updateBook);
            }
        }

        private double countPenalty(DateTime orderDate, DateTime returnDate, int bookId, bool isOrderCompleted)
        {
            double penalty = 0;
            if (!isOrderCompleted)
            {
                DateTime now = DateTime.Now;
                if (now > returnDate)
                {
                    Book book = Database.Books.Get(bookId);
                    double over = book.Price * 0.3;
                    penalty = now.Subtract(returnDate).TotalDays * over;
                }
            }
            return penalty;
        }

        private Order getOrderByKeyField(int bookId, int clientId, DateTime orderDate)
        {
            IEnumerable<Order> order = Database.Orders.GetAll();
            var orderdBookIdClientId = order.Where(o => o.Client_Id == clientId && o.Book_Id == bookId && o.OrderDate.Date == orderDate.Date).FirstOrDefault();
            return orderdBookIdClientId;
        }
    }
}
