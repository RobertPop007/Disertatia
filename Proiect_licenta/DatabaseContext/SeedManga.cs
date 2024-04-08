﻿using Newtonsoft.Json;
using Disertatie_backend.Entities.Manga;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedManga
    {
        public static async Task SeedAllManga(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoDbClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.Value.DatabaseName);

            var _mangaCollection = mongoDb.GetCollection<DatumManga>(databaseSettings.Value.CollectionList["MangaCollection"]);

            await SeedMangaList(_mangaCollection, "https://api.jikan.moe/v4/top/manga");

            for (var i = 2; i <= 1081; i++)
            {
                System.Threading.Thread.Sleep(1000);
                await SeedMangaList(_mangaCollection, $"https://api.jikan.moe/v4/top/manga?page={i}");
            }
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
