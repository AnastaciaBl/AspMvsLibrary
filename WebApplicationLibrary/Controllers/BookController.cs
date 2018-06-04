using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.BLL.Interfaces;
using Library.BLL.DTO;
using WebApplicationLibrary.Models;
using AutoMapper;
using Library.BLL.Infrastructure;

namespace WebApplicationLibrary.Controllers
{
    public class BookController : Controller
    {
        IBookManager bookService;
        IAuthorManager authorService;

        public BookController(IBookManager serv, IAuthorManager authorServ)
        {
            bookService = serv;
            authorService = authorServ;
        }

        // GET: Book
        public ActionResult Index()
        {
            IEnumerable<BookDTO> bookDtos = bookService.GetBooks();
            var listBooksDto = bookDtos.ToList();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            var books = mapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(bookDtos);
            var authorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
            for (int i = 0; i < books.Count; i++)
            {
                books[i].Theme = bookService.GetTheme(listBooksDto[i].Theme_Id);
                IEnumerable<AuthorDTO> authorsDtos = bookService.GetAuthors(books[i].Id).ToList();
                books[i].Authors = authorMapper.Map<IEnumerable<AuthorDTO>, List<AuthorViewModel>>(authorsDtos);
            }
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var listAuthorsDto = authorService.GetAuthors();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
            var book = new BookViewModel()
            {
                Authors = mapper.Map<IEnumerable<AuthorDTO>, List<AuthorViewModel>>(listAuthorsDto)
            };
            return View(book);
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookViewModel book)
        {
            try
            {
                List<AuthorDTO> authors = new List<AuthorDTO>();
                for (int i = 0; i < book.SelectedAuthorId.Count; i++)
                    authors.Add(authorService.GetAuthor(book.SelectedAuthorId[i]));
                var bookCreate = new BookDTO()
                {
                    Title = book.Title,
                    Theme_Id = 1,
                    Price = book.Price,
                    PenaltyType = Library.DAL.Entities.Penalty.Medium,
                    //Authors = authors
                };
                bookService.Create(bookCreate, book.SelectedAuthorId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            //var model = new BookViewModel();
            var book = bookService.GetBook(id);
            var authorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
            var viewModel = new BookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                ThemeId = book.Theme_Id,
                Theme = bookService.GetTheme(book.Theme_Id),
                Price = book.Price,
                IsReturned = book.IsReturned,
                Authors = authorMapper.Map<IEnumerable<AuthorDTO>, List<AuthorViewModel>>(bookService.GetAuthors(id))
            };
            ViewData["AllAuthors"] = from author in viewModel.Authors
                                          select new SelectListItem { Text = author.ToString(), Value = author.Id.ToString() };
            return View(viewModel);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var book = bookService.GetBook(id);
            try
            {
                // TODO: Add update logic here
                var bookUpdate = new BookDTO()
                {
                    Id = Convert.ToInt32(collection["Id"].ToString()),
                    Title = collection["Title"].ToString(),
                    Theme_Id = book.Theme_Id,
                    Price = Convert.ToDouble(collection["Price"].ToString()),
                    IsReturned = Convert.ToBoolean(collection["IsReturned"].ToString()),
                    PenaltyType = book.PenaltyType
                };
                bookService.Update(bookUpdate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
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
