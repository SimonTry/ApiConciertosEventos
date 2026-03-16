using ApiConciertos.Models;

namespace ApiConciertos.Interfaces
{
    public interface IClientService
    {
        Task<List<Clientes>> GetAll();
        Task<Clientes?> getById(Guid id);

        Task<Clientes> Create(Clientes evento);

        Task<bool> Update(Guid id, Clientes evento);

        Task<bool> ChangeStatus(Guid id);
    }
}
