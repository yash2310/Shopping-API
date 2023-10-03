using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Shopping.Shared
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Any(expression);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
