using Shopping.Shared;
using Shopping.Entity;
using Microsoft.Extensions.Options;

namespace Shopping.Loggin.Data
{
    public class LogRepo : NoSQLRepository<LogEntity>, ILogRepo
    {
        public LogRepo(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings) { }
    }
}
