using Microsoft.Extensions.Options;
using Shopping.Shared;

namespace Shopping.Product.Data.Repository
{
    public class ProductRepo : NoSQLRepository<Entity.ProductEntity>, IProductRepo
    {
        public ProductRepo(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings) { }
    }
}
