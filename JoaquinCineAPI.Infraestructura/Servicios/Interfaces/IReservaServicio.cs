using JoaquinCineAPI.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaquinCineAPI.Infraestructura.Servicios.Interfaces
{
    public interface IReservaServicio
    {
        Reserva Get(Guid id);
        IEnumerable<Reserva> Get();
        IEnumerable<Reserva> GetByPeliId(Guid id);
        void NuevaReserva(int CantAsientos, Guid PeliId);
        void DeleteReserva(Guid id);
        bool SaveChanges();
    }
}
