using System;
using System.Collections.Generic;
using Library.BLL.DTO;
using Library.BLL.Interfaces;
using Library.BLL.Infrastructure;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using AutoMapper;

namespace Library.BLL.Services
{
    public class BookManager : IBookManager
    {
        IUnitOfWork Database { get; set; }

        public BookManager(IUnitOfWork uow)
        {
            Database = uow;
        }

        //добавить запись в таблицу AuthorBook
        public void Create(BookDTO _book)
        {
            Theme theme = Database.Themes.Get(_book.Theme_Id);

            if (theme == null) throw new ValidationException("Theme wasn`t found.", "");
            if (_book.Authors.Count == 0) throw new ValidationException("Authors weren`t found.", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
            Book book = new Book
            {
                Title = _book.Title,
                Theme_Id = theme.Id,
                Price = _book.Price,
                IsReturned = true,
                PenaltyType = _book.PenaltyType,
                Authors = mapper.Map<IEnumerable<AuthorDTO>, List<Author>>(_book.Authors)
            };
        }

        public void Delete(int id)
        {
            Database.Books.Delete(id);
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(Database.Books.GetAll());
        }

        public IEnumerable<BookDTO> GetBookAuthors(int bookID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDTO> GetBooksByStatus(bool isReturned)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDTO> GetBooksByTheme(string theme)
        {
            throw new NotImplementedException();
        }

        public void Update(BookDTO book)
        {
            Database.Books.Update(new Book { Title = book.Title, Theme_Id = book.Theme_Id, Price = book.Price,
                PenaltyType = book.PenaltyType, IsReturned = book.IsReturned });
        }
    }
}
