using System.ComponentModel.DataAnnotations;

namespace ApiConciertos.Models.DTOs
{
    public class LoginDTO
    {
        // Este DTO es para adicionar un modelo como cuerpo del endpoint del login
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
