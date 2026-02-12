using ApiConciertos.Interfaces;
using ApiConciertos.Models;

namespace ApiConciertos.Services
{
    public class EventosService : IEventosService
    {
        private static List<Eventos> _eventos = new List<Eventos>
        {
            new Eventos {id_evento = Guid.NewGuid(), nombre_evento="Quiz 1 Ing Web", fecha_evento="17-02-2026", artista="los Inges", isActive = 1}
        };

        public List<Eventos> GetAll() => _eventos.Where(e => e.isActive == 1).ToList();

        public Eventos getById(Guid id)  => _eventos.FirstOrDefault(e => e.id_evento == id);


        public Eventos Create(Eventos newEvent)
        {
            //Generamos un Id para el nuevo registro que está entrando
            newEvent.id_evento = Guid.NewGuid();
            //Agregamos el registro a la lista
            _eventos.Add(newEvent);
            return newEvent;
        }

        public bool Update(Guid id, Eventos editedEvent)
        {
            //validar la existencia de un ente supremo
            var eventoExiste = getById(id);
            if (eventoExiste == null) return false;

            eventoExiste.nombre_evento = editedEvent.nombre_evento;
            eventoExiste.fecha_evento = editedEvent.fecha_evento;
            eventoExiste.artista = editedEvent.artista;

            return true;
        }

        public bool ChangeStatus(Guid id)
        {
            var existe = getById(id);
            if (existe == null) return false;

            existe.isActive = existe.isActive == 1 ? 0 : 1;

            return true;
        }


    }
}
