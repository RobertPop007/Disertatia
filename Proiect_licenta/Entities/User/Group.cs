using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.User
{
    public class Group
    {
        public Group(string name)
        {
            Name = name;
        }

        public Group()
        {
        }

        [Key]
        public string Name { get; set; }
        public ICollection<Connection> Connections { get; set; } = new List<Connection>();
    }
}
