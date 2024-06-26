﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.Movies;

public class WriterList
{
    [Key]
    public Guid WriterId { get; set; } = Guid.NewGuid();
    public string Id { get; set; }
    public string Name { get; set; }
}
