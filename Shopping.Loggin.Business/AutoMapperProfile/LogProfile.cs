using AutoMapper;
using Shopping.Entity;
using Shopping.Shared.DTO;

namespace Shopping.Loggin.Business
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<LogDTO, LogEntity>().ReverseMap();
        }
    }
}
