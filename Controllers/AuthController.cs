using DevBoard.DTOs.Auth;
using DevBoard.Services;
using DevBoard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);

            if (!result.Success)
            {
                return Conflict(new { 
                    code = result.ErrorCode
                });
            }

            return Ok( new { 
                message = "Usuario registrado exitosamente"
            });
        }
    }
}