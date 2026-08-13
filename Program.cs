using DevBoard.Auth;
using DevBoard.Data;
using DevBoard.Services;
using DevBoard.Services.Interfaces;
using DevBoard.DTOs.Auth;
using DevBoard.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Configurar el contexto de la base de datos con MySQL
builder.Services.AddDbContext<DevBoardContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    ));

// Add services to the container.
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var ms = context.ModelState;
            var errorKeys = ms.Where(kvp => kvp.Value.Errors.Count > 0)
                              .Select(kvp => kvp.Key ?? string.Empty)
                              .ToList();

            bool HasErrorFor(string name) =>
                errorKeys.Any(k => k.Equals(name, StringComparison.OrdinalIgnoreCase) ||
                                   k.EndsWith("." + name, StringComparison.OrdinalIgnoreCase) ||
                                   k.Contains("[" + name + "]", StringComparison.OrdinalIgnoreCase));

            if (HasErrorFor(nameof(RegisterRequest.Email)))
                return new ConflictObjectResult(new { code = ErrorCode.InvalidEmail });

            if (HasErrorFor(nameof(RegisterRequest.Username)))
                return new ConflictObjectResult(new { code = ErrorCode.InvalidUsername });

            if (HasErrorFor(nameof(RegisterRequest.Password)))
                return new ConflictObjectResult(new { code = ErrorCode.InvalidPassword });

            // Fallback: devolver ModelState por defecto (400) si no coincide con las reglas anteriores
            return new BadRequestObjectResult(context.ModelState);
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
