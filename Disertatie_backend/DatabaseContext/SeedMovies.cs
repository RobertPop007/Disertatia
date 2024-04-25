using Newtonsoft.Json;
using Disertatie_backend.Entities.Movies;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Disertatie_backend.Configurations;
using Disertatie_backend.Entities.Anime;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Disertatie_backend.Entities.User;
using Disertatie_backend.DTO;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedMovies
    {

        public static async Task SeedAllMovies(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoDbClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.Value.DatabaseName);

            var _moviesCollection = mongoDb.GetCollection<Movie>(databaseSettings.Value.CollectionList["MoviesCollection"]);

            var documents = await _moviesCollection.Find(_ => true).ToListAsync();

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
            //        await SeedTrueMoviesList(context, "https://imdb-api.com/en/API/Title/k_jac24n9w/" + id + "/FullActor,Images,Trailer,Ratings,Wikipedia,");
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

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string returnedUrl = reader.ReadToEnd();
                var movie = JsonConvert.DeserializeObject<Movie>(returnedUrl);

                await _moviesCollection.InsertOneAsync(movie);

            }
        }
    }
}
