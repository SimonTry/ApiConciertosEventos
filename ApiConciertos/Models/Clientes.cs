using System.ComponentModel.DataAnnotations;

namespace ApiConciertos.Models
{
    public class Clientes
    {
        [Key]
        public Guid Cliente_Id { get; set; } = Guid.NewGuid();

        public string nombre_cliente { get; set; }
        public int isActive { get; set; } = 1;

        [Required]
        public string IdentityUserId { get; set; } = string.Empty;

    }
}
