using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Movies
{
    public class DirectorList
    {
        [Key]
        public Guid DirectorId { get; set; } = Guid.NewGuid();
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
