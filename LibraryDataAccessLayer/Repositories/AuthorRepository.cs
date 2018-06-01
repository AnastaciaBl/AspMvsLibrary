using Library.DAL.Entities;
using Library.DAL.Context;

namespace Library.DAL.Repositories
{
    class AuthorRepository : AbstractRepository<Author>
    {
        public AuthorRepository(LibraryContext context) : base(context)
        {
        }
    }
}
