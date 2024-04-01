using Newtonsoft.Json;
using Disertatie_backend.Entities.Anime;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedAnime
    {
        public static async Task SeedAllAnime()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDb = mongoClient.GetDatabase("Database_disertație");

            var _animeCollection = mongoDb.GetCollection<Datum>("Anime");

            if (_animeCollection.CountDocuments(_ => true) >= 0)
            {
                await SeedAnimeList(_animeCollection, "https://api.jikan.moe/v4/top/anime");

                //for (var i = 2; i < 1500; i++)
                //{
                //    System.Threading.Thread.Sleep(1000);
                //    await SeedAnimeList(_animeCollection, $"https://api.jikan.moe/v4/top/anime?page={i}");
                //}
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
                    //var animeAlreadyExists = _animeCollection.FindAsync(x => x.Mal_id == anime.Mal_id);
                    //if (animeAlreadyExists == null)
                    //{
                        await _animeCollection.InsertOneAsync(anime);
                    //}
                }
            }
        }
    }
}
