using Microsoft.Azure.Cosmos;
using System.Linq.Expressions;

namespace Shopping.Shared
{
    public interface ICosmosRepository<T> where T : class
    {
        Task<List<T>> GetAsync();

        Task<T> GetAsync(string id, PartitionKey key);

        Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression);

        Task CreateAsync(T entity, PartitionKey key);

        Task UpdateAsync(T entity, string id, PartitionKey key);

        Task RemoveAsync(string id, PartitionKey key);
    }
}
