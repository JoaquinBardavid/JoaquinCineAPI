using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaquinCineAPI.Modelo.Modelo
{
    public class Reserva
    {
        [Key]
        public Guid Id { get; set; }
        public int CantAsientos { get; set; }
        public Guid PeliId { get; set; }
        public Pelicula Peli { get; set; }
    }
}
