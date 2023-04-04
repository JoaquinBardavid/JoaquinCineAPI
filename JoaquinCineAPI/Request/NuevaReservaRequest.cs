using System;

namespace JoaquinCineAPI.Request
{
    public class NuevaReservaRequest
    {
        public int CantAsientos { get; set; }
        public Guid PeliId { get; set; }
    }
}
