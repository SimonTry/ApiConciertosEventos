using ApiConciertos.Models;

namespace ApiConciertos.Interfaces
{
    public interface IEventosService
    {
        List<Eventos> GetAll();
        Eventos getById(int id);

        //Eventos Create(Eventos evento);

        //bool Update(int id, Eventos evento);

        //bool SoftDelete(int id);
    }
}
