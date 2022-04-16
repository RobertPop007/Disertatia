using System;

namespace Proiect_licenta.Entities.Manga
{
    public class JpgManga
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Image_url { get; set; }
        public string Small_image_url { get; set; }
        public string Large_image_url { get; set; }
    }
}
