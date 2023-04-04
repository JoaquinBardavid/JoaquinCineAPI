using JoaquinCineAPI.Modelo.Interfaces;
using JoaquinCineAPI.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaquinCineAPI.Infraestructura.Repositorio
{
    public class PeliculaRepositorio : IPeliculaRepositorio
    {
        private DBContext context;
        public PeliculaRepositorio(DBContext _context)
        {
            context = _context;
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0;//cantidad de lineas de datos cambiados en bd (>0 = todo bien)
        }

        public IEnumerable<Pelicula> Get()
        {
            return context.Peliculas.ToList();
        }

        public Pelicula Get(Guid id)
        {
            return context.Peliculas.Where(Pelicula => Pelicula.Id == id).FirstOrDefault();
        }

        public void NuevaPelicula(Pelicula pelicula)
        {
            pelicula.Id = Guid.NewGuid();
            context.Peliculas.Add(pelicula);
        }

        public void UpdateTitulo(Pelicula pelicula)
        {
            var entry = Get(pelicula.Id);
            if (entry != null)
            {
                entry.Titulo = pelicula.Titulo;
            }
        }

        public void UpdateCartelera(Pelicula pelicula) 
        {
            var entry = Get(pelicula.Id);
            if (entry != null)
            {
                entry.SalaId = pelicula.SalaId;
            }
        }

        public void DeletePelicula(Guid id)
        {
            var entry = Get(id);
            if (entry != null)
            {
                context.Peliculas.Remove(entry);
            }
        }

    }
}
