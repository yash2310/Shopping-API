using Shopping.Entity;
using Shopping.Shared;
using System.Linq.Expressions;

namespace Shopping.Loggin.Business
{
    public interface ILogService
    {
        Task<bool> Create(LogDTO log);
        Task<List<SearchLogDTO>> GetAll();
        Task<List<SearchLogDTO>> Filter(DateTime startDate, DateTime endDate);
    }
}
