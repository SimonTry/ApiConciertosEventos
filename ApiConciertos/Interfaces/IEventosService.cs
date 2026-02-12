using ApiConciertos.Models;

namespace ApiConciertos.Interfaces
{
    public interface IEventosService
    {
        List<Eventos> GetAll();
        Eventos getById(Guid id);

        Eventos Create(Eventos evento);

        bool Update(Guid id, Eventos evento);

        bool ChangeStatus(Guid id);
    }
}
