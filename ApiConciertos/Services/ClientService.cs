using ApiConciertos.DAO;
using ApiConciertos.Models;
using ApiConciertos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiConciertos.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Clientes>> GetAll()
        {
            return await _context.Clients.Where(e => e.isActive == 1).ToListAsync();
        }

        public async Task<Clientes> getById(Guid id) => await _context.Clients.FindAsync(id);


        public async Task<Clientes> Create(Clientes newClient)
        {
            //Agregamos el registro a la lista
            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();
            return newClient;
        }

        public async Task<bool> Update(Guid id, Clientes editClient)
        {
            //validar la existencia de un ente supremo
            var clientExist = await getById(id);
            if (clientExist == null) return false;

            clientExist.nombre_cliente = editClient.nombre_cliente;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeStatus(Guid id)
        {
            // Verificamos si existe o no el registro
            var existe = await getById(id);
            if (existe == null) return false;

            existe.isActive = existe.isActive == 1 ? 0 : 1;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
