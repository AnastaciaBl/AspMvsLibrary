using System;
using System.Collections.Generic;
using System.Linq;
using Library.BLL.DTO;
using Library.BLL.Interfaces;
using Library.BLL.Infrastructure;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using AutoMapper;
using System.Data.SqlClient;

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
        public void Create(BookDTO _book, List<int> authorsIds)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
            Book book = new Book
            {
                Title = _book.Title,
                Theme_Id = _book.Theme_Id,
                Price = _book.Price,
                IsReturned = true,
                PenaltyType = _book.PenaltyType,
                //Authors = mapper.Map<IEnumerable<AuthorDTO>, List<Author>>(_book.Authors)
            };
            Database.Books.Create(book);
            var lastBook = Database.Books.GetAll().ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            List<AuthorBook> authorBooks = new List<AuthorBook>();
            for (int i = 0; i < authorsIds.Count; i++)
            {
                var authorBookCreate = new AuthorBook()
                {
                    Book_Id = lastBook.Id,
                    Author_Id = authorsIds[i]
                };
                Database.Author_Book.Create(authorBookCreate);
            }
        }

        public void Delete(int id)
        {
            Database.Books.Delete(id);
        }

        public BookDTO GetBook(int id)
        {
            var book = Database.Books.Get(id);
            var bookDTO = new BookDTO()
            {
                Id = book.Id,
                Title = book.Title,
                Theme_Id = book.Theme_Id,
                Price = book.Price,
                IsReturned = book.IsReturned,
                PenaltyType = book.PenaltyType,
            };
            return bookDTO;
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(Database.Books.GetAll());
        }

        public void Update(BookDTO book)
        {
            var updateBook = Database.Books.Get(book.Id);
            updateBook.Title = book.Title;
            //updateBook.Theme_Id = book.Theme_Id;
            updateBook.Price = book.Price;
            updateBook.PenaltyType = book.PenaltyType;
            //updateBook.IsReturned = book.IsReturned;
            Database.Books.Update(updateBook);
        }

        public string GetTheme(int themeID)
        {
            return Database.Themes.Get(themeID).Topic;
        }

        public List<ThemeDTO> GetAllTheme()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Theme, ThemeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Theme>, IEnumerable<ThemeDTO>>(Database.Themes.GetAll()).ToList();
        }

        public IEnumerable<AuthorDTO> GetAuthors(int bookID)
        {
            IEnumerable<AuthorBook> authorsIds = Database.Author_Book.SqlQuery("SELECT * FROM dbo.AuthorBooks WHERE Book_Id = @Book_Id", new SqlParameter("@Book_Id", bookID));
            var authors = new List<Author>();
            foreach(var id in authorsIds)
            {
                int authorId = id.Author_Id;
                authors.Add(Database.Authors.Get(authorId));            
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(authors);
        }
    }
}
