using System;
using Library.DAL.Entities;

namespace Library.DAL.Interfaces
{
    interface IUnitOfWork:IDisposable
    {
        IRepository<Author> Authors { get; }
        IRepository<AuthorBook> Author_Book { get; }
        IRepository<Book> Books { get; }
        IRepository<Client> Clients { get; }
        IRepository<Order> Orders { get; }
        IRepository<Theme> Themes { get; }
        void Save();
    }
}
