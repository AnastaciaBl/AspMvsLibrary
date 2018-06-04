using Library.BLL.Interfaces;
using System.Collections.Generic;
using Library.BLL.DTO;
using Library.DAL.Interfaces;
using AutoMapper;
using Library.DAL.Entities;
using System.Data.SqlClient;

namespace Library.BLL.Services
{
    public class AuthorManager : IAuthorManager
    {
        IUnitOfWork Database { get; set; }

        public AuthorManager(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(AuthorDTO author)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
            var authorCreate = new Author
            {
                Name = author.Name,
                Surname = author.Surname,
            };
            Database.Authors.Create(authorCreate);
        }

        public void Delete(int id)
        {
            Database.Authors.Delete(id);
        }

        public AuthorDTO GetAuthor(int id)
        {
            var author = Database.Authors.Get(id);
            var authorDTO = new AuthorDTO()
            {
                Name = author.Name,
                Surname = author.Surname,
            };
            return authorDTO;
        }

        public IEnumerable<AuthorDTO> GetAuthors()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(Database.Authors.GetAll());
        }

        public IEnumerable<BookDTO> GetBooks(int authorID)
        {
            IEnumerable<AuthorBook> booksIds = Database.Author_Book.SqlQuery("SELECT * FROM dbo.AuthorBooks WHERE Author_Id = @Author_Id", new SqlParameter("@Author_Id", authorID));
            var books = new List<Book>();
            foreach (var id in booksIds)
            {
                int bookIds = id.Book_Id;
                books.Add(Database.Books.Get(bookIds));
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(books);
        }

        public void Update(AuthorDTO author)
        {
            var updateAuthor = Database.Authors.Get(author.Id);
            updateAuthor.Name = author.Name;
            updateAuthor.Surname = author.Surname;
            Database.Authors.Update(updateAuthor);
        }
    }
}
