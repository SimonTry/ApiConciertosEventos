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

        public double valor_unitario { get; set; }

        public string fecha_compra { get; set; }
        public string numero_boleta { get; set; }
        public int isActive { get; set; }
    }
}
