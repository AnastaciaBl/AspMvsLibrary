using Library.DAL.Entities;
using Library.DAL.Context;

namespace Library.DAL.Repositories
{
    class ClientRepository : AbstractRepository<Client>
    {
        public ClientRepository(LibraryContext context) : base(context)
        {
        }
    }
}
