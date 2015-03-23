using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using MovieFanatic.Domain.Model;
using Newtonsoft.Json;

namespace MovieFanatic.Web.Infrastructure
{
    public class MovieLoader
    {
        private static readonly IList<Domain.Model.Genre> _genres = new List<Domain.Model.Genre>();
        private static readonly IList<Domain.Model.ProductionCompany> _productionCompanies = new List<Domain.Model.ProductionCompany>();
        private static readonly IList<Actor> _actors = new List<Actor>();
        private static readonly IList<MovieStatus> _statuses = new List<MovieStatus>();

        public static IEnumerable<Domain.Model.Movie> LoadMovies()
        {
            var result = new List<Domain.Model.Movie>();

            for (var index = 1; index <= 100; index++)
            {
                result.AddRange(LoadMovies(index));
            }

            return result;
        }

        private static IEnumerable<Domain.Model.Movie> LoadMovies(int page)
        {
            var apiKey = ConfigurationManager.AppSettings["tmd-api-key"];

            var request = (HttpWebRequest)WebRequest.Create(String.Format("http://api.themoviedb.org/3/movie/top_rated?api_key={0}&page={1}", apiKey, page));
            request.KeepAlive = true;
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentLength = 0;
            string responseContent;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();
                }
            }

            var results = JsonConvert.DeserializeObject<RootMovie>(responseContent).results;
            var movies = new List<Domain.Model.Movie>();

            foreach (var result in results)
            {
                request = (HttpWebRequest)WebRequest.Create(String.Format("http://api.themoviedb.org/3/movie/{1}?api_key={0}", apiKey, result.id));
                request.KeepAlive = true;
                request.Method = "GET";
                request.Accept = "application/json";
                request.ContentLength = 0;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }

                var detail = JsonConvert.DeserializeObject<RootMovieDetail>(responseContent);

                if (detail.release_date == "")
                {
                    continue;
                }

                var status = _statuses.SingleOrDefault(stat => stat.Status == detail.status);
                if (status == null)
                {
                    status = new MovieStatus(detail.status);
                    _statuses.Add(status);
                }

                var movie = new Domain.Model.Movie(detail.title, detail.id, DateTime.Parse(detail.release_date), status) { Overview = detail.overview, AverageRating = (decimal?)detail.vote_average };
                foreach (var genre in detail.genres)
                {
                    var selectedGenre = _genres.SingleOrDefault(gen => gen.Name == genre.name);

                    if (selectedGenre == null)
                    {
                        selectedGenre = new Domain.Model.Genre(genre.name);
                        _genres.Add(selectedGenre);
                    }

                    movie.MovieGenres.Add(new MovieGenre(movie, selectedGenre));
                }

                foreach (var productionCompany in detail.production_companies)
                {
                    var selectedCompany = _productionCompanies.SingleOrDefault(comp => comp.Name == productionCompany.name);

                    if (selectedCompany == null)
                    {
                        selectedCompany = new Domain.Model.ProductionCompany(productionCompany.name);
                        _productionCompanies.Add(selectedCompany);
                    }

                    movie.ProductionCompanyMovies.Add(new ProductionCompanyMovie(selectedCompany, movie));
                }

                request = (HttpWebRequest)WebRequest.Create(String.Format("http://api.themoviedb.org/3/movie/{1}/credits?api_key={0}", apiKey, result.id));
                request.KeepAlive = true;
                request.Method = "GET";
                request.Accept = "application/json";
                request.ContentLength = 0;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }

                var credit = JsonConvert.DeserializeObject<RootCredits>(responseContent);

                foreach (var cast in credit.cast)
                {
                    var selectedActor = _actors.SingleOrDefault(actor => actor.Name == cast.name);

                    if (selectedActor == null)
                    {
                        selectedActor = new Actor(cast.name);
                        _actors.Add(selectedActor);
                    }

                    movie.Characters.Add(new Character(cast.character, movie, selectedActor));
                }

                movies.Add(movie);
            }

            return movies;
        }

        //thanks http://json2csharp.com/
        private class Movie
        {
            public bool adult { get; set; }
            public string backdrop_path { get; set; }
            public int id { get; set; }
            public string original_title { get; set; }
            public string release_date { get; set; }
            public string poster_path { get; set; }
            public double popularity { get; set; }
            public string title { get; set; }
            public double vote_average { get; set; }
            public int vote_count { get; set; }
        }

        private class RootMovie
        {
            public int page { get; set; }
            public List<Movie> results { get; set; }
            public int total_pages { get; set; }
            public int total_results { get; set; }
        }

        private class Genre
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        private class ProductionCompany
        {
            public string name { get; set; }
            public int id { get; set; }
        }

        private class ProductionCountry
        {
            public string iso_3166_1 { get; set; }
            public string name { get; set; }
        }

        private class SpokenLanguage
        {
            public string iso_639_1 { get; set; }
            public string name { get; set; }
        }

        private class RootMovieDetail
        {
            public bool adult { get; set; }
            public string backdrop_path { get; set; }
            public object belongs_to_collection { get; set; }
            public int budget { get; set; }
            public List<Genre> genres { get; set; }
            public string homepage { get; set; }
            public int id { get; set; }
            public string imdb_id { get; set; }
            public string original_title { get; set; }
            public string overview { get; set; }
            public double popularity { get; set; }
            public string poster_path { get; set; }
            public List<ProductionCompany> production_companies { get; set; }
            public List<ProductionCountry> production_countries { get; set; }
            public string release_date { get; set; }
            public long revenue { get; set; }
            public int runtime { get; set; }
            public List<SpokenLanguage> spoken_languages { get; set; }
            public string status { get; set; }
            public string tagline { get; set; }
            public string title { get; set; }
            public double vote_average { get; set; }
            public int vote_count { get; set; }
        }

        private class Cast
        {
            public int cast_id { get; set; }
            public string character { get; set; }
            public string credit_id { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int order { get; set; }
            public string profile_path { get; set; }
        }

        private class Crew
        {
            public string credit_id { get; set; }
            public string department { get; set; }
            public int id { get; set; }
            public string job { get; set; }
            public string name { get; set; }
            public string profile_path { get; set; }
        }

        private class RootCredits
        {
            public int id { get; set; }
            public List<Cast> cast { get; set; }
            public List<Crew> crew { get; set; }
        }
    }
}