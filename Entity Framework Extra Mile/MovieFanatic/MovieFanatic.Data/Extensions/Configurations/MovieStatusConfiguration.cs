using System.Data.Entity.ModelConfiguration;
using MovieFanatic.Domain.Model;

namespace MovieFanatic.Data.Extensions.Configurations
{
    public class MovieStatusConfiguration : EntityTypeConfiguration<MovieStatus>
    {
        public MovieStatusConfiguration()
        {
            Property(status => status.Status).HasMaxLength(50).IsRequired();
        }
    }
}