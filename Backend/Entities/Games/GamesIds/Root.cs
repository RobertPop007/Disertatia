using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.Games.GamesIds;

public class Root
{
    [Key]
    public Guid Id { get; set; } = new Guid();
    public List<Result> Results { get; set; }
}
