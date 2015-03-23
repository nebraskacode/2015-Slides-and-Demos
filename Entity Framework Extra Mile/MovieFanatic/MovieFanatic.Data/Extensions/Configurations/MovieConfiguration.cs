using System.Data.Entity.ModelConfiguration;
using MovieFanatic.Domain.Model;

namespace MovieFanatic.Data.Extensions.Configurations
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            Property(movie => movie.Title).HasMaxLength(100).IsRequired();
            Property(movie => movie.AverageRating).HasPrecision(4, 2);

            HasRequired(movie => movie.Status)
                .WithMany(stat => stat.Movies);
        }
    }
}