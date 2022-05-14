using Newtonsoft.Json;
using Proiect_licenta.Entities.Manga;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Proiect_licenta.DatabaseContext
{
    public class SeedManga
    {
        public static async Task SeedAllManga(DataContext context)
        {
            //if (!context.Manga.Any())
            //{
            //    await SeedMangaList(context, "https://api.jikan.moe/v4/top/manga");

            //    for (var i = 2; i < 100; i++)
            //    {
            //        System.Threading.Thread.Sleep(3000);
            //        await SeedMangaList(context, $"https://api.jikan.moe/v4/top/manga?page={i}");
            //    }
            //}

            //await SeedMangaList(context, "https://api.jikan.moe/v4/top/manga");

            //for (var i = 2; i < 150; i++)
            //{
            //    System.Threading.Thread.Sleep(3000);
            //    await SeedMangaList(context, $"https://api.jikan.moe/v4/top/manga?page={i}");
            //}

            await context.SaveChangesAsync();
        }

        public static async Task SeedMangaList(DataContext context, string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string returnedUrl = reader.ReadToEnd();
                var allManga = JsonConvert.DeserializeObject<Manga>(returnedUrl);

                foreach (var manga in allManga.Data)
                {
                    var mangaAlreadyExists = context.Manga.Any(x => x.Mal_id == manga.Mal_id);
                    if (mangaAlreadyExists == false)
                    {
                        await context.Manga.AddAsync(manga);
                    }
                }
            }
        }
    }
}
