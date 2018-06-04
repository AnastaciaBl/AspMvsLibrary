using Library.DAL.Entities;
using Library.DAL.Context;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library.DAL.Repositories
{
    class AuthorBookRepository : AbstractRepository<AuthorBook>
    {
        public AuthorBookRepository(LibraryContext context) : base(context)
        {

        }

        //public IEnumerable<AuthorBook> GetAuthorsIds(int bookId)
        //{
        //    var authorsIds = _db.Author_Book.SqlQuery("SELECT Author_Id FROM AuthorBooks WHERE Book_Id=@bookId", new SqlParameter("@bookId", bookId));
        //    return authorsIds;
        //}
    }
}
