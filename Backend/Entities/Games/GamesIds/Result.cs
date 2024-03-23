using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.Games.GamesIds;

public class Result
{
    [Key]
    public Guid ResultId { get; set; } = new Guid();
    public int Id { get; set; }
}
