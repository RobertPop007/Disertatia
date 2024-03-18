using System;

namespace Backend.Entities.Manga;

public class ImagesManga
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public JpgManga Jpg { get; set; }
    public WebpManga Webp { get; set; }
}
