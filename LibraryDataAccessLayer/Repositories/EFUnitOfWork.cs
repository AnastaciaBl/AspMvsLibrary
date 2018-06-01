using System;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Library.DAL.Context;

namespace Library.DAL.Repositories
{
    class EFUnitOfWork : IUnitOfWork
    {
        private LibraryContext db;
        private AuthorBookRepository authorBookRepository;
        private AuthorRepository authorRepository;
        private BookRepository bookRepository;
        private ClientRepository clientRepository;
        private OrderRepository orderRepository;
        private ThemeRepository themeRepository;

        public IRepository<Author> Authors => authorRepository ?? (authorRepository = new AuthorRepository(db));

        public IRepository<AuthorBook> Author_Book => authorBookRepository ?? (authorBookRepository = new AuthorBookRepository(db));

        public IRepository<Book> Books => bookRepository ?? (bookRepository = new BookRepository(db));

        public IRepository<Client> Clients => clientRepository ?? (clientRepository = new ClientRepository(db));

        public IRepository<Order> Orders => orderRepository ?? (orderRepository = new OrderRepository(db));

        public IRepository<Theme> Themes => themeRepository ?? (themeRepository = new ThemeRepository(db));

        public EFUnitOfWork(string connectionString)
        {
            db = new LibraryContext(connectionString);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool isDisposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
