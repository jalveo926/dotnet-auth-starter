using DevBoard.DTOs.Auth;
namespace DevBoard.Services.Interfaces
{
    public interface IAuthService
    {
        // Esta tarea representa un método asíncrono que registra a un nuevo usuario en el sistema.
        // Toma un objeto RegisterRequest como parámetro, que contiene la información necesaria para el registro (como nombre de usuario, correo electrónico y contraseña).
        // Devuelve un valor booleano que indica si el registro fue exitoso o no.
        Task<bool> RegisterAsync(RegisterRequest request);
    }
}
