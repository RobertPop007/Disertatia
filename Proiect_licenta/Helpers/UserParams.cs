using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_licenta.Helpers
{
    public class UserParams : PaginationParams
    {

        public string CurrentUsername { get; set; }

        public string SearchedUsername { get; set; }
        public string OrderBy { get; set; } = "username";
    }
}
