using System;

namespace Disertatie_backend.Entities.Anime
{
    public class Trailer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Youtube_id { get; set; }
        public string Url { get; set; }
        public string Embed_url { get; set; }
        public Images Images { get; set; }
    }
}
