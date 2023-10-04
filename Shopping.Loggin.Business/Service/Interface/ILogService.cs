using Shopping.Shared.DTO;
using System.Linq.Expressions;

namespace Shopping.Loggin.Business
{
    public interface ILogService
    {
        Task<bool> Create(LogDTO log);

        Task<List<LogDTO>> GetAll();
    }
}
