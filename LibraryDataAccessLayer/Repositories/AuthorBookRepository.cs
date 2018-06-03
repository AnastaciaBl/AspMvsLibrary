using Library.DAL.Entities;
using Library.DAL.Context;

namespace Library.DAL.Repositories
{
    class AuthorBookRepository : AbstractRepository<AuthorBook>
    {
        public AuthorBookRepository(LibraryContext context) : base(context)
        {

        }
    }
}
