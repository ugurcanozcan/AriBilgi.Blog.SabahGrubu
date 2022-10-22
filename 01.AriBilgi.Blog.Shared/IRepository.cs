using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.AriBilgi.Blog.Shared
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Func<T, bool> predicate);
        IQueryable<T> GetAll();
        List<T> GetAll(Func<T, bool> predicate);
        bool Any(Func<T, bool> predicate);
        int Count(Func<T, bool> predicate);
       
    }
}
