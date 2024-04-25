using Disertatie_backend.DatabaseContext;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Interfaces;
using Disertatie_backend.Repositories;
using Disertatie_backend_Tests.MockData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disertatie_backend_Tests.Repositories_Tests
{
    public class UserItemsRepository_Tests
    {
        private readonly UserItemsRepository<Datum> _userItemsRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IAnimeRepository> _mockAnimeRepository;
        private readonly Mock<IMangaRepository> _mockMangaRepository;
        private readonly Mock<IGamesRepository> _mockGamesRepository;
        private readonly Mock<IMoviesRepository> _mockMoviesRepository;
        private readonly Mock<ITvShowsRepository> _mockTvShowsRepository;
        private readonly Mock<DataContext> _mockContext;

        private readonly AppUser user = UserMockData.ValidUser();

        public UserItemsRepository_Tests()
        {
            var appUserAnimeItem = AppUserAnimeItemMockData.UserAnime(user);

            var mockUsersSet = new Mock<DbSet<AppUser>>();
            var users = new List<AppUser> { user }.AsQueryable();
            mockUsersSet.As<IQueryable<AppUser>>().Setup(m => m.Provider).Returns(users.Provider);
            mockUsersSet.As<IQueryable<AppUser>>().Setup(m => m.Expression).Returns(users.Expression);
            mockUsersSet.As<IQueryable<AppUser>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockUsersSet.As<IQueryable<AppUser>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            var mockAppUserAnimeItemSet = new Mock<DbSet<AppUserAnimeItem>>();
            var appUserAnimeItems = new List<AppUserAnimeItem> {  }.AsQueryable();
            mockAppUserAnimeItemSet.As<IQueryable<AppUserAnimeItem>>().Setup(m => m.Provider).Returns(appUserAnimeItems.Provider);
            mockAppUserAnimeItemSet.As<IQueryable<AppUserAnimeItem>>().Setup(m => m.Expression).Returns(appUserAnimeItems.Expression);
            mockAppUserAnimeItemSet.As<IQueryable<AppUserAnimeItem>>().Setup(m => m.ElementType).Returns(appUserAnimeItems.ElementType);
            mockAppUserAnimeItemSet.As<IQueryable<AppUserAnimeItem>>().Setup(m => m.GetEnumerator()).Returns(appUserAnimeItems.GetEnumerator());

            _mockContext = new Mock<DataContext>();
            _mockContext.Setup(c => c.Users).Returns(mockUsersSet.Object);
            _mockContext.Setup(c => c.UserAnimes).Returns(mockAppUserAnimeItemSet.Object);

            _mockUserRepository = new Mock<IUserRepository>();
            _mockAnimeRepository = new Mock<IAnimeRepository>();
            _mockMangaRepository = new Mock<IMangaRepository>();
            _mockMoviesRepository = new Mock<IMoviesRepository>();
            _mockTvShowsRepository = new Mock<ITvShowsRepository>();
            _mockGamesRepository = new Mock<IGamesRepository>();
            
            _userItemsRepository = new UserItemsRepository<Datum>(_mockContext.Object,
                                                            _mockUserRepository.Object,     
                                                            _mockAnimeRepository.Object,
                                                            _mockMangaRepository.Object,
                                                            _mockMoviesRepository.Object,
                                                            _mockTvShowsRepository.Object,
                                                            _mockGamesRepository.Object);
        }

        [Fact]
        public async Task AddItemToUser_PositiveResult()
        {
            var anime = AnimeMockData.ValidAnime();

            await _userItemsRepository.AddItemToUser<Datum>(user, anime.Id);

            user.AppUserAnime?.Select(x => x.AnimeId).Should().ContainEquivalentOf(anime.Id.ToString());
        }

        [Fact]
        public async Task DeleteItemFromUser_PositiveResult()
        {
            var anime = AnimeMockData.ValidAnime();
            
            await _userItemsRepository.AddItemToUser<Datum>(user, anime.Id);

            //_mockContext.Object.UserAnimes.Should().ContainEquivalentOf(appUserAnimeItem);
            //user.AppUserAnime?.Select(x => x.AnimeId).Should().ContainEquivalentOf(anime.Id.ToString());

            await _userItemsRepository.DeleteItemFromUser<Datum>(user, anime.Id);

            user.AppUserAnime?.Select(x => x.AnimeId).Should().NotContainEquivalentOf(anime.Id.ToString());
        }
    }
}
