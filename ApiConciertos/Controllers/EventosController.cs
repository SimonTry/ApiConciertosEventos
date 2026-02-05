using ApiConciertos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiConciertos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : Controller
    {
        private static List<Eventos> _eventos = new List<Eventos>
        {
            new Eventos { id_evento = 1, nombre_evento = "Concierto Rock", fecha_evento = "2023-09-15", artista = "Rock Band" },
            new Eventos { id_evento = 2, nombre_evento = "Festival Pop", fecha_evento = "2023-10-20", artista = "Pop Star" },
            new Eventos { id_evento = 3, nombre_evento = "Noche de Jazz", fecha_evento = "2023-11-05", artista = "Jazz Ensemble" }
        };
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_eventos);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var evento = _eventos.FirstOrDefault(e => e.id_evento == id);
            if(evento == null)
            {
                return NotFound("No existe el evento");
            }
            return Ok(evento);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Eventos newEvent)
        {
            
                newEvent.id_evento = _eventos.Max(e => e.id_evento) + 1;
                _eventos.Add(newEvent);
                return CreatedAtAction(nameof(getById),
                    new { id = newEvent.id_evento }, newEvent);
            
               
        }

    }
}
