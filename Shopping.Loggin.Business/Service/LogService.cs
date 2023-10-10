using AutoMapper;
using Shopping.Entity;
using Shopping.Loggin.Data;
using Shopping.Shared;
using Shopping.Shared.Service;

namespace Shopping.Loggin.Business
{
    public class LogService : BaseService, ILogService
    {
        private readonly ILogRepo logRepo;
        private readonly IMapper mapper;

        public LogService(ILogRepo logRepo, IMapper mapper)
        {
            this.logRepo = logRepo;
            this.mapper = mapper;
        }

        public async Task<bool> Create(LogDTO log, bool flag, string corId)
        {
            var entity = mapper.Map<LogEntity>(log);

            entity.Id = Guid.NewGuid();
            entity.CorrelationId = flag ? corId : Guid.NewGuid().ToString();
            entity.CreatedBy = log.Username;

            await logRepo.CreateAsync(entity, PartitionKey(entity.Id));
            return true;
        }

        public async Task<List<SearchLogDTO>> GetAll()
        {
            var products = await logRepo.GetAsync();

            return mapper.Map<List<SearchLogDTO>>(products);
        }

        public async Task<List<SearchLogDTO>> Filter(DateTime startDate, DateTime endDate)
        {
            var logs = await logRepo.WhereAsync(l => l.CreatedOn >= startDate && l.CreatedOn <= endDate);
            return mapper.Map<List<SearchLogDTO>>(logs);
        }
    }
}
