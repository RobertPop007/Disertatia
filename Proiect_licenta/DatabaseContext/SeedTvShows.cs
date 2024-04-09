using Newtonsoft.Json;
using Disertatie_backend.Entities.TvShows;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;
using Disertatie_backend.Entities.Anime;
using MongoDB.Driver;
using Disertatie_backend.Entities.Movies;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedTvShows
    {
        public static async Task SeedAllTvShows(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoDbClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.Value.DatabaseName);

            var _tvShowsCollection = mongoDb.GetCollection<Datum>(databaseSettings.Value.CollectionList["TVShowsCollection"]);

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

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string returnedUrl = reader.ReadToEnd();
                var tvShow = JsonConvert.DeserializeObject<TvShow>(returnedUrl);

                await _tvShowsCollection.InsertOneAsync(tvShow);

            }
        }
    }
}
