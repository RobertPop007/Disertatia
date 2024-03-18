using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Anime;

public class Studio
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Mal_id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
}
