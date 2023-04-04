using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaquinCineAPI.Modelo.Modelo
{
    public class Pelicula
    {
        [Key]
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public int SalaId { get; set; }
        public byte[] Imagen { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}