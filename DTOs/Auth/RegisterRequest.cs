using System.ComponentModel.DataAnnotations;

namespace DevBoard.DTOs.Auth
{
    public class RegisterRequest
    {
        //Lo que el usuario manda cuando va a registrarse (Crear un usuario)
        [Required(ErrorMessage = "Se requiere nombre de usuario.")]
        [StringLength(
        50,
        MinimumLength = 3,
        ErrorMessage = "El nombre de usuario debe de tener al menos 3 caracteres."
        )]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Se requiere email.")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
        [StringLength(
            255,
            ErrorMessage = "El email no puede exceder 255 caracteres ."
        )]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Se requiere contraseña.")]
        [StringLength(
            100,
            MinimumLength = 8,
            ErrorMessage = "La contraseña debe tener como mínimo 8 caracteres."
        )]
        public string Password { get; set; } = string.Empty;
    }
}
