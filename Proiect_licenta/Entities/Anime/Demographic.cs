using System;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.Anime
{
    public class Demographic
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Mal_id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
