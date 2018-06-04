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
    public class AuthorController : Controller
    {
        IAuthorManager authorService;

        public AuthorController(IAuthorManager serv)
        {
            authorService = serv;
        }

        // GET: Author
        public ActionResult Index()
        {
            IEnumerable<AuthorDTO> authorDtos = authorService.GetAuthors();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
            var authors = mapper.Map<IEnumerable<AuthorDTO>, List<AuthorViewModel>>(authorDtos);
            var authorMapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            for (int i = 0; i < authors.Count; i++)
            {
                IEnumerable<BookDTO> booksDtos = authorService.GetBooks(authors[i].Id).ToList();
                authors[i].Books = authorMapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(booksDtos);
            }
            return View(authors);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var authorCreate = new AuthorDTO()
                {
                    Name = collection["Name"],
                    Surname = collection["Surname"]
                };
                authorService.Create(authorCreate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            //var model = new BookViewModel();
            var author = authorService.GetAuthor(id);
            var bookMapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            var viewModel = new AuthorViewModel()
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,
                Books = bookMapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(authorService.GetBooks(id))
            };
            ViewData["AllBooks"] = from book in viewModel.Books
                                     select new SelectListItem { Text = book.Title, Value = book.Id.ToString() };
            return View(viewModel);
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var author = authorService.GetAuthor(id);
            try
            {
                // TODO: Add update logic here
                var authorUpdate = new AuthorDTO()
                {
                    Id = Convert.ToInt32(collection["Id"].ToString()),
                    Name = collection["Name"].ToString(),
                    Surname = collection["Surname"].ToString(),
                };
                authorService.Update(authorUpdate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            authorService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
