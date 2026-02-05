using System.ComponentModel.DataAnnotations;

namespace ApiConciertos.Models
{
    public class Eventos
    {
        
        public int id_evento { get; set; }

        [Required(ErrorMessage ="Debe ingresar el nombre del concierto")]
        [MinLength(2,ErrorMessage ="La cantidad mínima es 1")]

        public string nombre_evento { get; set; }


        public string fecha_evento { get; set; }
        public string artista { get; set; }
    }
}
