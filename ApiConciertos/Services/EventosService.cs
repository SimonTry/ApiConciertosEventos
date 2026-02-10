using ApiConciertos.Interfaces;
using ApiConciertos.Models;

namespace ApiConciertos.Services
{
    public class EventosService : IEventosService
    {
        private static List<Eventos> _eventos = new List<Eventos>();

        public List<Eventos> GetAll() => _eventos.Where(e => e.isActive == 1).ToList();

        public Eventos getById(int id)  => _eventos.FirstOrDefault(e => e.id_evento == id);


    }
}
