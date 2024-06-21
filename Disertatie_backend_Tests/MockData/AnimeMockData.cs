using Disertatie_backend.DTO;
using Disertatie_backend_Tests.DTOs;

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

        public static AnimeModel FirstAnime()
        {
            return new AnimeModel
            {
                Id = new MongoDB.Bson.ObjectId("6611a0767b2649a4fd4e6f2d"),
                Mal_id = 16498,
                Url = "https://myanimelist.net/anime/16498/Shingeki_no_Kyojin",
                Title = "Shingeki no Kyojin",
                Title_english = "Attack on Titan",
                Title_japanese = "進撃の巨人",
                Reviews = new List<ReviewDto>()
            };
        }

        public static AnimeModel SecondAnime()
        {
            return new AnimeModel
            {
                Id = new MongoDB.Bson.ObjectId("6611a0757b2649a4fd4e6f11"),
                Mal_id = 1535,
                Url = "https://myanimelist.net/anime/1535/Death_Note",
                Title = "Death Note",
                Title_english = "Death Note",
                Title_japanese = "デスノート",
                Reviews = new List<ReviewDto>()
            };
        }
    }
}
