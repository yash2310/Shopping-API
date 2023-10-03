using Shopping.Shared;
using System.Linq.Expressions;

namespace Shopping.Product.Business
{
    public interface IProductService
    {
        Task<ProductDTO> Get(int id);
        Task<List<ProductDTO>> GetAll();
        Task<List<ProductDTO>> Where(Expression<Func<ProductDTO, bool>> expression);
        Task<bool> Create(ProductDTO product);
        Task<bool> Update(ProductDTO product);
        Task<bool> Delete(int productId);
    }
}
