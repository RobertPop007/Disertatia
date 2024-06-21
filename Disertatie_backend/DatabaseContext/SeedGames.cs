using Newtonsoft.Json;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.Games.GamesIds;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Disertatie_backend.Configurations;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Net.Http;
using Disertatie_backend.Entities.Games.GameTrailer;
using System;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedGames
    {
        public static async Task SeedAllGamesIds(DatabaseSettings databaseSettings)
        {
            var mongoDbClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.DatabaseName);

            var _gamesCollection = mongoDb.GetCollection<Game>(databaseSettings.CollectionList["GamesCollection"]);

            var gamesIds = new List<int>();

            SeedGameId(gamesIds, "https://api.rawg.io/api/games?key=9818629e6e0e4f71871839141551f960");

            for (var i = 0; i <= 502; i++)
            {
                SeedGameId(gamesIds, $@"https://api.rawg.io/api/games?key=9818629e6e0e4f71871839141551f960&page={i}");
            }

            foreach (var gameId in gamesIds)
            {
                await SeedGame(_gamesCollection, $@"https://api.rawg.io/api/games/{gameId}?key=9818629e6e0e4f71871839141551f960");
            }
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
        }
    }
}
