using Microsoft.AspNetCore.Mvc;
using Shopping.Loggin.Business;
using Shopping.Shared;

namespace Shopping.Loggin.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : BaseController
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
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await logService.GetAll());
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateAsync(LogDTO log)
        {
            try
            {
                var result = await logService.Create(log);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }

        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> FilterAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await logService.Filter(startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }
    }
}
