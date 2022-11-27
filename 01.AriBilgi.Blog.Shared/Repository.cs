using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.AriBilgi.Blog.Shared
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _dbContext;


        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public bool Any(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Any(predicate);
        }

        public int Count(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Count(predicate);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public T Get(Func<T, bool> predicate)
        {
            
            return _dbContext.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public List<T> GetAll(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();


        }

        

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
