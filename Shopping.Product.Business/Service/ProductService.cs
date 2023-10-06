using AutoMapper;
using Microsoft.Azure.Cosmos;
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
            var data = await productRepo.GetAsync(product.Id.ToString(), new PartitionKey(product.Id.ToString()));

            if (data == null)
            {
                var entity = mapper.Map<ProductEntity>(product);
                await productRepo.CreateAsync(entity, new PartitionKey(entity.Id.ToString()));
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(ProductDTO product)
        {
            var data = await productRepo.GetAsync(product.Id.ToString(), new PartitionKey(product.Id.ToString()));

            if (data != null)
            {
                var entity = mapper.Map<ProductEntity>(product);
                await productRepo.UpdateAsync(entity, entity.Id.ToString(), new PartitionKey(product.Id.ToString()));
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Delete(string id)
        {
            var data = await productRepo.GetAsync(id.ToString(), new PartitionKey(id.ToString()));

            if (data != null)
            {
                await productRepo.RemoveAsync(id, new PartitionKey(id.ToString()));
                return true;
            }
            else
                return false;

        }

        public async Task<ProductDTO> Get(string id)
        {
            var product = await productRepo.GetAsync(id, new PartitionKey(id.ToString()));

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
