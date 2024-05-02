using Disertatie_backend.Configurations;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Books;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.User;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Disertatie_backend.DatabaseContext
{
    public class SeedBooks
    {
        public static async Task SeedAllBooks(DatabaseSettings databaseSettings)
        {
            var mongoDbClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.DatabaseName);

            var _booksCollection = mongoDb.GetCollection<Book>(databaseSettings.CollectionList["BooksCollection"]);

            //var defaultReviews = new List<Review>();
            //var update = Builders<Book>.Update.Set(x => x.ReviewsIds, new HashSet<Guid>());
            //_booksCollection.UpdateMany(FilterDefinition<Book>.Empty, update);

            //var filter = Builders<Book>.Filter.Empty; // Match all documents
            //var options = new FindOptions<Book> { Sort = Builders<Book>.Sort.Descending("_id") };
            //var cursor = await _booksCollection.FindAsync(filter, options);
            //await cursor.ForEachAsync(async doc =>
            //{
            //    // Delete each document
            //    //await SeedCoverByISBN(doc, _booksCollection);
            //    //await _booksCollection.DeleteOneAsync(Builders<Game>.Filter.Eq("Rating", doc.Rating));
            //});

            //await SeedCoverByISBN(_booksCollection);

            //using (StreamReader r = new StreamReader(@"C:\books.txt"))
            //{
            //    var json = r.ReadToEnd();
            //    var listOfBooks = JsonConvert.DeserializeObject<List<Book>>(json);

            //    //foreach(var book in listOfBooks)
            //    //{
            //    //    var url = $"https://openlibrary.org/api/books?bibkeys=ISBN:{book.Isbn}&format=json";

            //    //    using (HttpClient client = new HttpClient())
            //    //    {
            //    //        HttpResponseMessage response = await client.GetAsync(url);

            //    //        if (response.IsSuccessStatusCode)
            //    //        {
            //    //            // Read the response content
            //    //            string responseBody = await response.Content.ReadAsStringAsync();
            //    //            var bookExtracted = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(returnedUrl);
            //    //            var bookModel = bookExtracted[$"ISBN:{book.Isbn}"];
            //    //            var thumbnail = bookModel["thumbnail_url"];

            //    //            book.CoverUrl = thumbnail;
            //    //        }
            //    //    }
            //    //}

            //    await _booksCollection.InsertManyAsync(listOfBooks);
            //}

            await SeedCoverByISBN(_booksCollection);
        }

        public static async Task SeedCoverByISBN(IMongoCollection<Book> _booksCollection)
        {
            var filter = Builders<Book>.Filter.Empty; // Match all documents
            //var options = new FindOptions<Book> { Sort = Builders<Book>.Sort.Descending("_id") };
            var cursor = _booksCollection.Find(filter);
            await cursor.ForEachAsync(async doc =>
            {
                //Thread.Sleep(1000);
                var url = $"https://openlibrary.org/api/books?bibkeys=ISBN:{doc.Isbn}&format=json";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string returnedUrl = reader.ReadToEnd();
                    var bookExtracted = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(returnedUrl);
                    var bookModel = bookExtracted[$"ISBN:{doc.Isbn}"];
                    var thumbnail = bookModel["thumbnail_url"];

                    var coverUpdate = Builders<Book>.Update.Set(x => x.CoverUrl, thumbnail);
                    await _booksCollection.UpdateOneAsync(Builders<Book>.Filter.Eq(x => x.Isbn, doc.Isbn), coverUpdate);
                }
            });
        }
    }
}
