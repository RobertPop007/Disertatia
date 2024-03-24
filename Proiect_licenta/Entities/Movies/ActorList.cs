﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.Movies
{
    public class ActorList
    {
        [Key]
        public Guid ActorId { get; set; } = Guid.NewGuid();
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string AsCharacter { get; set; }
    }
}
