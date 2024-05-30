using Newtonsoft.Json;
using Disertatie_backend.Entities.Manga;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Disertatie_backend.Configurations;
using MongoDB.Driver;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedManga
    {
        public static async Task SeedAllManga(DatabaseSettings databaseSettings)
        {
            var mongoDbClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.DatabaseName);

            var _mangaCollection = mongoDb.GetCollection<DatumManga>(databaseSettings.CollectionList["MangaCollection"]);

            //var documents = await _mangaCollection.Find(_ => true).ToListAsync();
            var filter = Builders<DatumManga>.Filter.Empty; // Match all documents
            var options = new FindOptions<DatumManga> { Sort = Builders<DatumManga>.Sort.Descending("_id"), Limit = 6025 };
            var cursor = await _mangaCollection.FindAsync(filter, options);
            await cursor.ForEachAsync(async doc =>
            {
                // Delete each document
                await _mangaCollection.DeleteOneAsync(Builders<DatumManga>.Filter.Eq("_id", doc.Id));
            });
            //var defaultReviews = new List<ReviewDto>();
            //var update = Builders<DatumManga>.Update.Set(x => x.Reviews, defaultReviews);
            //_mangaCollection.UpdateMany(FilterDefinition<DatumManga>.Empty, update);

            //var defaultReviews = new List<Review>();
            //var update = Builders<DatumManga>.Update.Set(x => x.Reviews, defaultReviews);
            //_mangaCollection.UpdateMany(FilterDefinition<DatumManga>.Empty, update);

            //await SeedMangaList(_mangaCollection, "https://api.jikan.moe/v4/top/manga");

            //for (var i = 2; i <= 1081; i++)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //    await SeedMangaList(_mangaCollection, $"https://api.jikan.moe/v4/top/manga?page={i}");
            //}
        }

        public static async Task SeedMangaList(IMongoCollection<DatumManga> _mangaCollection, string url)
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
                    await _mangaCollection.InsertOneAsync(manga);
                }
            }
        }
    }
}
