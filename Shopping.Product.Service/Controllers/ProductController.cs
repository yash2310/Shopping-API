using Microsoft.AspNetCore.Mvc;
using Shopping.Product.Business;
using Shopping.Shared;
using System.Linq.Expressions;

namespace Shopping.Product.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ProductDTO> GetProduct(string id)
        {
            return await productService.Get(id);
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<ProductDTO>> GetAllProduct()
        {
            return await productService.GetAll();
        }

        [HttpPost]
        [Route("add")]
        public async Task<bool> Create(ProductDTO product)
        {
            try
            {
                var result = await productService.Create(product);


                HttpClientUtility.Post("https://localhost:7023/api/logging/add", new LogDTO
                {
                    CorrelationId ="",
                    LogType = Shared.Enum.LogType.Information,
                    Message = "Test Message",
                    ServicePath = $"{Request.Scheme}://{Request.Host}",
                    Username = "yash.prajapati"
                });

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<bool> Update(ProductDTO product)
        {
            try
            {
                var result = await productService.Update(product);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("delete")]
        public async Task<bool> Delete(string id)
        {
            try
            {
                var result = await productService.Delete(id);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("instock")]
        public async Task<List<ProductDTO>> ActiveProduct()
        {
            Expression<Func<ProductDTO, bool>> expr = p => p.InStock == true;
            return await productService.Where(expr);
        }
    }
}
