using Library.DAL.Entities;
using Library.DAL.Context;

namespace Library.DAL.Repositories
{
    class BookRepository : AbstractRepository<Book>
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }
    }
}
