using AutoMapper;
using Shopping.Entity;
using Shopping.Shared;

namespace Shopping.Loggin.Business
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<LogDTO, LogEntity>().ReverseMap();
            CreateMap<SearchLogDTO, LogEntity>().ReverseMap();
        }
    }
}
