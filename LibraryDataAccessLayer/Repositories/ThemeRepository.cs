using Library.DAL.Entities;
using Library.DAL.Context;

namespace Library.DAL.Repositories
{
    class ThemeRepository : AbstractRepository<Theme>
    {
        public ThemeRepository(LibraryContext context) : base(context)
        {
        }
    }
}
