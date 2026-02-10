using ApiConciertos.Interfaces;
using ApiConciertos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiConciertos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : Controller
    {
        private readonly IEventosService _eventService;

        public EventosController(IEventosService eventosService)
        {
            _eventService = eventosService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_eventService.GetAll());

        //[HttpGet("{id}")]
        //public IActionResult getById(int id)
        //{
        //    var evento = _eventos.FirstOrDefault(e => e.id_evento == id);
        //    if(evento == null)
        //    {
        //        return NotFound("No existe el evento");
        //    }
        //    return Ok(evento);
        //}

        //[HttpPost]
        //public IActionResult Create([FromBody] Eventos newEvent)
        //{
            
        //        newEvent.id_evento = _eventos.Max(e => e.id_evento) + 1;
        //        _eventos.Add(newEvent);
        //        return CreatedAtAction(nameof(getById),
        //            new { id = newEvent.id_evento }, newEvent);     
        //}

        //[HttpPut]
        //public IActionResult Edit(int id, [FromBody] Eventos editedEvent)
        //{
        //    // validar que el evento si exista
        //    var evento_existente = _eventos.FirstOrDefault(e => e.id_evento == id);
        //    // si no existe el objeto (evento) retornamos un not found
        //    if (evento_existente == null) return NotFound();
        //    // modificar cada atributo del objeto si existe
        //    evento_existente.nombre_evento = editedEvent.nombre_evento;
        //    evento_existente.fecha_evento = editedEvent.fecha_evento;
        //    evento_existente.artista = editedEvent.artista;

        //    return NoContent();
        //}

        //[HttpPatch("{id}/soft-delete")]
        //public IActionResult SoftDelete(int id)
        //{
        //    // validar que el evento si exista
        //    var evento_existente = _eventos.FirstOrDefault(e => e.id_evento == id);
        //    // si no existe el objeto (evento) retornamos un not found
        //    if (evento_existente == null) return NotFound();

        //    evento_existente.isActive = 0;

        //    return Ok($"El evento ID:{id} se ha desactivado");
        //}

        


    }
}
