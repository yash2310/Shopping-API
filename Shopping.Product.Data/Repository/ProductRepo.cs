using Microsoft.Extensions.Options;
using Shopping.Entity;
using Shopping.Shared;

namespace Shopping.Product.Data.Repository
{
    public class ProductRepo : MongoRepository<ProductEntity>, IProductRepo
    {
        public ProductRepo(IOptions<MongoDatabaseSettings> databaseSettings) : base(databaseSettings) { }
    }
}
