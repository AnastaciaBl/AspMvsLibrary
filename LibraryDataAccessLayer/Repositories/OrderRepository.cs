using Library.DAL.Entities;
using Library.DAL.Context;

namespace Library.DAL.Repositories
{
    class OrderRepository : AbstractRepository<Order>
    {
        public OrderRepository(LibraryContext context) : base(context)
        {
        }
    }
}
