using Disertatie_backend.DatabaseContext;
using Disertatie_backend.Entities;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Entities.TvShows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z.EntityFramework.Plus;

namespace Disertatie_backend.EmailTemplates
{
    public class RecommandationEmailTemplate
    {
        public static string GetEmailTemplate(AppUser user, DataContext context)
        {
            var sb = new StringBuilder();
            
            var random = new Random();

            sb.AppendFormat(@"
                        <html>
                            <head>
                            </head>
                            <body>
                            <p>
                            Stimate/ă {0}
                            </p>
                            <p>
                            Vă mulțumim că v-ați abonat la newsletter-ul nostru!<br>
                            </p>
 
                            <p>
                            Prin acest newsletter o să primiți recomandări zilnice în funcție de ce ați urmărit până acum. Așteptăm cu nreăbdare să vă revedem online în comunitatea noastră.<br>
                            </p>

                            <p>Dacă observați ceva neînregulă, vă rugăm să ne contactați pe email sau telefon, pe care le găsiți pe pagina de contact.</p>"
                            , user.UserName);


            var moviePart = GetMoviePartTemplate(user, context, random);
            if (moviePart != String.Empty) sb.AppendFormat(moviePart);

            var tvShowPart = GetTvShowPartTemplate(user, context, random);
            if (tvShowPart != String.Empty) sb.AppendFormat(tvShowPart);

            var animePart = GetAnimePartTemplate(user, context, random);
            if (animePart != String.Empty) sb.AppendFormat(animePart);

            var mangaPart = GetMangaPartTemplate(user, context, random);
            if (mangaPart != String.Empty) sb.AppendFormat(mangaPart);

            var gamePart = GetGamePartTemplate(user, context, random);
            if (gamePart != String.Empty) sb.AppendFormat(gamePart);

            sb.AppendFormat(@"</body>
                        </html>");

            return sb.ToString();
        }

        public static string GetMoviePartTemplate(AppUser user, DataContext context, Random random)
        {
            var movieTable = new StringBuilder();
            var randomMovie = new Movie();

            if (user.AppUserMovie.Count > 0)
            {
                var countMovies = 0;
                var moviesIdList = user.AppUserMovie;

                var index = random.Next(moviesIdList.Count);
                randomMovie = context.Movies.Where(o => o.Id == moviesIdList.ElementAt(index).MovieId).IncludeOptimized(o => o.Similars).FirstOrDefault();

                countMovies++;

                while (randomMovie.Similars == null)
                {
                    index = random.Next(moviesIdList.Count);
                    randomMovie = context.Movies.Where(o => o.Id == moviesIdList.ElementAt(index).MovieId).IncludeOptimized(o => o.Similars).FirstOrDefault();

                    countMovies++;

                    if (countMovies == moviesIdList.Count)
                        break;
                }


                index = random.Next(randomMovie.Similars.Count);

                var movieId = randomMovie.Similars[index].Id;
                var randomSimilarMovie = context.Movies.Where(o => o.Id == movieId).FirstOrDefault();

                movieTable.AppendFormat(@"<table style='width: 100 %; border: 1px solid black; border-collapse: collapse;'>
                                <th colspan='2' style='border: 1px solid black; border-collapse: collapse;'> Pentru ca ți-a plăcut {0}, s-ar putea să îți placă și</th>
                                <tr>
                                    <td style='border: 1px solid black; border-collapse: collapse;'><p>{2}</p><br><p>'{3}'<p></td>
                                    <td style='border: 1px solid black; border-collapse: collapse;'><a href='{4}'><img width='200' style='cursor: pointer' height='200' margin='5' src='{1}'></a></td>
                                </tr>
                            </table><br><br>", randomMovie.Title, randomSimilarMovie.Image, randomSimilarMovie.Title, randomSimilarMovie.Tagline, $"https://localhost:4200/movies/{randomSimilarMovie.Title}");

                return movieTable.ToString();
            }
            else
                return String.Empty;
        }

        public static string GetTvShowPartTemplate(AppUser user, DataContext context, Random random)
        {
            var tvShowTable = new StringBuilder();
            var randomTvShow = new TvShow();

            if (user.AppUserTvShow.Count > 0)
            {
                var countTvShows = 0;
                var tvShowsIdList = user.AppUserTvShow;

                var index = random.Next(tvShowsIdList.Count);
                randomTvShow = context.TrueTvShow.Where(o => o.Id == tvShowsIdList.ElementAt(index).TvShowId).IncludeOptimized(o => o.Similars).FirstOrDefault();

                countTvShows++;

                while (randomTvShow.Similars == null)
                {
                    index = random.Next(tvShowsIdList.Count);
                    randomTvShow = context.TrueTvShow.Where(o => o.Id == tvShowsIdList.ElementAt(index).TvShowId).IncludeOptimized(o => o.Similars).FirstOrDefault();

                    countTvShows++;

                    if (countTvShows == tvShowsIdList.Count)
                        break;
                }


                index = random.Next(randomTvShow.Similars.Count);

                var tvShowId = randomTvShow.Similars[index].Id;
                var randomSimilarTvShow = context.TrueTvShow.Where(o => o.Id == tvShowId).FirstOrDefault();

                tvShowTable.AppendFormat(@"<table style='width: 100 %; border: 1px solid black; border-collapse: collapse;'>
                                <th colspan='2' style='border: 1px solid black; border-collapse: collapse;'> Pentru ca ți-a plăcut {0}, s-ar putea să îți placă și</th>
                                <tr>
                                    <td style='border: 1px solid black; border-collapse: collapse;'><p>{2}</p></td>
                                    <td style='border: 1px solid black; border-collapse: collapse;'><a href='{4}'><img width='200' style='cursor: pointer' height='200' margin='5' src='{1}'></a></td>
                                </tr>
                            </table><br><br>", randomTvShow.Title, randomSimilarTvShow.Image, randomSimilarTvShow.Title, string.Empty, $"https://localhost:4200/tvShows/{randomSimilarTvShow.Title}");

                return tvShowTable.ToString();
            }
            else
                return String.Empty;
        }

        public static string GetAnimePartTemplate(AppUser user, DataContext context, Random random)
        {
            var animeTable = new StringBuilder();
            var randomAnime = new Datum();
            var randomRecommendedAnimes = new List<Datum>();

            if (user.AppUserAnime.Count > 0)
            {
                var countAnimes = 0;
                var animesIdList = user.AppUserAnime;

                var index = random.Next(animesIdList.Count);
                randomAnime = context.Anime.Where(o => o.Id == animesIdList.ElementAt(index)).IncludeOptimized(o => o.Licensors).FirstOrDefault();

                countAnimes++;

                while (randomAnime.Licensors == null)
                {
                    index = random.Next(animesIdList.Count);
                    randomAnime = context.Anime.Where(o => o.Id == animesIdList.ElementAt(index)).IncludeOptimized(o => o.Licensors).FirstOrDefault();

                    countAnimes++;

                    if (countAnimes == animesIdList.Count)
                        break;
                }

                index = random.Next(context.Anime.Count());

                var randomSimilarAnime = context.Anime.Where(o => o != null).IncludeOptimized(u => u.Images).IncludeOptimized(u => u.Images.Webp).ToList().ElementAt(index);

                animeTable.AppendFormat(@"<table style='width: 100 %; border: 1px solid black; border-collapse: collapse;'>
                                <th colspan='2' style='border: 1px solid black; border-collapse: collapse;'> Pentru ca ți-a plăcut {0}, s-ar putea să îți placă și</th>
                                <tr>
                                    <td style='border: 1px solid black; border-collapse: collapse;'><p>{2}</p></td>
                                    <td style='border: 1px solid black; border-collapse: collapse;'><a href='{4}'><img width='200' style='cursor: pointer' height='200' margin='5' src='{1}'></a></td>
                                </tr>
                            </table><br><br>", randomAnime.Title, randomSimilarAnime.Images.Webp.Image_url, randomSimilarAnime.Title, string.Empty, $"https://localhost:4200/anime/{randomSimilarAnime.Title}");

                return animeTable.ToString();
            }
            else
                return String.Empty;
        }

        public static string GetMangaPartTemplate(AppUser user, DataContext context, Random random)
        {
            var mangaTable = new StringBuilder();
            var randomManga = new DatumManga();
            var randomRecommendedMangas = new List<DatumManga>();

            if (user.AppUserManga.Count > 0)
            {
                var countMangas = 0;
                var mangasIdList = user.AppUserManga;

                var index = random.Next(mangasIdList.Count);
                randomManga = context.Manga.Where(o => o.Mal_id == mangasIdList.ElementAt(index).MangaId).FirstOrDefault();

                countMangas++;

                while (randomManga.Status == null)
                {
                    index = random.Next(mangasIdList.Count);
                    randomManga = context.Manga.Where(o => o.Mal_id == mangasIdList.ElementAt(index).MangaId).FirstOrDefault();

                    countMangas++;

                    if (countMangas == mangasIdList.Count)
                        break;
                }

                index = random.Next(context.Manga.Count());

                var randomSimilarManga = context.Manga.Where(o => o != null).IncludeOptimized(u => u.Images).IncludeOptimized(u => u.Images.Webp).ToList().ElementAt(index);

                mangaTable.AppendFormat(@"<table style='width: 100 %; border: 1px solid black; border-collapse: collapse;'>
                                <th colspan='2' style='border: 1px solid black; border-collapse: collapse;'> Pentru ca ți-a plăcut {0}, s-ar putea să îți placă și</th>
                                <tr>
                                    <td style='border: 1px solid black; border-collapse: collapse;'><p>{2}</p></td>
                                    <td style='border: 1px solid black; border-collapse: collapse;'><a href='{4}'><img width='200' style='cursor: pointer' height='200' margin='5' src='{1}'></a></td>
                                </tr>
                            </table><br><br>", randomManga.Title, randomSimilarManga.Images.Webp.Image_url, randomSimilarManga.Title, string.Empty, $"https://localhost:4200/manga/{randomSimilarManga.Title}");

                return mangaTable.ToString();
            }
            else
                return String.Empty;
        }

        public static string GetGamePartTemplate(AppUser user, DataContext context, Random random)
        {
            var gameTable = new StringBuilder();
            var randomGame = new Game();
            var randomRecommendedGames = new List<Game>();

            if (user.AppUserGame.Count > 0)
            {
                var countGames = 0;
                var gamesIdList = user.AppUserGame;

                var index = random.Next(gamesIdList.Count);
                randomGame = context.Games.Where(o => o.Id == gamesIdList.ElementAt(index).GameId).FirstOrDefault();

                countGames++;

                while (randomGame.Description == null)
                {
                    index = random.Next(gamesIdList.Count);
                    randomGame = context.Games.Where(o => o.Id == gamesIdList.ElementAt(index).GameId).FirstOrDefault();

                    countGames++;

                    if (countGames == gamesIdList.Count)
                        break;
                }

                index = random.Next(context.Games.Count());

                var randomSimilarGame = context.Games.Where(o => o != null).IncludeOptimized(u => u.Background_image).ToList().ElementAt(index);

                gameTable.AppendFormat(@"<table style='width: 100 %; border: 1px solid black; border-collapse: collapse;'>
                                <th colspan='2' style='border: 1px solid black; border-collapse: collapse;'> Pentru ca ți-a plăcut {0}, s-ar putea să îți placă și</th>
                                <tr>
                                    <td style='border: 1px solid black; border-collapse: collapse;'><p>{2}</p></td>
                                    <td style='border: 1px solid black; border-collapse: collapse;'><a href='{4}'><img width='200' style='cursor: pointer' height='200' margin='5' src='{1}'></a></td>
                                </tr>
                            </table><br><br>", randomGame.Name, randomSimilarGame.Background_image, randomSimilarGame.Name, string.Empty, $"https://localhost:4200/games/{randomSimilarGame.Name}");

                return gameTable.ToString();
            }
            else
                return String.Empty;
        }
    }
}
