using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MovieFanatic.Domain.Model
{
    public class Movie : EntityBase
    {
        public Movie(string title, int apiId, DateTime releaseDate, MovieStatus status)
            : this()
        {
            Title = title;
            ApiId = apiId;
            ReleaseDate = releaseDate;
            Status = status;
        }
        private Movie()
        {
            MovieGenres = new Collection<MovieGenre>();
            ProductionCompanyMovies = new Collection<ProductionCompanyMovie>();
            Characters = new Collection<Character>();
        }

        public string Title { get; set; }
        public int ApiId { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string Overview { get; set; }
        public decimal? AverageRating { get; set; }
        public bool HaveWatched { get; private set; }
        public DateTime? WatchedOn { get; private set; }
        public string Review { get; private set; }

        public virtual MovieStatus Status { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; protected set; }
        public virtual ICollection<ProductionCompanyMovie> ProductionCompanyMovies { get; protected set; }
        public virtual ICollection<Character> Characters { get; protected set; }

        public void Watched(string review)
        {
            HaveWatched = true;
            WatchedOn = DateTime.UtcNow;
            Review = review;
        }
    }
}