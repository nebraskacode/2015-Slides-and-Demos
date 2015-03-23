using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MovieFanatic.Domain.Model
{
    public class Genre : EntityBase
    {
        public Genre(string name)
            : this()
        {
            Name = name;
        }
        private Genre()
        {
            MovieGenres = new Collection<MovieGenre>();
        }

        public string Name { get; private set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; protected set; }
    }
}
