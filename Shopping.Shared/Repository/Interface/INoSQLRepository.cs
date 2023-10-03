using System.Linq.Expressions;

namespace Shopping.Shared
{
    public interface INoSQLRepository<T> where T : class
    {
        Task<List<T>> GetAsync();

        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression);

        Task CreateAsync(T entity);

        Task UpdateAsync(Expression<Func<T, bool>> expression, T entity);

        Task RemoveAsync(Expression<Func<T, bool>> expression);
    }
}
