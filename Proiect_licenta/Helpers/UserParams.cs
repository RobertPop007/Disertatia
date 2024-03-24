﻿namespace Disertatie_backend.Helpers
{
    public class UserParams : PaginationParams
    {

        public string CurrentUsername { get; set; }

        public string SearchedUsername { get; set; }
        public string OrderBy { get; set; } = "username";
    }
}
