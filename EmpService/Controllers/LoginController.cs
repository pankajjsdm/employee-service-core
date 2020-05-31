
using EmpService.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmpService.Controllers
{
    [Authorize]
    [ApiController]
   //[Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginServices;

        public LoginController(ILoginService userService)
        {
            _loginServices = userService;
        }

        [AllowAnonymous]
        [Route("api/login")]
        public IActionResult Authenticate([FromBody] LoginRequest model)
        {
            var user = _loginServices.Authenticate(model.Username , model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        [Route("api/GetUsers")]
        public IActionResult GetAll()
        {
            var users = _loginServices.GetAll();
            return Ok(users);
        }
    }
}
