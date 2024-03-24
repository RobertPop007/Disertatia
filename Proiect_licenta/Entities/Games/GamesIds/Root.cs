using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.Games.GamesIds
{
    public class Root
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        public List<Result> Results { get; set; }
    }
}
