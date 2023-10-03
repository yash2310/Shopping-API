using AutoMapper;
using SharpCompress.Common;
using Shopping.Entity;
using Shopping.Product.Data;
using Shopping.Shared;
using System.Linq.Expressions;

namespace Shopping.Product.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo productRepo;
        private readonly IMapper mapper;

        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }

        public async Task<bool> Create(ProductDTO product)
        {
            Expression<Func<Entity.ProductEntity, bool>> expr = p => p.ProductId == product.ProductId;

            var data = await productRepo.GetAsync(expr);

            if (data == null)
            {
                var entity = mapper.Map<Entity.ProductEntity>(product);
                await productRepo.CreateAsync(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(ProductDTO product)
        {
            Expression<Func<Entity.ProductEntity, bool>> expr = p => p.ProductId == product.ProductId;

            var data = await productRepo.GetAsync(expr);

            if (data != null)
            {
                var entity = mapper.Map<Entity.ProductEntity>(product);
                await productRepo.UpdateAsync(expr, entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Delete(int productId)
        {
            Expression<Func<Entity.ProductEntity, bool>> expr = p => p.ProductId == productId;

            var data = await productRepo.GetAsync(expr);

            if (data != null)
            {
                await productRepo.RemoveAsync(expr);
                return true;
            }
            else
                return false;

        }

        public async Task<ProductDTO> Get(int id)
        {
            Expression<Func<Entity.ProductEntity, bool>> expr = p => p.ProductId == id;

            var product = await productRepo.GetAsync(expr);

            return mapper.Map<ProductDTO>(product);
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            var products = await productRepo.GetAsync();

            return mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<List<ProductDTO>> Where(Expression<Func<ProductDTO, bool>> expression)
        {
            var param = Expression.Parameter(typeof(Entity.ProductEntity));

            var body = new Visitor<Entity.ProductEntity>(param).Visit(expression.Body);

            // Convert expresion from one to another type
            Expression<Func<Entity.ProductEntity, bool>> expr = Expression.Lambda<Func<Entity.ProductEntity, bool>>(body, param);
            
            var products = await productRepo.WhereAsync(expr);
            return mapper.Map<List<ProductDTO>>(products);
        }
    }
}
