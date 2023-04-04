using JoaquinCineAPI.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaquinCineAPI.Modelo.Interfaces
{
    public interface IPeliculaRepositorio
    {
        Pelicula Get(Guid id);
        IEnumerable<Pelicula> Get();
        void NuevaPelicula(Pelicula pelicula);
        void UpdateTitulo(Pelicula pelicula);
        void UpdateCartelera(Pelicula pelicula);
        void DeletePelicula(Guid id);
        bool SaveChanges();
    }
}