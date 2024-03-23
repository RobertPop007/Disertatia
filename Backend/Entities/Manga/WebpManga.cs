using System;

namespace Backend.Entities.Manga;

public class WebpManga
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Image_url { get; set; }
    public string Small_image_url { get; set; }
    public string Large_image_url { get; set; }
}
