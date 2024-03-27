using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disertatie_backend.Entities.Manga
{
    public class DatumManga
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Mal_id { get; set; }
        public string Url { get; set; }
        public ImagesManga Images { get; set; }
        public string Title { get; set; }
        public string Title_english { get; set; }
        public string Title_japanese { get; set; }
        public string Type { get; set; }
        public int? Chapters { get; set; }
        public int? Volumes { get; set; }
        public string Status { get; set; }
        public bool Publishing { get; set; }
        public PublishedManga Published { get; set; }
        public double? Score { get; set; }
        public double Scored { get; set; }
        public int Scored_by { get; set; }
        public int? Rank { get; set; }
        public int? Popularity { get; set; }
        public int Members { get; set; }
        public int Favorites { get; set; }
        public string Synopsis { get; set; }
        public string Background { get; set; }
        public IList<AuthorManga> Authors { get; set; }
        public IList<SerializationManga> Serializations { get; set; }
        public IList<GenreManga> Genres { get; set; }
        public IList<ThemeManga> Themes { get; set; }
        public IList<DemographicManga> Demographics { get; set; }
        public IList<AppUserMangaItem> AppUserManga { get; set; }
    }
}
