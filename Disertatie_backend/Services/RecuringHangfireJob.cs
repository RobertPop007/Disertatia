using Disertatie_backend.DatabaseContext;
using Disertatie_backend.DTO;
using Disertatie_backend.EmailTemplates;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Configurations;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Entities.TvShows;
using MongoDB.Driver;
using Disertatie_backend.Entities.Books;
using Microsoft.EntityFrameworkCore;

namespace Disertatie_backend.Services
{
    public class RecuringHangfireJob : IRecuringHangfireJob
    {
        private readonly DataContext _context;
        private readonly IEmailSender _emailSender;

        private readonly UserManager<AppUser> _userManager;
        private readonly DatabaseSettings _databaseMovieSettings;
        private readonly DatabaseSettings _databaseTvShowsSettings;
        private readonly DatabaseSettings _databaseAnimeSettings;
        private readonly DatabaseSettings _databaseMangaSettings;
        private readonly DatabaseSettings _databaseGamesSettings;
        private readonly DatabaseSettings _databaseBooksSettings;

        private readonly IMongoCollection<Movie> _moviesCollection;
        private readonly IMongoDBCollectionHelper<Movie> _moviesCollectionHelper;
        private readonly IMongoCollection<TvShow> _tvShowsCollection;
        private readonly IMongoDBCollectionHelper<TvShow> _tvShowsCollectionHelper;
        private readonly IMongoCollection<Datum> _animeCollection;
        private readonly IMongoDBCollectionHelper<Datum> _animeCollectionHelper;
        private readonly IMongoCollection<DatumManga> _mangaCollection;
        private readonly IMongoDBCollectionHelper<DatumManga> _mangaCollectionHelper;
        private readonly IMongoCollection<Game> _gamesCollection;
        private readonly IMongoDBCollectionHelper<Game> _gamesCollectionHelper;
        private readonly IMongoCollection<Book> _booksCollection;
        private readonly IMongoDBCollectionHelper<Book> _booksCollectionHelper;

        public RecuringHangfireJob(DataContext context, 
            IEmailSender emailSender, 
            UserManager<AppUser> userManager, 
            DatabaseSettings databaseMovieSettings,
            DatabaseSettings databaseTvShowSettings,
            DatabaseSettings databaseAnimeSettings,
            DatabaseSettings databaseMangaSettings,
            DatabaseSettings databaseGamesSettings,
            DatabaseSettings databaseBooksSettings,
            IMongoDBCollectionHelper<Movie> moviesCollectionHelper,
            IMongoDBCollectionHelper<TvShow> tvShowsCollectionHelper,
            IMongoDBCollectionHelper<Datum> animeCollectionHelper,
            IMongoDBCollectionHelper<DatumManga> mangaCollectionHelper,
            IMongoDBCollectionHelper<Book> booksCollectionHelper,
            IMongoDBCollectionHelper<Game> gamesCollectionHelper)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;

            _databaseMovieSettings = databaseMovieSettings;
            _databaseTvShowsSettings = databaseTvShowSettings;
            _databaseAnimeSettings = databaseAnimeSettings;
            _databaseMangaSettings = databaseMangaSettings;
            _databaseGamesSettings = databaseGamesSettings;
            _databaseBooksSettings = databaseBooksSettings;

            _moviesCollectionHelper = moviesCollectionHelper;
            _tvShowsCollectionHelper = tvShowsCollectionHelper;
            _animeCollectionHelper = animeCollectionHelper;
            _mangaCollectionHelper = mangaCollectionHelper;
            _booksCollectionHelper = booksCollectionHelper;
            _gamesCollectionHelper = gamesCollectionHelper;

            _moviesCollection = _moviesCollectionHelper.CreateCollection(databaseMovieSettings);
            _tvShowsCollection = _tvShowsCollectionHelper.CreateCollection(databaseTvShowSettings);
            _animeCollection = _animeCollectionHelper.CreateCollection(databaseAnimeSettings);
            _mangaCollection = _mangaCollectionHelper.CreateCollection(databaseMangaSettings);
            _gamesCollection = _gamesCollectionHelper.CreateCollection(databaseGamesSettings);
            _booksCollection = _booksCollectionHelper.CreateCollection(databaseBooksSettings);
        }
        public async Task SendRecomandationsEmails()
        {
            var userList = _userManager.Users
                .Include(u => u.AppUserMovie)
                .Include(u => u.AppUserTvShow)
                .Include(u => u.AppUserAnime)
                .Include(u => u.AppUserManga)
                .Include(u => u.AppUserBook)
                .Include(u => u.AppUserGame)
                .ToList();
            foreach(var user in userList)
            {
                if(user.IsSubscribedToNewsletter == true)
                {
                    var mail_content = RecommandationEmailTemplate.GetEmailTemplate(user,
                        _moviesCollection,
                        _tvShowsCollection,
                        _animeCollection,
                        _mangaCollection,
                        _booksCollection,
                        _gamesCollection);

                    var message = new EmailMessage(new string[] { user.Email }, "Daily recommandations", mail_content);
                    await _emailSender.SendHtmlEmailAsync(message, user.UserName);
                }
            }
        }
    }
}
