using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.Movies;

public class Item
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Image { get; set; }
}
