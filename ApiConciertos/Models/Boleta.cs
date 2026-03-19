using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiConciertos.Models
{
    public class Boleta
    {
        //SE agrega el dataAnnotation de Key para que EF (Entity Framework) conozca cuál es la llave primaria
        [Key]
        //Se agrega DataAnnotation para que el ID se genere automáticamente con la propiedad NewID()
        // para columnas UNIQUEIDENTIFIER
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id_boleta { get; set; }

        // Relación con Eventos
        [Required]
        public Guid EventoId { get; set; }

        [ForeignKey("EventoId")]
        public Eventos? Evento { get; set; }

        // Relación con Clientes (IdentityUser)
        [Required]
        public Guid ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Clientes? Cliente { get; set; }

        public double valor_unitario { get; set; }

        public string fecha_compra { get; set; }
        // Para poner la fecha por defecto y no enviarla en el body reemplace la línea de arriba por esta de abajo
        //public DateTime FechaCompra { get; set; } = DateTime.UtcNow;

        [Required]
        public string NroAsiento { get; set; } = string.Empty;

        public string numero_boleta { get; set; }
        public string ticketStatus { get; set; } = "Reserved";
        public int isActive { get; set; }
    }
}
