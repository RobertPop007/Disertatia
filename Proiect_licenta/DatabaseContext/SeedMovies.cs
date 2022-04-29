using Newtonsoft.Json;
using Proiect_licenta.DTO.Movies;
using Proiect_licenta.Entities.Movies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Proiect_licenta.DatabaseContext
{
    public class SeedMovies
    {

        public static async Task SeedAllMovies(DataContext context)
        {
            if (!context.Top250Movies.Any())
            {
                await SeedMoviesList(context, "https://imdb-api.com/en/API/Top250Movies/k_k49hz8mt");
                await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls020043828");
                await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls060044601");
                await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls053951083");
                await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls002712620");
                await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls036694571");
                await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls020828441");
                await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_k49hz8mt/ls023836170");
                await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls041805722");
                await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls000028602");
                await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls094143100");
                await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls000068347");
                await SeedMoviesList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls006153007");

                
            }

            //var idList = context.Top250Movies.Select(x => x.Id).Skip(3000).Take(318).ToList();

            //foreach (var id in idList)
            //{
            //    await SeedTrueMoviesList(context, "https://imdb-api.com/en/API/Title/k_jac24n9w/" + id + "/FullActor,Images,Trailer,Ratings,Wikipedia,");
            //}

            await context.SaveChangesAsync();
        }

        public static async Task SeedMoviesList(DataContext context, string url)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string returnedUrl = reader.ReadToEnd();
                var movies = JsonConvert.DeserializeObject<MovieGeneralInfo>(returnedUrl);

                foreach (var movie in movies.Items)
                {
                    if (context.Top250Movies.FirstOrDefault(x => x.Id == movie.Id) == null)
                    {
                        await context.Top250Movies.AddAsync(movie);
                    }
                }
            }
        }

        public static async Task SeedTrueMoviesList(DataContext context, string url)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string returnedUrl = reader.ReadToEnd();
                var movie = JsonConvert.DeserializeObject<Movie>(returnedUrl);

                await context.Movies.AddAsync(movie);
                
            }
        }
    }
}
