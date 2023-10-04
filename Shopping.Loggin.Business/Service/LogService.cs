using AutoMapper;
using Shopping.Entity;
using Shopping.Loggin.Data;
using Shopping.Shared;
using Shopping.Shared.DTO;
using System.Linq.Expressions;

namespace Shopping.Loggin.Business
{
    public class LogService: ILogService
    {
        private readonly ILogRepo logRepo;
        private readonly IMapper mapper;

        public LogService(ILogRepo logRepo, IMapper mapper)
        {
            this.logRepo = logRepo;
            this.mapper = mapper;
        }

        public async Task<bool> Create(LogDTO log)
        {
            var entity = mapper.Map<LogEntity>(log);
            await logRepo.CreateAsync(entity);
            return true;
        }

        public async Task<List<LogDTO>> GetAll()
        {
            var products = await logRepo.GetAsync();

            return mapper.Map<List<LogDTO>>(products);
        }
    }
}
