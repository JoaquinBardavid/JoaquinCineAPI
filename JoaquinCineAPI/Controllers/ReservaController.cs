using JoaquinCineAPI.Infraestructura.Servicios.Interfaces;
using JoaquinCineAPI.Modelo.Modelo;
using JoaquinCineAPI.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace JoaquinCineAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {

        private IReservaServicio reservaServicio;

        public ReservaController(IReservaServicio _reservaServicio)
        {
            reservaServicio = _reservaServicio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Reserva>> Get()
        {
            return Ok(reservaServicio.Get());
        }

        [HttpGet("GetReservaPorIdPelicula/{id}")]
        public ActionResult GetByPeliId(Guid id)
        {
            return Ok(reservaServicio.GetByPeliId(id));
        }

        [HttpPost]
        public ActionResult NuevaReserva([FromBody] NuevaReservaRequest request)
        {
            reservaServicio.NuevaReserva(request.CantAsientos, request.PeliId);
            return Ok();
        }

        [HttpDelete("BorrarReserva/{id}")]
        public void Delete(Guid id)
        {
            reservaServicio.DeleteReserva(id);
        }
    }
}
