using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MovieFanatic.Domain.Model
{
    public class MovieStatus : EntityBase
    {
        public MovieStatus(string status)
            : this()
        {
            Status = status;
        }
        private MovieStatus()
        {
            Movies = new Collection<Movie>();
        }

        public string Status { get; private set; }

        public virtual ICollection<Movie> Movies { get; protected set; } 
    }
}