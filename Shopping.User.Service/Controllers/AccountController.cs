using Microsoft.AspNetCore.Mvc;
using Shopping.Shared;
using Shopping.User.Business;

namespace Shopping.User.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> logger;
        private readonly IUserService userService;

        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public TokenDTO Login(LoginDTO login)
        {
            var user = userService.ValidateUser(login);

            if (user != null)
            {
                return new TokenDTO { User = user, Token = userService.GenerateToken(user) };
            }

            return new TokenDTO();
        }

        [HttpPost]
        [Route("register")]
        public bool Register(RegisterDTO register)
        {
            return userService.AddUser(register);
        }
    }
}
