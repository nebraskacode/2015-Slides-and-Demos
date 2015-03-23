using System;
using System.Collections.Generic;

namespace MovieFanatic.Web.Models
{
    public class MovieIndexViewModel
    {
        public bool IsShowingDeleted { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

        public class Movie
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Overview { get; set; }
            public decimal? AverageRating { get; set; }
            public IEnumerable<string> Genres { get; set; }
            public IEnumerable<string> Actors { get; set; }
        }
    }
}