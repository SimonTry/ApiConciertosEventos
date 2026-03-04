using System.ComponentModel.DataAnnotations;

namespace ApiConciertos.Models.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = null!;

        [Required]
        public string Role { get; set; } = "User"; // Por defecto asignamos User
    }
}
