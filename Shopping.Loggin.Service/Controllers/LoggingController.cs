using Microsoft.AspNetCore.Mvc;
using Shopping.Loggin.Business;
using Shopping.Shared.DTO;

namespace Shopping.Loggin.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILogService logService;
        private readonly ILogger<LoggingController> logger;

        public LoggingController(ILogService logService, ILogger<LoggingController> logger)
        {
            this.logService = logService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<LogDTO>> GetAllAsync()
        {
            return await logService.GetAll();
        }

        [HttpPost]
        [Route("add")]
        public async Task<bool> CreateAsync(LogDTO log)
        {
            try
            {
                var result = await logService.Create(log);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
