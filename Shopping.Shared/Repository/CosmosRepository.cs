using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace Shopping.Shared
{
    public class CosmosRepository<T> : ICosmosRepository<T> where T : class
    {
        private List<T> values = new List<T>();
        private readonly Container container;

        public CosmosRepository(IOptions<CosmosDatabaseSettings> databaseSettings)
        {
            var client = new CosmosClient(databaseSettings.Value.DBUri, databaseSettings.Value.ConnectionString);
            container = client.GetContainer(databaseSettings.Value.DatabaseName, databaseSettings.Value.ContainerName);
        }

        public async Task<List<T>> GetAsync()
        {
            string query = "Select * from C";
            QueryDefinition queryDefinition = new QueryDefinition(query);
            var queryResult = container.GetItemQueryIterator<T>(queryDefinition);

            while (queryResult.HasMoreResults)
            {
                var result = await queryResult.ReadNextAsync();
                foreach (var item in result)
                {
                    values.Add(item);
                }
            }

            return values;
        }

        public async Task<T> GetAsync(string id, PartitionKey key)
        {
            var response = await container.ReadItemAsync<T>(id, key);

            return response.Resource;
        }

        public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
            var data = container.GetItemLinqQueryable<T>().Where(expression).ToFeedIterator<T>();
            while (data.HasMoreResults)
            {
                foreach (var item in await data.ReadNextAsync())
                {
                    values.Add(item);
                }
            }
            return values;
        }

        public async Task CreateAsync(T entity, PartitionKey key)
        {
            await container.CreateItemAsync(entity, key);
        }

        public async Task RemoveAsync(string id, PartitionKey key)
        {
            await container.DeleteItemAsync<T>(id, key);
        }

        public async Task UpdateAsync(T entity, string id, PartitionKey key)
        {
            await container.ReplaceItemAsync(entity, id, key);
        }
    }
}
