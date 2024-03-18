using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.Games.Game;

public class PublisherGame
{
    [Key]
    public Guid PublisherGameId { get; set; } = Guid.NewGuid();
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public int Games_count { get; set; }
    public string Image_background { get; set; }
}
