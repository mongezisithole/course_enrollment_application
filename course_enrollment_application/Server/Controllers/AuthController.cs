using course_enrollment_application.Repositories;
using course_enrollment_application.Shared.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace course_enrollment_application.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(UserLoginDto userLogin)
        {
            return _userService.Login(userLogin);
        }
    }
}
