using Newtonsoft.Json;

namespace Disertatie_backend.Entities.Books
{
    public class BookThumbnail
    {
        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }
    }
}
