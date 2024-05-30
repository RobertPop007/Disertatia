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
            //for (var i = 251; i <= 500; i++)
            //{
            //    var endpoint = $"https://api.themoviedb.org/3/movie/top_rated?language=en-US&page={i}";
            //    moviesIds.AddRange(await SeedMoviesIds(endpoint));
            //}

            var mongoDbClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.DatabaseName);
            
            var _moviesCollection = mongoDb.GetCollection<Movie>(databaseSettings.CollectionList["MoviesCollection"]);
            var filter = Builders<Movie>.Filter.Empty; // Match all documents
            var options = new FindOptions<Movie> { Sort = Builders<Movie>.Sort.Descending("VoteAverage"), Limit = 324 };
            var cursor = await _moviesCollection.FindAsync(filter, options);
            await cursor.ForEachAsync(async doc =>
            {
                // Delete each document
                await _moviesCollection.DeleteOneAsync(Builders<Movie>.Filter.Eq("_id", doc.Id));
            });
            //foreach (var id in moviesIds)
            //{
            //    await SeedTrueMoviesList(_moviesCollection, $"https://api.themoviedb.org/3/movie/{id}?&append_to_response=videos,similar,images,credits&api_key=ff82c60470d3f2939794a05f8e248a89");
            //}

            //var documents = await _moviesCollection.Find(_ => true).ToListAsync();

            //var defaultReviews = new List<ReviewDto>();
            //var update = Builders<Movie>.Update.Set(x => x.Reviews, defaultReviews);
            //_moviesCollection.UpdateMany(FilterDefinition<Movie>.Empty, update);

            //if (!context.Top250Movies.Any())
            //{
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/Top250Movies/k_k49hz8mt");
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls020043828");
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls060044601");
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls053951083");
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls002712620");
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls036694571");
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls020828441");
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls023836170");
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls041805722");
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls000028602");
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls094143100");
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls000068347");
            //    await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls006153007");
            //}

            //if(!context.Movies.Any())
            //{
            //    var idList = context.Top250Movies.Select(x => x.Id).Skip(0).Take(3318).ToList();

            //    foreach (var id in idList)
            //    {
            //    }

            //    foreach (var movie in context.Movies
            //        .IncludeOptimized(o => o.Similars))
            //    {
            //        foreach (var similarMovie in movie.Similars.ToList())
            //        {
            //            var fullTitleToAdd = context.Movies.FirstOrDefault(x => x.Title == similarMovie.Title);

            //            if (fullTitleToAdd == null) movie.Similars.Remove(similarMovie);
            //        }
            //    }
            //}
        }

        //public static async Task SeedMoviesList(DataContext context, string url)
        //{

        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


        //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //    using (Stream stream = response.GetResponseStream())
        //    using (StreamReader reader = new StreamReader(stream))
        //    {
        //        string returnedUrl = reader.ReadToEnd();
        //        var movies = JsonConvert.DeserializeObject<MovieGeneralInfo>(returnedUrl);

        //        foreach (var movie in movies.Items)
        //        {
        //            if (context.Top250Movies.FirstOrDefault(x => x.Id == movie.Id) == null)
        //            {
        //                await context.Top250Movies.AddAsync(movie);
        //            }
        //        }
        //    }
        //}

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

                        movie.Videos.Results = movie.Videos.Results.Take(5).ToList();
                        movie.Similar.Results = movie.Similar.Results.Take(10).ToList();
                        movie.Images.Backdrops = movie.Images.Backdrops.Take(5).ToList();
                        movie.Images.Logos = movie.Images.Logos.Take(5).ToList();
                        movie.Images.Posters = movie.Images.Posters.Take(5).ToList();
                        movie.Credits.Cast = movie.Credits.Cast.Take(15).ToList();
                        movie.Credits.Crew = movie.Credits.Crew.Take(10).ToList();

                        //foreach(var property in typeof(Movie).GetProperties())
                        //{
                        //    var value = property.GetValue(movie);
                        //    if(value != null)
                        //    {
                        //        movieWithoutNullValues.Add(property.Name, BsonValue.Create(value));
                        //        _moviesCollection.
                        //    }
                        //}

                        await _moviesCollection.InsertOneAsync(movie);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
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
                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var movie = JsonConvert.DeserializeObject<Root>(responseBody);

                    foreach (var item in movie.Results.Select(x => x.Id))
                    {
                        listToReturn.Add(item);
                    };
                }
            }

            return listToReturn;

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //using (Stream stream = response.GetResponseStream())
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    string returnedUrl = reader.ReadToEnd();
            //    var movie = JsonConvert.DeserializeObject<Result>(returnedUrl);

            //    listToReturn.Add(movie.Id);
            //}

            //return listToReturn;
        }
    }
}
