using Shopping.Shared;

namespace Shopping.Product.Data
{
    public interface IProductRepo: INoSQLRepository<Entity.ProductEntity>
    {
    }
}
