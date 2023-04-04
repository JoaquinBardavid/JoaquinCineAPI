using JoaquinCineAPI.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaquinCineAPI.Modelo.Interfaces
{
    public interface IReservaRepositorio
    {
        Reserva Get(Guid id);
        IEnumerable<Reserva> Get();
        IEnumerable<Reserva> GetByPeliId(Guid id);
        void NuevaReserva(Reserva reserva);
        void DeleteReserva(Guid id);
        bool SaveChanges();
    }
}
