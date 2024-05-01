using Disertatie_backend.Configurations;
using Disertatie_backend.Entities.Books;
using Disertatie_backend.Entities.Games.Game;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedBooks
    {
        public static async Task SeedAllBooks(DatabaseSettings databaseSettings)
        {
            var mongoDbClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.DatabaseName);

            var _booksCollection = mongoDb.GetCollection<Book>(databaseSettings.CollectionList["BooksCollection"]);
        
            using(StreamReader r = new StreamReader(@"C:\books.txt"))
            {
                var json = r.ReadToEnd();
                var listOfBooks = JsonConvert.DeserializeObject<List<Book>>(json);

                await _booksCollection.InsertManyAsync(listOfBooks);
            }
        }
    }
}
