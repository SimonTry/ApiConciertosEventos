using ApiConciertos.Models;

namespace ApiConciertos.Interfaces
{
    public interface IEventosService
    {
        Task<List<Eventos>> GetAll();
        Task<Eventos?> getById(Guid id);

        Task<Eventos> Create(Eventos evento);

        Task<bool> Update(Guid id, Eventos evento);

        Task<bool> ChangeStatus(Guid id);
    }
}
