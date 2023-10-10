using Shopping.Shared;

namespace Shopping.Loggin.Business
{
    public interface ILogService
    {
        Task<bool> Create(LogDTO log, bool flag, string corId);
        Task<List<SearchLogDTO>> GetAll();
        Task<List<SearchLogDTO>> Filter(DateTime startDate, DateTime endDate);
    }
}
