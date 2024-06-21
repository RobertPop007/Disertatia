using Disertatie_backend.Configurations;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Books;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Disertatie_backend.EmailTemplates
{
    public class RecommandationEmailTemplate
    {
        public static string GetConfirmationEmailTemplate(Guid userId, string token)
        {
            var sb = new StringBuilder();
            string confirmationLink = $"https://localhost:4200/confirmEmail?userId={userId}&token={token}";
            var body = $@"
                    <html>
                    <body>
                        <p>Your account has been created! Welcome to our community!</p>
                        <p>Use this link to activate your email: <a href=""{confirmationLink}"">Confirm email</a></p>
                    </body>
                    </html>";

            sb.Append(body);
            

            return sb.ToString();
        }

        public static string GetConfirmationEmailWithFacebookTemplate(Guid userId, string username, string password, string token)
        {
            var sb = new StringBuilder();
            string confirmationLink = $"https://localhost:4200/confirmEmail?userId={userId}&token={token}";
            var body = $@"
                    <html>
                    <body>
                        <p>Your account has been created! Welcome to our community! Please note that your username is: {username} and your password is: {password}</p>
                        <p>You are advised to change your password after you login into your account! Use this link to activate your email: <a href=""{confirmationLink}"">Confirm email</a></p>
                    </body>
                    </html>";

            sb.Append(body);


            return sb.ToString();
        }

        public static string GetChangePasswordEmailTemplate(string email, string token)
        {
            var sb = new StringBuilder();
            string changePasswordLink = $"https://localhost:4200/changePassword?email={email}&token={token}";
            var body = $@"
                    <html>
                    <body>
                        <p>You requested a password change.</p>
                        <p>Use this link to change your password: <a href=""{changePasswordLink}"">Change password</a></p>
                    </body>
                    </html>";

            sb.Append(body);


            return sb.ToString();
        }

        public static string GetEmailTemplate(AppUser user, 
            IMongoCollection<Movie> movieCollection,
            IMongoCollection<TvShow> tvShowCollection,
            IMongoCollection<Datum> animeCollection,
            IMongoCollection<DatumManga> mangaCollection,
            IMongoCollection<Book> booksCollection,
            IMongoCollection<Game> gamesCollection)
        {
            var sb = new StringBuilder();
            
            var random = new Random();

            sb.AppendFormat(@"
                        <html>
                            <head>
                            </head>
                            <body>
                            <p>
                            Dear  {0}
                            </p>
                            <p>
                            Thank you for subscribing to our newsletter!<br>
                            </p>
 
                            <p>
                            Through this newsletter, you will receive daily recommendations based on what you have watched so far. We look forward to seeing you online in our community.<br>
                            </p>

                            <p>If you notice anything wrong, please contact us by email or phone, which you can find on the contact page.</p>"
                            , user.UserName);


            var moviePart = GetMoviePartTemplate(user, movieCollection, random);
            if (moviePart != String.Empty) sb.AppendFormat(moviePart);

            var tvShowPart = GetTvShowPartTemplate(user, tvShowCollection, random);
            if (tvShowPart != String.Empty) sb.AppendFormat(tvShowPart);

            var animePart = GetAnimePartTemplate(user, animeCollection, random);
            if (animePart != String.Empty) sb.AppendFormat(animePart);

            var mangaPart = GetMangaPartTemplate(user, mangaCollection, random);
            if (mangaPart != String.Empty) sb.AppendFormat(mangaPart);

            var gamePart = GetGamePartTemplate(user, gamesCollection, random);
            if (gamePart != String.Empty) sb.AppendFormat(gamePart);

            var bookPart = GetBookPartTemplate(user, booksCollection, random);
            if (bookPart != String.Empty) sb.AppendFormat(bookPart);

            sb.AppendFormat(@"</body>
                        </html>");

            return sb.ToString();
        }

        public static string GetMoviePartTemplate(AppUser user, IMongoCollection<Movie> collection, Random random)
        {
            var movieTable = new StringBuilder();
            var randomMovie = new Movie();

            if (user.AppUserMovie.Count > 0)
            {
                var countMovies = 0;
                var moviesIdList = user.AppUserMovie;

                var index = random.Next(moviesIdList.Count);

                randomMovie = collection.Find(u => u.Id.ToString() == moviesIdList.ElementAt(index).MovieId).FirstOrDefault();
                countMovies++;

                while (randomMovie.Similar == null)
                {
                    index = random.Next(moviesIdList.Count);
                    randomMovie = collection.Find(u => u.Id.ToString() == moviesIdList.ElementAt(index).MovieId).FirstOrDefault();

                    countMovies++;

                    if (countMovies == moviesIdList.Count)
                        break;
                }

                var randomSimilarMovie = new Movie();
                string movieTitle;
                index = random.Next(randomMovie.Similar.Results.Count - 1);

                movieTitle = randomMovie.Similar.Results[index].Title;
                randomSimilarMovie = collection.Find(o => o.Title == movieTitle).FirstOrDefault();

                while(randomSimilarMovie == null)
                {
                    index = random.Next(randomMovie.Similar.Results.Count - 1);

                    movieTitle = randomMovie.Similar.Results[index].Title;
                    randomSimilarMovie = collection.Find(o => o.Title == movieTitle).FirstOrDefault();
                }

                movieTable.AppendFormat(@"<table style='width: 100%; border: 1px solid #ddd; border-collapse: collapse; font-family: Arial, sans-serif;'>
                        <thead>
                            <tr style='background-color: #f4f4f4;'>
                                <th colspan='2' style='border: 1px solid #ddd; padding: 10px; text-align: left;'>Because you liked {0}, you might also like</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style='border: 1px solid #ddd; padding: 10px; width: 70%; vertical-align: top;'>
                                    <h2 style='margin: 0; color: #333;'>{2}</h2>
                                    <p style='margin: 10px 0; color: #666;'>{3}</p>
                                    <p style='margin: 10px 0; color: #666;'>{5}</p>
                                </td>
                                <td style='border: 1px solid #ddd; padding: 10px; width: 30%; text-align: center;'>
                                    <a href='{4}' style='text-decoration: none;'>
                                        <img width='200' height='200' style='cursor: pointer; border: 0;' src='https://image.tmdb.org/t/p/w500/{1}' alt='{2}'>
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table><br><br>",
                    randomMovie.Title,
                    randomSimilarMovie.BackdropPath,
                    randomSimilarMovie.Title,
                    randomSimilarMovie.Tagline,
                    $"https://localhost:4200/movies/{randomSimilarMovie.Title}",
                    randomSimilarMovie.Overview);

                return movieTable.ToString();
            }
            else
                return String.Empty;
        }

        public static string GetTvShowPartTemplate(AppUser user, IMongoCollection<TvShow> collection, Random random)
        {
            var tvShowTable = new StringBuilder();
            var randomTvShow = new TvShow();

            if (user.AppUserTvShow.Count > 0)
            {
                var countTvShows = 0;
                var tvShowsIdList = user.AppUserTvShow;

                var index = random.Next(tvShowsIdList.Count);
                randomTvShow = collection.Find(u => u.Id.ToString() == tvShowsIdList.ElementAt(index).TvShowId).FirstOrDefault();

                countTvShows++;

                while (randomTvShow.Similar == null)
                {
                    index = random.Next(tvShowsIdList.Count);
                    randomTvShow = collection.Find(u => u.Id.ToString() == tvShowsIdList.ElementAt(index).TvShowId).FirstOrDefault();

                    countTvShows++;

                    if (countTvShows == tvShowsIdList.Count)
                        break;
                }


                var randomSimilarTvShow = new TvShow();
                string tvShowTitle;

                index = random.Next(randomTvShow.Similar.Results.Count - 1);

                tvShowTitle = randomTvShow.Similar.Results[index].Name;
                randomSimilarTvShow = collection.Find(o => o.Name == tvShowTitle).FirstOrDefault();

                while (randomSimilarTvShow == null)
                {
                    index = random.Next(randomTvShow.Similar.Results.Count - 1);

                    tvShowTitle = randomTvShow.Similar.Results[index].Name;
                    randomSimilarTvShow = collection.Find(o => o.Name == tvShowTitle).FirstOrDefault();
                }

                tvShowTable.AppendFormat(@"<table style='width: 100%; border: 1px solid #ddd; border-collapse: collapse; font-family: Arial, sans-serif;'>
                        <thead>
                            <tr style='background-color: #f4f4f4;'>
                                <th colspan='2' style='border: 1px solid #ddd; padding: 10px; text-align: left;'>Because you liked {0}, you might also like</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style='border: 1px solid #ddd; padding: 10px; width: 70%; vertical-align: top;'>
                                    <h2 style='margin: 0; color: #333;'>{2}</h2>
                                    <p style='margin: 10px 0; color: #666;'>{3}</p>
                                    <p style='margin: 10px 0; color: #666;'>{5}</p>
                                </td>
                                <td style='border: 1px solid #ddd; padding: 10px; width: 30%; text-align: center;'>
                                    <a href='{4}' style='text-decoration: none;'>
                                        <img width='200' height='200' style='cursor: pointer; border: 0;' src='https://image.tmdb.org/t/p/w500/{1}' alt='{2}'>
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table><br><br>",
                    randomTvShow.Name,
                    randomSimilarTvShow.BackdropPath,
                    randomSimilarTvShow.Name,
                    randomSimilarTvShow.Tagline,
                    $"https://localhost:4200/tvShows/{randomSimilarTvShow.Name}",
                    randomSimilarTvShow.Overview);

                return tvShowTable.ToString();
            }
            else
                return String.Empty;
        }

        public static string GetAnimePartTemplate(AppUser user, IMongoCollection<Datum> collection, Random random)
        {
            var animeTable = new StringBuilder();
            var randomAnime = new Datum();
            var randomRecommendedAnimes = new List<Datum>();

            if (user.AppUserAnime.Count > 0)
            {
                var countAnimes = 0;
                var animesIdList = user.AppUserAnime;

                var index = random.Next(animesIdList.Count);
                randomAnime = collection.Find(u => u.Id.ToString() == animesIdList.ElementAt(index).AnimeId).FirstOrDefault();

                countAnimes++;

                while (randomAnime.Status == null)
                {
                    index = random.Next(animesIdList.Count);
                    randomAnime = collection.Find(u => u.Id.ToString() == animesIdList.ElementAt(index).AnimeId).FirstOrDefault();

                    countAnimes++;

                    if (countAnimes == animesIdList.Count)
                        break;
                }

                index = random.Next(Convert.ToInt32(collection.CountDocuments(Builders<Datum>.Filter.Empty)));

                var randomSimilarAnime = collection.Find(o => o != null).ToList().ElementAt(index);

                animeTable.AppendFormat(@"<table style='width: 100%; border: 1px solid #ddd; border-collapse: collapse; font-family: Arial, sans-serif;'>
                    <thead>
                        <tr style='background-color: #f4f4f4;'>
                            <th colspan='2' style='border: 1px solid #ddd; padding: 10px; text-align: left;'>Because you liked {0}, you might also like</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style='border: 1px solid #ddd; padding: 10px; width: 70%; vertical-align: top;'>
                                <h2 style='margin: 0; color: #333;'>{2}</h2>
                                <p style='margin: 10px 0; color: #666;'>{3}</p>
                                <p style='margin: 10px 0; color: #666;'>{5}</p>
                            </td>
                            <td style='border: 1px solid #ddd; padding: 10px; width: 30%; text-align: center;'>
                                <a href='{4}' style='text-decoration: none;'>
                                    <img width='200' height='200' style='cursor: pointer; border: 0;' src='{1}' alt='{2}'>
                                </a>
                            </td>
                        </tr>
                    </tbody>
                </table><br><br>",
                randomAnime.Title,
                randomSimilarAnime.Images.Jpg.ImageUrl,
                randomSimilarAnime.Title,
                randomSimilarAnime.Background,
                $"https://localhost:4200/anime/{randomSimilarAnime.Title}",
                randomSimilarAnime.Synopsis);


                return animeTable.ToString();
            }
            else
                return String.Empty;
        }

        public static string GetMangaPartTemplate(AppUser user, IMongoCollection<DatumManga> collection, Random random)
        {
            var mangaTable = new StringBuilder();
            var randomManga = new DatumManga();
            var randomRecommendedMangas = new List<DatumManga>();

            if (user.AppUserManga.Count > 0)
            {
                var countMangas = 0;
                var mangasIdList = user.AppUserManga;

                var index = random.Next(mangasIdList.Count);
                randomManga = collection.Find(u => u.Id.ToString() == mangasIdList.ElementAt(index).MangaId).FirstOrDefault();

                countMangas++;

                while (randomManga.Status == null)
                {
                    index = random.Next(mangasIdList.Count);
                    randomManga = collection.Find(u => u.Id.ToString() == mangasIdList.ElementAt(index).MangaId).FirstOrDefault();


                    countMangas++;

                    if (countMangas == mangasIdList.Count)
                        break;
                }

                index = random.Next(Convert.ToInt32(collection.CountDocuments(Builders<DatumManga>.Filter.Empty)));

                var randomSimilarManga = collection.Find(o => o != null).ToList().ElementAt(index);

                mangaTable.AppendFormat(@"<table style='width: 100%; border: 1px solid #ddd; border-collapse: collapse; font-family: Arial, sans-serif;'>
                    <thead>
                        <tr style='background-color: #f4f4f4;'>
                            <th colspan='2' style='border: 1px solid #ddd; padding: 10px; text-align: left;'>Because you liked {0}, you might also like</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style='border: 1px solid #ddd; padding: 10px; width: 70%; vertical-align: top;'>
                                <h2 style='margin: 0; color: #333;'>{2}</h2>
                                <p style='margin: 10px 0; color: #666;'>{3}</p>
                                <p style='margin: 10px 0; color: #666;'>{5}</p>
                            </td>
                            <td style='border: 1px solid #ddd; padding: 10px; width: 30%; text-align: center;'>
                                <a href='{4}' style='text-decoration: none;'>
                                    <img width='200' height='200' style='cursor: pointer; border: 0;' src='{1}' alt='{2}'>
                                </a>
                            </td>
                        </tr>
                    </tbody>
                </table><br><br>",
                 randomManga.Title,
                 randomSimilarManga.Images.Jpg.ImageUrl,
                 randomSimilarManga.Title,
                 randomSimilarManga.Background,
                 $"https://localhost:4200/manga/{randomSimilarManga.Title}",
                 randomSimilarManga.Synopsis);


                return mangaTable.ToString();
            }
            else
                return String.Empty;
        }

        public static string GetGamePartTemplate(AppUser user, IMongoCollection<Game> collection, Random random)
        {
            var gameTable = new StringBuilder();
            var randomGame = new Game();
            var randomRecommendedGames = new List<Game>();

            if (user.AppUserGame.Count > 0)
            {
                var countGames = 0;
                var gamesIdList = user.AppUserGame;

                var index = random.Next(gamesIdList.Count);
                randomGame = collection.Find(u => u.Id.ToString() == gamesIdList.ElementAt(index).GameId).FirstOrDefault();

                countGames++;

                while (randomGame.Description == null)
                {
                    index = random.Next(gamesIdList.Count);
                    randomGame = collection.Find(u => u.Id.ToString() == gamesIdList.ElementAt(index).GameId).FirstOrDefault();

                    countGames++;

                    if (countGames == gamesIdList.Count)
                        break;
                }

                index = random.Next(Convert.ToInt32(collection.CountDocuments(Builders<Game>.Filter.Empty)));

                var randomSimilarGame = collection.Find(o => o != null).ToList().ElementAt(index);

                gameTable.AppendFormat(@"<table style='width: 100%; border: 1px solid #ddd; border-collapse: collapse; font-family: Arial, sans-serif;'>
                    <thead>
                        <tr style='background-color: #f4f4f4;'>
                            <th colspan='2' style='border: 1px solid #ddd; padding: 10px; text-align: left;'>Because you liked {0}, you might also like</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style='border: 1px solid #ddd; padding: 10px; width: 70%; vertical-align: top;'>
                                <h2 style='margin: 0; color: #333;'>{2}</h2>
                                <p style='margin: 10px 0; color: #666;'>{3}</p>
                            </td>
                            <td style='border: 1px solid #ddd; padding: 10px; width: 30%; text-align: center;'>
                                <a href='{4}' style='text-decoration: none;'>
                                    <img width='200' height='200' style='cursor: pointer; border: 0;' src='{1}' alt='{2}'>
                                </a>
                            </td>
                        </tr>
                    </tbody>
                </table><br><br>",
                randomGame.Name,
                randomSimilarGame.BackgroundImage,
                randomSimilarGame.Name,
                randomSimilarGame.DescriptionRaw,
                $"https://localhost:4200/games/{randomSimilarGame.Name}");

                return gameTable.ToString();
            }
            else
                return String.Empty;
        }

        public static string GetBookPartTemplate(AppUser user, IMongoCollection<Book> collection, Random random)
        {
            var bookTable = new StringBuilder();
            var randomBook = new Book();
            var randomRecommendedBooks = new List<Book>();

            if (user.AppUserBook.Count > 0)
            {
                var countBooks = 0;
                var booksIdList = user.AppUserBook;

                var index = random.Next(booksIdList.Count);
                randomBook = collection.Find(u => u.Id.ToString() == booksIdList.ElementAt(index).BookId).FirstOrDefault();

                countBooks++;

                while (randomBook.Isbn == null)
                {
                    index = random.Next(booksIdList.Count);
                    randomBook = collection.Find(u => u.Id.ToString() == booksIdList.ElementAt(index).BookId).FirstOrDefault();

                    countBooks++;

                    if (countBooks == booksIdList.Count)
                        break;
                }

                index = random.Next(Convert.ToInt32(collection.CountDocuments(Builders<Book>.Filter.Empty)));

                var randomSimilarBook = collection.Find(o => o != null).ToList().ElementAt(index);

                bookTable.AppendFormat(@"<table style='width: 100%; border: 1px solid #ddd; border-collapse: collapse; font-family: Arial, sans-serif;'>
                    <thead>
                        <tr style='background-color: #f4f4f4;'>
                            <th colspan='2' style='border: 1px solid #ddd; padding: 10px; text-align: left;'>Because you liked {0}, you might also like</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style='border: 1px solid #ddd; padding: 10px; width: 70%; vertical-align: top;'>
                                <h2 style='margin: 0; color: #333;'>{1}</h2>
                                <p style='margin: 10px 0; color: #666;'>Written by: {2}</p>
                            </td>
                        </tr>
                    </tbody>
                </table><br><br>",
                randomBook.Title,
                randomSimilarBook.Title,
                randomSimilarBook.Authors,
                $"https://localhost:4200/books/{randomSimilarBook.Title}");

                return bookTable.ToString();
            }
            else
                return String.Empty;
        }
    }
}
