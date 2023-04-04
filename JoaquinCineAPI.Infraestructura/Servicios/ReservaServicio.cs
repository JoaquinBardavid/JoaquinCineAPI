using JoaquinCineAPI.Infraestructura.Servicios.Interfaces;
using JoaquinCineAPI.Modelo.Interfaces;
using JoaquinCineAPI.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaquinCineAPI.Infraestructura.Servicios
{
    public class ReservaServicio : IReservaServicio
    {
        public IReservaRepositorio reservaRepositorio;
        public ReservaServicio(IReservaRepositorio _reservaRepositorio)
        {
            reservaRepositorio = _reservaRepositorio;
        }
        public void DeleteReserva(Guid id)
        {
            reservaRepositorio.DeleteReserva(id);
            reservaRepositorio.SaveChanges();
        }

        public Reserva Get(Guid id)
        {
            return reservaRepositorio.Get(id);
        }

        public IEnumerable<Reserva> Get()
        {
            return reservaRepositorio.Get();
        }

        public IEnumerable<Reserva> GetByPeliId(Guid id)
        {
            return reservaRepositorio.GetByPeliId(id);
        }

        public void NuevaReserva(int CantAsientos, Guid PeliId)
        {
            Reserva reserva = new Reserva();

            reserva.Id = Guid.NewGuid();
            reserva.CantAsientos = CantAsientos;
            reserva.PeliId = PeliId;

            reservaRepositorio.NuevaReserva(reserva);
            SaveChanges();
        }

        public bool SaveChanges()
        {
            return reservaRepositorio.SaveChanges();
        }

    }
}
