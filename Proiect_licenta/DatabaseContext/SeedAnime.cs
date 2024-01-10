using Newtonsoft.Json;
using Proiect_licenta.Entities.Anime;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Proiect_licenta.DatabaseContext
{
    public class SeedAnime
    {
        public static async Task SeedAllAnime(DataContext context)
        {
            //if (!context.Anime.Any())
            //{
            //    await SeedAnimeList(context, "https://api.jikan.moe/v4/top/anime");

            //    for (var i = 2; i < 100; i++)
            //    {
            //        System.Threading.Thread.Sleep(5000);
            //        await SeedAnimeList(context, $"https://api.jikan.moe/v4/top/anime?page={i}");
            //    }
            //}

            await context.SaveChangesAsync();
        }

        public static async Task SeedAnimeList(DataContext context, string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string returnedUrl = reader.ReadToEnd();
                var allAnime = JsonConvert.DeserializeObject<Anime>(returnedUrl);
                
                foreach (var anime in allAnime.Data)
                {
                    var animeAlreadyExists = context.Anime.Any(x => x.Mal_id == anime.Mal_id);
                    if (animeAlreadyExists == false)
                    {
                        await context.Anime.AddAsync(anime);
                    }
                }
            }
        }
    }
}
