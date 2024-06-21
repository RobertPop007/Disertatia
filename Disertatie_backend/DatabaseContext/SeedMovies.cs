using Newtonsoft.Json;
using Disertatie_backend.Entities.Movies;
using System.Threading.Tasks;
using Disertatie_backend.Configurations;
using MongoDB.Driver;
using System.Collections.Generic;
using Disertatie_backend.Entities.Movies.MovieIds;
using System.Net.Http;
using System;
using System.Linq;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedMovies
    {
        private static List<int> moviesIds = new List<int>();
        public static async Task SeedAllMovies(DatabaseSettings databaseSettings)
        {
            for (var i = 1; i <= 500; i++)
            {
                var endpoint = $"https://api.themoviedb.org/3/movie/top_rated?language=en-US&page={i}";
                moviesIds.AddRange(await SeedMoviesIds(endpoint));
            }

            var mongoDbClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.DatabaseName);
            
            var _moviesCollection = mongoDb.GetCollection<Movie>(databaseSettings.CollectionList["MoviesCollection"]);
            
            foreach (var id in moviesIds)
            {
                await SeedTrueMoviesList(_moviesCollection, $"https://api.themoviedb.org/3/movie/{id}?&append_to_response=videos,similar,images,credits&api_key=ff82c60470d3f2939794a05f8e248a89");
            }
        }

        public static async Task SeedTrueMoviesList(IMongoCollection<Movie> _moviesCollection, string url)
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
                        var movie = JsonConvert.DeserializeObject<Movie>(responseBody);

                        await _moviesCollection.InsertOneAsync(movie);
                    }
                    catch { throw; }
                }
            }
        }

        public static async Task<List<int>> SeedMoviesIds(string url)
        {
            var token = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmZjgyYzYwNDcwZDNmMjkzOTc5NGEwNWY4ZTI0OGE4OSIsInN1YiI6IjYxNGY5YzdmMTQwYmFkMDAyNTNiNzE0OCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.-daJoGBoJfNzeJSJPl9bd47IzN5RZanP3eiC235gFLI";
            var listToReturn = new List<int>();

            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var movie = JsonConvert.DeserializeObject<Root>(responseBody);

                    foreach (var item in movie.Results.Select(x => x.Id))
                    {
                        listToReturn.Add(item);
                    };
                }
            }

            return listToReturn;
        }
    }
}
