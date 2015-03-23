using System.Data.Entity.ModelConfiguration;
using MovieFanatic.Domain.Model;

namespace MovieFanatic.Data.Extensions.Configurations
{
    public class CharacterConfiguration : EntityTypeConfiguration<Character>
    {
        public CharacterConfiguration()
        {
            Property(charac => charac.Name).HasMaxLength(400).IsRequired();

            HasRequired(charac => charac.Movie)
                .WithMany(movie => movie.Characters);

            HasRequired(charac => charac.Actor)
                .WithMany(actor => actor.Characters);
        }
    }
}