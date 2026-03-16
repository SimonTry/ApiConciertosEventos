using ApiConciertos.Interfaces;
using ApiConciertos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiConciertos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() => Ok(await _clientService.GetAll());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> getById(Guid id)
        {
            var evento = await _clientService.getById(id);
            //Se refactoriza condicion por una operación ternaria o si corto
            return evento != null ? Ok(evento) : NotFound();
            //if (evento == null)
            //{
            //    return NotFound("No existe el evento");
            //}
            //return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Clientes newClient)
        {

            var createdClient = await _clientService.Create(newClient);
            return CreatedAtAction(nameof(getById), new { id = createdClient.Cliente_Id }, createdClient);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Clientes editedClient)
        {

            return await _clientService.Update(id, editedClient) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _clientService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del evento") : NotFound();
        }
    }
}
