using ApiConciertos.DAO;
using ApiConciertos.Interfaces;
using ApiConciertos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiConciertos.Services
{
    public class EventosService : IEventosService
    {
       
        private readonly ApplicationDbContext _context;

        public EventosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Eventos>> GetAll()
        {
            return await _context.Events.Where(e => e.isActive == 1).ToListAsync();
        }

        public async Task<Eventos> getById(Guid id)  => await _context.Events.FindAsync(id);


        public async Task<Eventos> Create(Eventos newEvent)
        {
            //Agregamos el registro a la lista
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            return newEvent;
        }

        public async Task<bool> Update(Guid id, Eventos editedEvent)
        {
            //validar la existencia de un ente supremo
            var eventoExiste = await getById(id);
            if (eventoExiste == null) return false;

            eventoExiste.nombre_evento = editedEvent.nombre_evento;
            eventoExiste.fecha_evento = editedEvent.fecha_evento;
            eventoExiste.artista = editedEvent.artista;

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
