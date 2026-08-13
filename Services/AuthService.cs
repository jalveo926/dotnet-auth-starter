using DevBoard.Data;
using DevBoard.Data.Entities;
using DevBoard.DTOs.Auth;
using DevBoard.Services.Interfaces;
using DevBoard.Common.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DevBoard.Services
{
    public class AuthService : IAuthService
    {

        private readonly DevBoardContext _context;
        private readonly IPasswordService _passwordService;

        public AuthService(DevBoardContext context,IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        //request siendo la info que viene del front end, el request tiene username, email y password
        public async Task<bool> RegisterAsync(RegisterRequest request)
        {   //Revisar si el usuario ya existe en la base de datos por email o username
            var existingUser = await _context.Users
                .AnyAsync(u =>
                    u.Email == request.Email ||
                    u.Username == request.Username);

            if (existingUser && ValidationUtils.IsValidPassword(request.Password) && ValidationUtils.IsValidEmail(request.Email))
            {
                return false;
            }

            //Se crea el usuario a guardar en la base de datos 
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = _passwordService.HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return true;
        }

        public string CreatePasswordHash(string password)
        {
            return _passwordService.HashPassword(password);
        }
    }
}
