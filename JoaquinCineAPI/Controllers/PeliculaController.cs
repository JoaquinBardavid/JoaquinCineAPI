using JoaquinCineAPI.Infraestructura.Servicios.Interfaces;
using JoaquinCineAPI.Modelo.Modelo;
using JoaquinCineAPI.Request;
using JoaquinCineAPI.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JoaquinCineAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {


        private IPeliculaServicio peliculaServicio;

        public PeliculaController(IPeliculaServicio _peliculaServicio)
        {
            peliculaServicio = _peliculaServicio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetPeliculaResponse>> Get()
        {
            return Ok(peliculaServicio.Get().Select(p => new GetPeliculaResponse{
                SalaId = p.SalaId,
                Id = p.Id,
                Titulo = p.Titulo,
                Img = "data:image/jpeg;base64," + Convert.ToBase64String(p.Imagen)
            }));
        }

        [HttpPost]
        public ActionResult NuevaPelicula([FromBody] NuevaPeliculaRequest request)
        {
            peliculaServicio.NuevaPelicula(request.Titulo, request.SalaId, request.Img);
            return Ok();
        }

        [HttpGet("GetPeliculaPorId/{id}")]
        public ActionResult Get(Guid id)
        {
            return Ok(peliculaServicio.Get(id));
        }

        [HttpPut("CambioCartelera/{id}")]
        public ActionResult UpdateCartelera(Guid id, [FromBody] UpdatePeliculaRequest request)
        {
            Pelicula pelicula = new Pelicula();
            pelicula.Id = id;
            pelicula.SalaId = request.SalaId;
            peliculaServicio.UpdateCartelera(pelicula);
            return Ok();
        }

        [HttpDelete("BorrarPelicula/{id}")]
        public void Delete(Guid id)
        {
            peliculaServicio.DeletePelicula(id);
        }

    }
}
