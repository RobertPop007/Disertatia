using System;

namespace Proiect_licenta.Entities.Manga
{
    public class DemographicManga
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Mal_Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
