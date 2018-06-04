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
    public class ClientController : Controller
    {
        IClientManager clientService;

        public ClientController(IClientManager serv)
        {
            clientService = serv;
        }

        // GET: Client
        public ActionResult Index()
        {
            IEnumerable<ClientDTO> clientDtos = clientService.GetClients();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientViewModel>()).CreateMapper();
            var books = mapper.Map<IEnumerable<ClientDTO>, List<ClientViewModel>>(clientDtos);
            var authorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
            return View(books);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientViewModel client)
        {
            try
            {
                var clientCreate = new ClientDTO()
                {
                    FullName = client.FullName,
                    Phone = client.Phone,
                    Passport = client.Passport,
                    RegistrationDate = DateTime.Now
                };
                clientService.Create(clientCreate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var client = clientService.GetClient(id);
            var viewModel = new ClientViewModel()
            {
                Id = client.Id,
                FullName = client.FullName,
                Phone = client.Phone,
            };
            return View(viewModel);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ClientViewModel client)
        {
            var clientOld = clientService.GetClient(id);
            try
            {
                var clientUpdate = new ClientDTO()
                {
                    Id = id,
                    FullName = client.FullName,
                    Phone = client.Phone,
                    Passport = clientOld.Passport,
                    RegistrationDate = clientOld.RegistrationDate
                };
                clientService.Update(clientUpdate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            clientService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
