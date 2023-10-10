using AutoMapper;
//using Microsoft.Azure.Cosmos;
using Shopping.Entity;
using Shopping.Product.Data;
using Shopping.Shared;
using Shopping.Shared.Service;
using System.Linq.Expressions;

namespace Shopping.Product.Business
{
    public class ProductService : BaseService, IProductService
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
            var entity = mapper.Map<ProductEntity>(product);
            entity.Id = Guid.NewGuid();
            await productRepo.CreateAsync(entity);

            return true;
        }

        public async Task<bool> Update(ProductDTO product)
        {
            var data = await productRepo.GetAsync(p => p.Id == product.Id);

            if (data != null)
            {
                var entity = mapper.Map<ProductEntity>(product);
                await productRepo.UpdateAsync(p => p.Id == product.Id, entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Delete(string id)
        {
            var data = await productRepo.GetAsync(p => p.Id.ToString() == id);

            if (data != null)
            {
                await productRepo.RemoveAsync(p => p.Id.ToString() == id);
                return true;
            }
            else
                return false;

        }

        public async Task<ProductDTO> Get(string id)
        {
            var product = await productRepo.GetAsync(p => p.Id.ToString() == id);

            return mapper.Map<ProductDTO>(product);
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            var products = await productRepo.GetAsync();

            return mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<List<ProductDTO>> Where(Expression<Func<ProductDTO, bool>> expression)
        {
            var param = Expression.Parameter(typeof(ProductEntity));

            var body = new Visitor<ProductEntity>(param).Visit(expression.Body);

            // Convert expresion from one to another type
            Expression<Func<ProductEntity, bool>> expr = Expression.Lambda<Func<ProductEntity, bool>>(body, param);

            var products = await productRepo.WhereAsync(expr);
            return mapper.Map<List<ProductDTO>>(products);
        }
    }
}
