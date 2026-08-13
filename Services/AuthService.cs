using DevBoard.Data;
using DevBoard.Data.Entities;
using DevBoard.DTOs.Auth;
using DevBoard.Services.Interfaces;
using DevBoard.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using DevBoard.Common.Errors;
using DevBoard.Services.Results;

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
        public async Task<AuthResult> RegisterAsync(RegisterRequest request)
        {   //Revisar si el usuario ya existe en la base de datos por email o username
            var existingUser = await _context.Users
                .AnyAsync(u =>
                    u.Email == request.Email ||
                    u.Username == request.Username);

            if (existingUser)
            {
                return new AuthResult { 
                    Success = false, 
                    ErrorCode = ErrorCode.EmailAlreadyExists,
                    ErrorMessage = ErrorCode.UsernameAlreadyExists
                };
            }

            if (!ValidationUtils.IsValidEmail(request.Email))
            {
                return new AuthResult
                {
                    Success = false,
                    ErrorCode = ErrorCode.InvalidEmail
                };
            }

            if (!ValidationUtils.IsValidUsername(request.Username))
            {
                return new AuthResult
                {
                    Success = false,
                    ErrorCode = ErrorCode.InvalidUsername
                };
            }

            if (!ValidationUtils.IsValidPassword(request.Password))
            {
                return new AuthResult
                {
                    Success = false,
                    ErrorCode = ErrorCode.InvalidPassword
                };
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

            return new AuthResult { 
                Success = true
            };
        }

        public string CreatePasswordHash(string password)
        {
            return _passwordService.HashPassword(password);
        }
    }
}
