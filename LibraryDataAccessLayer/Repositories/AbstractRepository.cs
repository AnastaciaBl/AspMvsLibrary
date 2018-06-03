using System;
using System.Collections.Generic;
using System.Linq;
using Library.DAL.Interfaces;
using Library.DAL.Context;
using System.Data.Entity;

namespace Library.DAL.Repositories
{
    class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected LibraryContext _db;
        protected DbSet<T> _dbSet;

        public AbstractRepository(LibraryContext context)
        {
            _db = context;
            _dbSet = context.Set<T>();
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
        }

        public void Delete(int id)
        {
            T entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
