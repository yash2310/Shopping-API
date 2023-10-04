using AutoMapper;
using Shopping.Entity;
using Shopping.Shared;

namespace Shopping.Product.Business
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, ProductEntity>().ReverseMap();
        }
    }
}
