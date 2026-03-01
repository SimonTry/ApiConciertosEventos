using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiConciertos.Models
{
    public class Eventos
    {

        //SE agrega el dataAnnotation de Key para que EF (Entity Framework) conozca cuál es la llave primaria
        [Key]
        //Se agrega DataAnnotation para que el ID se genere automáticamente con la propiedad NewID()
        // para columnas UNIQUEIDENTIFIER
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id_evento { get; set; }


        // Los DataAnnotation nos ayudan a agregar reglas y validaciones que serían muy tediosas de replicar
        // con condiciones u otras clases de estructuras
        [Required(ErrorMessage = "Debe ingresar el nombre del concierto")]
        [MinLength(2, ErrorMessage = "La cantidad mínima es 1")]

        public string nombre_evento { get; set; }


        public string fecha_evento { get; set; }
        public string artista { get; set; }
        public int isActive {get;set;}
    }
}
