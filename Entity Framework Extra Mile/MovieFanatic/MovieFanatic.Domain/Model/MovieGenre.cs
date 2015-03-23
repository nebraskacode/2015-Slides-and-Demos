namespace MovieFanatic.Domain.Model
{
    public class MovieGenre : EntityBase
    {
        public MovieGenre(Movie movie, Genre genre)
            : this()
        {
            Movie = movie;
            Genre = genre;
        }
        private MovieGenre() { }

        public virtual Movie Movie { get; protected set; }
        public virtual Genre Genre { get; protected set; }
    }
}