using Newtonsoft.Json;
using Disertatie_backend.Entities.TvShows;
using System.Linq;
using System.Threading.Tasks;
using Disertatie_backend.Configurations;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Net.Http;
using Disertatie_backend.Entities.Games.GamesIds;
using System;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedTvShows
    {
        private static List<int> tvShowsIds = new List<int>();
        public static async Task SeedAllTvShows(DatabaseSettings databaseSettings)
        {
            for (var i = 0; i <= 500; i++)
            {
                var endpoint = $"https://api.themoviedb.org/3/tv/popular?language=en-US&page={i}";
                tvShowsIds.AddRange(await SeedTvShowsIds(endpoint));
            }

            var mongoDbClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.DatabaseName);

            var _tvShowsCollection = mongoDb.GetCollection<TvShow>(databaseSettings.CollectionList["TVShowsCollection"]);

            foreach (var id in tvShowsIds)
            {
                await SeedTrueTvShowList(_tvShowsCollection, $"https://api.themoviedb.org/3/tv/{id}?&append_to_response=videos,similar,images,credits&api_key=ff82c60470d3f2939794a05f8e248a89");
            }
        }

        public static async Task SeedTrueTvShowList(IMongoCollection<TvShow> _tvShowsCollection, string url)
        {
            var token = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmZjgyYzYwNDcwZDNmMjkzOTc5NGEwNWY4ZTI0OGE4OSIsInN1YiI6IjYxNGY5YzdmMTQwYmFkMDAyNTNiNzE0OCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.-daJoGBoJfNzeJSJPl9bd47IzN5RZanP3eiC235gFLI";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var tvShow = JsonConvert.DeserializeObject<TvShow>(responseBody);

                        await _tvShowsCollection.InsertOneAsync(tvShow);
                    }
                    catch { throw; }
                }
            }
        }

        public static async Task<List<int>> SeedTvShowsIds(string url)
        {
            var token = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmZjgyYzYwNDcwZDNmMjkzOTc5NGEwNWY4ZTI0OGE4OSIsInN1YiI6IjYxNGY5YzdmMTQwYmFkMDAyNTNiNzE0OCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.-daJoGBoJfNzeJSJPl9bd47IzN5RZanP3eiC235gFLI";
            var listToReturn = new List<int>();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var tvShow = JsonConvert.DeserializeObject<Root>(responseBody);

                    foreach (var item in tvShow.Results.Select(x => x.Id))
                    {
                        listToReturn.Add(item);
                    };
                }
            }

            return listToReturn;
        }
    }
}
