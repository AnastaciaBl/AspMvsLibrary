﻿using System;
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

        public BookController(IBookManager serv)
        {
            bookService = serv;
        }

        // GET: Book
        public ActionResult Index()
        {
            IEnumerable<BookDTO> bookDtos = bookService.GetBooks();
            var listBooksDto = bookDtos.ToList();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            var books = mapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(bookDtos);
            var authorMapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
            for(int i=0;i<books.Count;i++)
            {
                books[i].Authors = authorMapper.Map<IEnumerable<AuthorDTO>, List<AuthorViewModel>>(listBooksDto[i].Authors);
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
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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