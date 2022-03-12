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
                var urlMovies = "https://imdb-api.com/en/API/Top250Movies/k_k49hz8mt";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlMovies);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string returnedUrl = reader.ReadToEnd();
                    var movies = JsonConvert.DeserializeObject<MovieGeneralInfo>(returnedUrl);

                    foreach (var movie in movies.Items)
                    {
                        await context.Top250Movies.AddAsync(movie);
                    }

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
