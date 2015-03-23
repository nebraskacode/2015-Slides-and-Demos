using System.Data.Entity.ModelConfiguration;
using MovieFanatic.Domain;
using MovieFanatic.Domain.Model;

namespace MovieFanatic.Data.Extensions.Configurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(genre => genre.Name).HasMaxLength(50).IsRequired();
        }
    }
}