using System;

namespace JoaquinCineAPI.Response
{
    public class GetPeliculaResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public int SalaId { get; set; }
        public string Img { get; set; }
    }
}
