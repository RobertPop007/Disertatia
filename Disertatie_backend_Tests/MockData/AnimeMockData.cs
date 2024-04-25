using Disertatie_backend.DTO;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend_Tests.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disertatie_backend_Tests.MockData
{
    public static class AnimeMockData
    {
        public static AnimeModel ValidAnime()
        {
            return new AnimeModel
            {
                Id = new MongoDB.Bson.ObjectId("6611a0727b2649a4fd4e6ec0"),
                Mal_id = 52991,
                Url = "https://myanimelist.net/anime/52991/Sousou_no_Frieren",
                Title = "Sousou no Frieren",
                Title_english = "Frieren: Beyond Journey's End",
                Title_japanese = "葬送のフリーレン",
                Reviews = new List<ReviewDto>()
            };
        }

        public static AnimeModel AnotherValidAnime()
        {
            return new AnimeModel
            {
                Id = new MongoDB.Bson.ObjectId("6611a0727b2649a4fd4e6ec1"),
                Mal_id = 5114,
                Url = "https://myanimelist.net/anime/5114/Fullmetal_Alchemist__Brotherhood",
                Title = "Fullmetal Alchemist: Brotherhood",
                Title_english = "Fullmetal Alchemist: Brotherhood",
                Title_japanese = "鋼の錬金術師 FULLMETAL ALCHEMIST"
            };
        }
    }
}
