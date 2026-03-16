using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiConciertos.Interfaces;
using ApiConciertos.Models;
using System.Security.Claims;

namespace Replica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll() => Ok(await _ticketService.GetAll());

        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> getByClientId(Guid id)
        {
            // Capturamos el id del token o del Identity
            // Este Id es necesario para validar si ese usuario o JWT si corresponde al cliente
            // con esto se evita un error de vulnerabildiad
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                // se envía como argumento el id del cliente que pasa por parámetro en la URL get
                // Y se envía el id de la identidad para corrobar que si corresponda
            var ticket = await _ticketService.getByClientId(id, UserId);
            //Se refactoriza condicion por una operación ternaria o si corto
            return ticket != null ? Ok(ticket) : NotFound();
            //if (evento == null)
            //{
            //    return NotFound("No existe el evento");
            //}
            //return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Boleta newTicket)
        {

            var createdTk = await _ticketService.Create(newTicket);
            return Ok(createdTk);
        }

        [HttpPatch("{id}/enjoy")]
        public async Task<IActionResult> EnjoiTicket(Guid id)
        {

            return await _ticketService.ValidateTk(id) ? Ok("Enjoi the event") : NotFound();
        }

        [HttpPatch("{id}/cancell")]
        public async Task<IActionResult> CancelTicket(Guid id)
        {
            return await _ticketService.CancelTk(id) ? Ok("Ticket was cancelled") : NotFound();
        }
    }
}