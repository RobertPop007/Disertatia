using System.Collections.Generic;

namespace Disertatie_backend.Configurations
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public IDictionary<string, string> CollectionList { get; set; }

    }
}
