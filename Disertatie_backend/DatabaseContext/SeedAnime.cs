using Newtonsoft.Json;
using Disertatie_backend.Entities.Anime;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using MongoDB.Driver;
using Disertatie_backend.Configurations;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedAnime
    {
        public static async Task SeedAllAnime(DatabaseSettings databaseSettings)
        {
            var mongoDbClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.DatabaseName);

            var _animeCollection = mongoDb.GetCollection<Datum>(databaseSettings.CollectionList["AnimeCollection"]);

            await SeedAnimeList(_animeCollection, "https://api.jikan.moe/v4/top/anime");

            for (var i = 2; i <= 1081; i++)
            {
                System.Threading.Thread.Sleep(1000);
                await SeedAnimeList(_animeCollection, $"https://api.jikan.moe/v4/top/anime?page={i}");
            }
        }

        public static async Task SeedAnimeList(IMongoCollection<Datum> _animeCollection, string url)
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
                    await _animeCollection.InsertOneAsync(anime);
                }
            }
        }
    }
}
