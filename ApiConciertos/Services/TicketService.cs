using Microsoft.EntityFrameworkCore;
using ApiConciertos.DAO;
using ApiConciertos.Interfaces;
using ApiConciertos.Models;

namespace Replica.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Boleta>> GetAll()
        {
            return await _context.Tickets.Include(t => t.Evento).Include(t => t.Cliente).ToListAsync();
        }
        public async Task<List<Boleta?>> getByClientId(Guid client_id, string identifier)
        {
            // llamamos el método que valida si realmente el cliente es quién dice ser
            // es decir, validamos que el JWT generado si corresponda al cliente
            // del cual se desea obtener la información
            if (!await validateIdentity(client_id, identifier)) return null;

            return await _context.Tickets.Include(t => t.Evento).Where(c => c.ClienteId == client_id).ToListAsync();
        }

        public async Task<Boleta?> Create(Boleta ticket)
        {
            int eventExist = _context.Events.Where(e => e.id_evento == ticket.EventoId).Count();
            if (eventExist == 0) throw new Exception("Event not found");

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<bool> ValidateTk(Guid id)
        {
            var tkExist = await _context.Tickets.FindAsync(id);
            if (tkExist == null) return false;

            tkExist.ticketStatus = "Enjoyed";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CancelTk(Guid id)
        {
            var tkExist = await _context.Tickets.FindAsync(id);
            if (tkExist == null) return false;

            tkExist.ticketStatus = "Cancelled";
            await _context.SaveChangesAsync();
            return true;
        }


        /***
         * Creamos un método privado con la finalidad de validar el token y la vulnerabilidad de cibersegurudad BOLA
         * Broken Object Leven Authorization
         * Esta vulnerabilidad consiste en que se puede tener un token de un cliente y con este rol de cliente
         * Acceder a los endpoints que tien autorizados, pero ¿qué garantiza que yo si soy el cliente?
         * Es decir, podemos reclamar un JWT con el rol de Cliente y este puede entrar a los endpoints
         * autorizados para el rol de cliente, eso no significa que el cliente Carlos, pueda ver la información
         * de la cliente Mariana.
         * Para evitar esa suplantación de identidad en el modelo de cliente se agrega una Fk con IdentityUser
         * Que es la clase que administra los usuarios
         * El id del usuario como ya ha sido agregado previamente en el JWT como un claim lo vamos a tomar
         * Y validar contra el IdentityID que tiene el cliente al momento de su creación
         * Si estos no coinciden es una suplatanción, de lo contrario si es el cliente que dice ser
         */
        private async Task<bool> validateIdentity(Guid client, string identifier)
        {
            var clientExist = await _context.Clients.FindAsync(client);
            return identifier == clientExist?.IdentityUserId;
        }
    }
}