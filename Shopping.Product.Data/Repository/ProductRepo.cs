using Microsoft.Extensions.Options;
using Shopping.Entity;
using Shopping.Shared;

namespace Shopping.Product.Data.Repository
{
    public class ProductRepo : NoSQLRepository<ProductEntity>, IProductRepo
    {
        public ProductRepo(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings) { }
    }
}
