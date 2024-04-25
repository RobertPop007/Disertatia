using AutoMapper;
using Disertatie_backend.Configurations;
using Disertatie_backend.DTO.Anime;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using Disertatie_backend.Repositories;
using Disertatie_backend_Tests.DTOs;
using Disertatie_backend_Tests.MockData;
using FluentAssertions;

namespace Disertatie_backend_Tests.Repositories_Tests
{
    public class AnimeRepository_Tests
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly IMapper _mapper;
        private readonly IMongoDBCollectionHelper<Datum> _mongoDBCollectionHelper;
        private readonly DatabaseSettings _databaseSettings;
        private readonly AnimeModel anime = AnimeMockData.ValidAnime();

        public AnimeRepository_Tests()
        {
            _databaseSettings = new DatabaseSettings()
            {
                CollectionList = new Dictionary<string, string>()
                {
                    { "AnimeCollection", "Anime" }
                },
                ConnectionString = "mongodb+srv://robertpop:Sig1ZVM3AurL5C8q@mongodb-test.1tntwww.mongodb.net/",
                DatabaseName = "Database_disertație"
            };

            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Datum, AnimeModel>().ReverseMap();
                cfg.CreateMap<Datum, AnimeCard>().ReverseMap();
                cfg.CreateMap<AnimeCard, AnimeModel>().ReverseMap();
            });
            _mapper = config.CreateMapper();
            _mongoDBCollectionHelper = new MongoDBCollectionHelper<Datum>();
            _animeRepository = new AnimeRepository(_mapper, _mongoDBCollectionHelper, _databaseSettings);
        }

        [Fact]
        public async Task GetAnimeByIDAsync_PositiveResult()
        {
            var actualAnime = await _animeRepository.GetAnimeByIdAsync(anime.Id);
            actualAnime.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAnimeByTitleAsync_PositiveResult()
        {
            var actualAnime = await _animeRepository.GetAnimeByFullTitleAsync(anime.Title);
            actualAnime.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAnimesAsync_PositiveResult()
        {
            var mappedAnimes = new List<AnimeModel>();
            var animeParams = new AnimeParams()
            {
                OrderBy = "Score",
                PageNumber = 1,
                PageSize = 2,
                SearchedAnime = ""
            };
            var animesPagedList = await _animeRepository.GetAnimesAsync(animeParams);
            var animes = animesPagedList.ToList();
            animes.ForEach(x => mappedAnimes.Add(_mapper.Map<AnimeModel>(x)));

            var mockedAnimes = new List<AnimeModel>()
            {
                AnimeMockData.ValidAnime(),
                AnimeMockData.AnotherValidAnime()
            };

            mappedAnimes.Select(x => x.Title)
                .Should()
                .BeEquivalentTo(mockedAnimes.Select(x => x.Title));
        }
    }
}