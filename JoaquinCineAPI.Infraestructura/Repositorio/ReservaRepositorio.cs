using JoaquinCineAPI.Modelo.Interfaces;
using JoaquinCineAPI.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaquinCineAPI.Infraestructura.Repositorio
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private DBContext context;
        public ReservaRepositorio(DBContext _context)
        {
            context = _context;
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0; //cantidad de lineas de datos cambiados en bd (>0 = todo bien)
        }

        public IEnumerable<Reserva> Get()
        {
            return context.Reservas.ToList();
        }

        public Reserva Get(Guid id)
        {
            return context.Reservas.Where(Reserva => Reserva.Id == id).FirstOrDefault();
        }

        public void NuevaReserva(Reserva reserva)
        {
            reserva.Id = Guid.NewGuid();
            context.Reservas.Add(reserva);
        }

        public void DeleteReserva(Guid id)
        {
            var entry = Get(id);
            if (entry != null)
            {
                context.Reservas.Remove(entry);
            }
        }

        public IEnumerable<Reserva> GetByPeliId(Guid id)
        {
            return context.Reservas.Where(Reserva => Reserva.PeliId == id).ToList();
        }
    }
}
