using AutoMapper;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.DTO;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Interfaces;
using Disertatie_backend.Repositories;
using Disertatie_backend_Tests.DTOs;
using Disertatie_backend_Tests.MockData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Moq;

namespace Disertatie_backend_Tests.Repositories_Tests
{
    public class ReviewRepositoy_Tests
    {
        private readonly ReviewRepository<Datum> _reviewRepository;
        private readonly Mock<IAnimeRepository> _mockAnimeRepository;
        private readonly Mock<IMangaRepository> _mockMangaRepository;
        private readonly Mock<IGamesRepository> _mockGamesRepository;
        private readonly Mock<IMoviesRepository> _mockMoviesRepository;
        private readonly Mock<ITvShowsRepository> _mockTvShowsRepository;
        private readonly Mock<IBooksRepository> _mockBooksRepository;
        private readonly Mock<DataContext> _mockContext;
        private readonly IMapper _mapper;
        private readonly AppUser user = UserMockData.ValidUser();
        private readonly AnimeModel anime = AnimeMockData.ValidAnime();

        public ReviewRepositoy_Tests()
        {
            var mockUsersSet = new Mock<DbSet<AppUser>>();
            var users = new List<AppUser> { user }.AsQueryable();
            mockUsersSet.As<IQueryable<AppUser>>().Setup(m => m.Provider).Returns(users.Provider);
            mockUsersSet.As<IQueryable<AppUser>>().Setup(m => m.Expression).Returns(users.Expression);
            mockUsersSet.As<IQueryable<AppUser>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockUsersSet.As<IQueryable<AppUser>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            var mockReviewsSet = new Mock<DbSet<Review>>();
            var reviews = new List<Review> { ReviewMockData.ValidReview(user, anime) }.AsQueryable();
            mockReviewsSet.As<IQueryable<Review>>().Setup(m => m.Provider).Returns(reviews.Provider);
            mockReviewsSet.As<IQueryable<Review>>().Setup(m => m.Expression).Returns(reviews.Expression);
            mockReviewsSet.As<IQueryable<Review>>().Setup(m => m.ElementType).Returns(reviews.ElementType);
            mockReviewsSet.As<IQueryable<Review>>().Setup(m => m.GetEnumerator()).Returns(reviews.GetEnumerator());

            _mockContext = new Mock<DataContext>();
            _mockContext.Setup(c => c.Users).Returns(mockUsersSet.Object);
            _mockContext.Setup(c => c.Reviews).Returns(mockReviewsSet.Object);

            _mockAnimeRepository = new Mock<IAnimeRepository>();
            _mockMangaRepository = new Mock<IMangaRepository>();
            _mockMoviesRepository = new Mock<IMoviesRepository>();
            _mockTvShowsRepository = new Mock<ITvShowsRepository>();
            _mockGamesRepository = new Mock<IGamesRepository>();
            _mockBooksRepository = new Mock<IBooksRepository>();

            _reviewRepository = new ReviewRepository<Datum>(_mockContext.Object,
                                                            _mockAnimeRepository.Object,
                                                            _mockMangaRepository.Object,
                                                            _mockMoviesRepository.Object,
                                                            _mockTvShowsRepository.Object,
                                                            _mockGamesRepository.Object,
                                                            _mockBooksRepository.Object);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Review, ReviewDto>()
                        .ForMember(dest => dest.Username, opt => opt.MapFrom(src => 
                        src.User.UserName))
                        .ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task AddReviewToAnime_PositiveResult()
        {
            var review = ReviewMockData.ValidReview(user, anime);
            var reviewDto = _mapper.Map<ReviewDto>(review);

            await _reviewRepository.AddReviewToItem<Datum>(user.Id, anime.Id, reviewDto);

            var mappedReviewsFromUser = _mockContext.Object.Reviews.Where(x => x.ItemId == anime.Id.ToString()).Select(u => _mapper.Map<ReviewDto>(u));

            mappedReviewsFromUser.Should().ContainEquivalentOf(reviewDto);
        }

        [Fact]
        public async Task DeleteReviewToAnime_PositiveResult()
        {
            var review = ReviewMockData.ValidReview(user, anime);
            var reviewDto = _mapper.Map<ReviewDto>(review);

            await _reviewRepository.AddReviewToItem<Datum>(user.Id, anime.Id, reviewDto);

            var mappedReviewsFromUser = _mockContext.Object.Reviews.Where(x => x.ItemId == anime.Id.ToString()).Select(u => _mapper.Map<ReviewDto>(u));

            mappedReviewsFromUser.Should().ContainEquivalentOf(reviewDto);

            var newCreatedReview = user.Reviews.FirstOrDefault(x =>
                    x.MainDescription == reviewDto.MainDescription &&
                    x.ShortDescription == reviewDto.ShortDescription &&
                    x.Stars == reviewDto.Stars &&
                    x.User.UserName == reviewDto.Username
                    );

            if( newCreatedReview != null )
            {
                await _reviewRepository.DeleteReviewFromItem<Datum>(user.Id, anime.Id, newCreatedReview.ReviewId);

                var mappedReviewsFromUserAfterDelete = _mockContext.Object.Reviews.Where(x => x.ItemId == anime.Id.ToString()).Select(u => _mapper.Map<ReviewDto>(u));

                mappedReviewsFromUserAfterDelete.Should().NotContainEquivalentOf(review);
            }
        }

        [Fact]
        public async Task GetReviewsForAnime_PositiveResult()
        {
            var reviewToAdd = ReviewMockData.ValidReview(user, anime);
            var reviewDto = _mapper.Map<ReviewDto>(reviewToAdd);

            await _reviewRepository.AddReviewToItem<Datum>(user.Id, anime.Id, reviewDto);

            var mappedReviewsFromAnimeAfterAdd = _mockContext.Object.Reviews.Where(x => x.ItemId == anime.Id.ToString()).Select(u => _mapper.Map<ReviewDto>(u));

            mappedReviewsFromAnimeAfterAdd.Should().ContainEquivalentOf(reviewDto);
        }

        [Fact]
        public async Task GetReviewsFromUser_PositiveResult()
        {
            var reviewToAdd = ReviewMockData.ValidReview(user, anime);
            var reviewDto = _mapper.Map<ReviewDto>(reviewToAdd);

            await _reviewRepository.AddReviewToItem<Datum>(user.Id, anime.Id, reviewDto);

            var reviewsFromUser = await _reviewRepository.GetReviewsForUserAsync(user.Id);

            var mappedReviewsFromUser = reviewsFromUser.Select(u => _mapper.Map<ReviewDto>(u));

            mappedReviewsFromUser.Should().ContainEquivalentOf(reviewDto);
        }
    }
}
