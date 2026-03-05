using ApiConciertos.Interfaces;
using ApiConciertos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiConciertos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // con este DataAnnotation solo se dejará ejecutar los endpoint a los JWT que sea de Admin
    // Si se quiere agregar ás roles se separa por comas Admin,User,Colab
    [Authorize(Roles = "Admin")]
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
        // Este DataAnnotation sirve para que este endpoint en específico no requiera de autenticación
        // Por defecto el authorize toma todos los endpoints que no tengan este indicativo
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() => Ok( await _eventService.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> getById(Guid id)
        {
            var evento = await _eventService.getById(id);
            //Se refactoriza condicion por una operación ternaria o si corto
            return evento != null ? Ok(evento) : NotFound();
            //if (evento == null)
            //{
            //    return NotFound("No existe el evento");
            //}
            //return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Eventos newEvent)
        {

            var createdEvent = await _eventService.Create(newEvent);
            return CreatedAtAction(nameof(getById),new { id = createdEvent.id_evento }, createdEvent);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Eventos editedEvent)
        {

            return await _eventService.Update(id, editedEvent) ? NoContent(): NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _eventService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del evento") : NotFound();
        }




    }
}
