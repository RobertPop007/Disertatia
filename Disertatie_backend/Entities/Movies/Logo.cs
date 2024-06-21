using Newtonsoft.Json;

namespace Disertatie_backend.Entities.Movies
{
    public class Logo
    {
        public double AspectRatio { get; set; }

        public int Height { get; set; }

        public string Iso6391 { get; set; }

        public string FilePath { get; set; }

        public double VoteAverage { get; set; }

        public int VoteCount { get; set; }

        public int Width { get; set; }
    }
}
