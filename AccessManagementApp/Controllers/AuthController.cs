using AccessManagementApp.Models;
using AccessManagementApp.Repository.Models;
using AccessManagementApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccessManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterModel registerModel)
        {
            var user = await _authService.RegisterAsync(registerModel);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthUser>> Login(LoginModel loginModel)
        {
            var authUser = await _authService.Login(loginModel);
            return Ok(authUser);

        }
    }
}
