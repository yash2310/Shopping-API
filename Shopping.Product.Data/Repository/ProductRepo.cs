using Microsoft.Extensions.Options;
using Shopping.Entity;
using Shopping.Shared;

namespace Shopping.Product.Data.Repository
{
    public class ProductRepo : CosmosRepository<ProductEntity>, IProductRepo
    {
        public ProductRepo(IOptions<CosmosDatabaseSettings> databaseSettings) : base(databaseSettings) { }
    }
}
