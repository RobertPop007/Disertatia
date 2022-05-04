using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Games.GamesIds
{
    public class Root
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        public List<Result> Results { get; set; }
    }
}
