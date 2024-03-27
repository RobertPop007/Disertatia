using Newtonsoft.Json;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.Games.GamesIds;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedGames
    {
        public static async Task SeedAllGamesIds(DataContext context)
        {
            //if (!context.GamesIds.Any())
            //{
            //    await SeedGameId(context, "https://api.rawg.io/api/games?key=ec9156999ce5466ebc0fe23b17bcf556");

            //    for (var i = 2; i <= 160; i++)
            //    {
            //        await SeedGameId(context, $@"https://api.rawg.io/api/games?key=ec9156999ce5466ebc0fe23b17bcf556&page={i}");
            //    }
            //}

            //if (!context.Games.Any())
            //{
            //    foreach (var gameId in context.GamesIds.Skip(0).Take(3200))
            //    {
            //        await SeedGame(context, $@"https://api.rawg.io/api/games/{gameId.Id}?key=ec9156999ce5466ebc0fe23b17bcf556");
            //    }
            //}

            await context.SaveChangesAsync();
        }

        public static async Task SeedGameId(DataContext context, string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string returnedUrl = reader.ReadToEnd();
                var ids = JsonConvert.DeserializeObject<Root>(returnedUrl);

                foreach (var id in ids.Results)
                {
                    await context.GamesIds.AddAsync(id);
                }
            }
        }

        public static async Task SeedGame(DataContext context, string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string returnedUrl = reader.ReadToEnd();
                var game = JsonConvert.DeserializeObject<Game>(returnedUrl);

                await context.Games.AddAsync(game);
            }
        }
    }
}
