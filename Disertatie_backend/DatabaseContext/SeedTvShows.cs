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
            for (var i = 251; i <= 500; i++)
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

            //var documents = await _tvShowsCollection.Find(_ => true).ToListAsync();

            //var defaultReviews = new List<ReviewDto>();
            //var update = Builders<TvShow>.Update.Set(x => x.Reviews, defaultReviews);
            //_tvShowsCollection.UpdateMany(FilterDefinition<TvShow>.Empty, update);

            //if (!context.TvShows.Any())
            //{
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/top250tvs/k_nmakg2ch");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/imdblist/k_nmakg2ch/ls066189319");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/mostpopulartvs/k_nmakg2ch");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/imdblist/k_nmakg2ch/ls094943590");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/imdblist/k_nmakg2ch/ls045252633");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/imdblist/k_nmakg2ch/ls022397090");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/imdblist/k_nmakg2ch/ls026477582");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/imdblist/k_nmakg2ch/ls033953812");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/imdblist/k_nmakg2ch/ls023589152");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/imdblist/k_nmakg2ch/ls063527487");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/imdblist/k_nmakg2ch/ls036998982");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/imdblist/k_nmakg2ch/ls079394864");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/imdblist/k_nmakg2ch/ls093287916");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/api/imdblist/k_nmakg2ch/ls093287496"); //take(500)
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls095473628");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls500220439");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls046013528");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls065015622");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls065925054");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls065505948");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls065577238");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls065095546");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls067532771");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls067565700");
            //    await SeedTvShowsList(context, "https://imdb-api.com/en/API/IMDbList/k_jac24n9w/ls067561033");
            //}


            //if (!context.TrueTvShow.Any())
            //{
            //    var idList = context.TvShows.Select(x => x.Id).Skip(0).Take(2853).ToList();

            //    foreach (var id in idList)
            //    {
            //        await SeedTrueTvShowList(context, "https://imdb-api.com/en/API/Title/k_jac24n9w/" + id + "/FullActor,Images,Trailer,Ratings,Wikipedia,");
            //    }
            //}


            //await context.SaveChangesAsync();
        }

        public static async Task SeedTvShowsList(IMongoCollection<TvShow> _tvShowsCollection, string url)
        {

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //using (Stream stream = response.GetResponseStream())
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    string returnedUrl = reader.ReadToEnd();
            //    var tvShows = JsonConvert.DeserializeObject<TvShowGeneralInfo>(returnedUrl);

            //    foreach (var tvShow in tvShows.Items.Take(500))
            //    {
            //        await _tvShowsCollection.InsertOneAsync(tvShow);
            //    }
            //}
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

                        tvShow.Videos.Results = tvShow.Videos.Results.Take(5).ToList();
                        tvShow.Similar.Results = tvShow.Similar.Results.Take(10).ToList();
                        tvShow.Images.Backdrops = tvShow.Images.Backdrops.Take(10).ToList();
                        tvShow.Images.Logos = tvShow.Images.Logos.Take(10).ToList();
                        tvShow.Images.Posters = tvShow.Images.Posters.Take(10).ToList();
                        tvShow.Credits.Cast = tvShow.Credits.Cast.Take(15).ToList();
                        tvShow.Credits.Crew = tvShow.Credits.Crew.Take(10).ToList();

                        await _tvShowsCollection.InsertOneAsync(tvShow);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
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
