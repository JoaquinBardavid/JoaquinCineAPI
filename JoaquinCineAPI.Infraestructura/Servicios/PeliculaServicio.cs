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
    public class PeliculaServicio : IPeliculaServicio
    {
        public IPeliculaRepositorio peliculaRepositorio;
        public PeliculaServicio(IPeliculaRepositorio _peliculaRepositorio)
        {
            peliculaRepositorio = _peliculaRepositorio;
        }

        public void DeletePelicula(Guid id)
        {
            peliculaRepositorio.DeletePelicula(id);
            peliculaRepositorio.SaveChanges();
        }

        public Pelicula Get(Guid id)
        {
            return peliculaRepositorio.Get(id);
        }

        public IEnumerable<Pelicula> Get()
        {
            
            return peliculaRepositorio.Get();
        }

        public void NuevaPelicula(string titulo, int salaId, string img)
        {
            Pelicula pelicula = new Pelicula();

            pelicula.Id =  Guid.NewGuid();
            pelicula.Titulo = titulo;
            pelicula.SalaId = salaId;
            string[] img64 = img.Split(',');
            pelicula.Imagen = Convert.FromBase64String(img64[1]);
            peliculaRepositorio.NuevaPelicula(pelicula);
            SaveChanges();
        }

        public bool SaveChanges()
        {
            return peliculaRepositorio.SaveChanges();
        }

        public void UpdateCartelera(Pelicula pelicula)
        {
            peliculaRepositorio.UpdateCartelera(pelicula);
            peliculaRepositorio.SaveChanges();
        }

        public void UpdateTitulo(Pelicula pelicula)
        {
            peliculaRepositorio.UpdateTitulo(pelicula);
            peliculaRepositorio.SaveChanges();
        }
    }
}
