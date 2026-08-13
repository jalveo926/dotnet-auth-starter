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

            if (!result)
            {
                return Conflict("Usuario o Email ya existe.");
            }

            return Ok("Usuario registrado exitosamente.");
        }
    }
}