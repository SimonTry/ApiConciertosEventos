using ApiConciertos.Models;
namespace ApiConciertos.Interfaces
{
    public interface ITicketService
    {
        Task<List<Boleta>> GetAll();
        Task<List<Boleta?>> getByClientId(Guid id, string identifier);

        Task<Boleta> Create(Boleta ticket);

        Task<bool> ValidateTk(Guid id);

        Task<bool> CancelTk(Guid id);
    }
}
