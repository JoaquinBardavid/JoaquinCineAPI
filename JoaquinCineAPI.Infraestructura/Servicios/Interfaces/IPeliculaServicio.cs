using JoaquinCineAPI.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaquinCineAPI.Infraestructura.Servicios.Interfaces
{
    public interface IPeliculaServicio
    {
        Pelicula Get(Guid id);
        IEnumerable<Pelicula> Get();
        void NuevaPelicula(string titulo, int salaId, string img);
        void UpdateTitulo(Pelicula pelicula);
        void UpdateCartelera(Pelicula pelicula);
        void DeletePelicula(Guid id);
        bool SaveChanges();

    }
}
