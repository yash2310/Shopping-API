using Shopping.Shared;
using Shopping.Entity;
using Microsoft.Extensions.Options;

namespace Shopping.Loggin.Data
{
    public class LogRepo : CosmosRepository<LogEntity>, ILogRepo
    {
        public LogRepo(IOptions<CosmosDatabaseSettings> databaseSettings) : base(databaseSettings) { }
    }
}
