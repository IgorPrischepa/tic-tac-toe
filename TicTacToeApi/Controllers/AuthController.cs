using Microsoft.AspNetCore.Mvc;
using TicTacToeApi.Bll.Models;
using TicTacToeApi.Bll.Services.Contracts;
using TicTacToeApi.Dto.User;

namespace TicTacToeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IJwtAuthService _jwtService;

        public AuthController(IJwtAuthService jwtAuthService, ILogger<AuthController> logger)
        {
            _logger = logger;
            _jwtService = jwtAuthService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDto user)
        {
            try
            {
                string token = await _jwtService.LoginAsync(new LoginUserModel()
                {
                    Email = user.Email,
                    Password = user.Password
                });

                _logger.LogInformation("The token has been successfully generated.");
                return Ok(token);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("{Message}\n{StackTrace}", ex.Message, ex.StackTrace);
                return Unauthorized();
            }
        }
    }
}