using System;

namespace Backend.Entities.Anime;

public class Webp
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Image_url { get; set; }
    public string Small_image_url { get; set; }
    public string Large_image_url { get; set; }
}
