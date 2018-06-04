using System;
using System.Collections.Generic;
using System.Linq;
using Library.DAL.Interfaces;
using Library.DAL.Context;
using System.Data.Entity;
using System.Data.SqlClient;

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
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _db.SaveChanges();
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

        public IEnumerable<T> SqlQuery(string v, SqlParameter sqlParameter)
        {
            return _dbSet.SqlQuery(v, sqlParameter);
        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
