using System.Collections.Generic;

namespace Disertatie_backend.Entities.Books
{
    public class BookByISBN
    {
        public Dictionary<string, BookThumbnail> Books { get; set; }
    }
}
