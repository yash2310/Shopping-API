using AutoMapper;
using Shopping.Shared;

namespace Shopping.Product.Business.AutoMapperProfile
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Entity.ProductEntity>().ReverseMap();
        }
    }
}
