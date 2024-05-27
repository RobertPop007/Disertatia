using Newtonsoft.Json;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.Games.GamesIds;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Entities;
using Disertatie_backend.DTO;
using Disertatie_backend.Entities.Anime;
using System;
using System.Net.Http;
using Disertatie_backend.Entities.Games.GameTrailer;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedGames
    {
        public static async Task SeedAllGamesIds(DatabaseSettings databaseSettings)
        {
            var mongoDbClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.DatabaseName);

            var _gamesCollection = mongoDb.GetCollection<Game>(databaseSettings.CollectionList["GamesCollection"]);

            //var documents = await _gamesCollection.Find(_ => true).ToListAsync();

            //var defaultReviews = new List<ReviewDto>();
            //var update = Builders<Game>.Update.Set(x => x.Trailer, defaultReviews);
            //_gamesCollection.UpdateMany(FilterDefinition<Game>.Empty, update);
            var filter = Builders<Game>.Filter.Empty; // Match all documents
            //var options = new FindOptions<Game> { Sort = Builders<Game>.Sort.Descending("Rating"), Limit = 10000 };
            var cursor = await _gamesCollection.FindAsync(filter);
            await cursor.ForEachAsync(async doc =>
            {
                // Delete each document
                var url = $"https://api.rawg.io/api/games/{doc.GameId}/movies?key=9818629e6e0e4f71871839141551f960";
                var trailer = await AddTrailerToGame(url);
                var update = Builders<Game>.Update.Set(x => x.Trailer, trailer);
                _gamesCollection.UpdateMany(FilterDefinition<Game>.Empty, update);
            });
            //var defaultReviews = new List<Review>();
            //var update = Builders<Game>.Update.Set(x => x.Reviews, defaultReviews);
            //_gamesCollection.UpdateMany(FilterDefinition<Game>.Empty, update);

            //var gamesIds = new List<int>();

            //SeedGameId(gamesIds, "https://api.rawg.io/api/games?key=9818629e6e0e4f71871839141551f960");

            //for (var i = 462; i <= 502; i++)
            //{
            //    try
            //    {
            //        if(i!=62 && i!=352)
            //        SeedGameId(gamesIds, $@"https://api.rawg.io/api/games?key=9818629e6e0e4f71871839141551f960&page={i}");
            //    }
            //    catch (Exception ex)
            //    {

            //        throw;
            //    }
                
            //}


            //foreach (var gameId in gamesIds)
            //{
            //    await SeedGame(_gamesCollection, $@"https://api.rawg.io/api/games/{gameId}?key=9818629e6e0e4f71871839141551f960");
            //}
        }

        public static void SeedGameId(List<int> gamesIds, string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string returnedUrl = reader.ReadToEnd();
                var ids = JsonConvert.DeserializeObject<Root>(returnedUrl);

                foreach (var result in ids.Results)
                {
                    gamesIds.Add(result.Id);
                }
            }
        }

        private static async Task<string> AddTrailerToGame(string url)
        {

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var gameTrailer = JsonConvert.DeserializeObject<GameTrailer>(responseBody);

                    return gameTrailer.Results[0].Data.Max;
                }

                return string.Empty;
            }
        }

        public static async Task SeedGame(IMongoCollection<Game> _gamesCollection, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var game = JsonConvert.DeserializeObject<Game>(responseBody);

                    await _gamesCollection.InsertOneAsync(game);
                }
            }

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //using (Stream stream = response.GetResponseStream())
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    string returnedUrl = reader.ReadToEnd();
            //    var game = JsonConvert.DeserializeObject<Game>(returnedUrl);

            //    await _gamesCollection.InsertOneAsync(game);
            //}
        }
    }
}
