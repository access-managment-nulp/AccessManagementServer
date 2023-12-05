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
            try
            {
                if (!registerModel.IsValid())
                {
                    return BadRequest();
                }
                var user = await _authService.RegisterAsync(registerModel);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthUser>> Login(LoginModel loginModel)
        {
            try
            {
                var authUser = await _authService.Login(loginModel);
                return Ok(authUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
