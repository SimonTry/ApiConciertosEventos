using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiConciertos.Models
{
    public class Clientes
    {
        [Key]
        public Guid Cliente_Id { get; set; } = Guid.NewGuid();

        public string nombre_cliente { get; set; }
        public int isActive { get; set; } = 1;


        // Se crea una "llave foránea" para relacionar el id de Identity User
        // con el registro del cliente, esto para poder hacer la validación
        // de que realmente el token del usuario que está loguueado pueda ver la información de
        // ese cliente en específico

        [Required]
        public string IdentityUserId { get; set; } = string.Empty;

        [ForeignKey("IdentityUserId")]
        public IdentityUser? IdentityUser { get; set; }

    }
}
