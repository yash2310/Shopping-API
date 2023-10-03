using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Shopping.Shared
{
    public class NoSQLRepository<T> : INoSQLRepository<T> where T : class
    {
        private readonly IMongoCollection<T> collection;

        public NoSQLRepository(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);

            collection = mongoDatabase.GetCollection<T>(databaseSettings.Value.CollectionName);
        }

        public async Task<List<T>> GetAsync()
        {
            var data = await collection.Find(_ => true).ToListAsync();
            return data;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            var data = await collection.Find(expression).FirstOrDefaultAsync();
            return data;
        }

        public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
            var data = await collection.Find(expression).ToListAsync();
            return data;
        }

        public async Task CreateAsync(T entity)
        {
            await collection.InsertOneAsync(entity);
        }

        public async Task RemoveAsync(Expression<Func<T, bool>> expression)
        {
            await collection.DeleteOneAsync(expression);
        }

        public async Task UpdateAsync(Expression<Func<T, bool>> expression, T entity)
        {
            await collection.ReplaceOneAsync(expression, entity);
        }
    }
}
