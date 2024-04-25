using Newtonsoft.Json;
using Disertatie_backend.Entities.Anime;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using MongoDB.Driver;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;
using Disertatie_backend.Entities;
using System.Collections.Generic;
using System.Xml;
using Disertatie_backend.Entities.User;
using AspNetCore.Identity.Mongo.Mongo;
using System;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedAnime
    {
        public static async Task SeedAllAnime(DatabaseSettings databaseSettings)
        {
            var mongoDbClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.DatabaseName);

            var _animeCollection = mongoDb.GetCollection<Datum>(databaseSettings.CollectionList["AnimeCollection"]);

            //var document = _animeCollection.Find(x => x.Id == new MongoDB.Bson.ObjectId("6611a0727b2649a4fd4e6ec0"));

            //var defaultReviews = new List<Review>();
            //var update = Builders<Datum>.Update.Set(x => x.ReviewsIds, new List<Guid>());
            //_animeCollection.UpdateMany(FilterDefinition<Datum>.Empty, update);


            ////if (_animeCollection.CountDocuments(_ => true) >= 0)
            ////{
            //await SeedAnimeList(_animeCollection, "https://api.jikan.moe/v4/top/anime");

            //    for (var i = 2; i <= 1081; i++)
            //    {
            //        System.Threading.Thread.Sleep(1000);
            //        await SeedAnimeList(_animeCollection, $"https://api.jikan.moe/v4/top/anime?page={i}");
            //    }
            ////}
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
