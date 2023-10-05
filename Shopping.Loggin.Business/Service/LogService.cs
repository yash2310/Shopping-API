using AutoMapper;
using Microsoft.Azure.Cosmos;
using Shopping.Entity;
using Shopping.Loggin.Data;
using Shopping.Shared.DTO;

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
            await logRepo.CreateAsync(entity, new PartitionKey(entity.CorrelationId));
            return true;
        }

        public async Task<List<LogDTO>> GetAll()
        {
            var products = await logRepo.GetAsync();

            return mapper.Map<List<LogDTO>>(products);
        }
    }
}
