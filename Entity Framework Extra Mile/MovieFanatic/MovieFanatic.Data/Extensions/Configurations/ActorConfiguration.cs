using System.Data.Entity.ModelConfiguration;
using MovieFanatic.Domain.Model;

namespace MovieFanatic.Data.Extensions.Configurations
{
    public class ActorConfiguration : EntityTypeConfiguration<Actor>
    {
        public ActorConfiguration()
        {
            Property(actor => actor.Name).HasMaxLength(100).IsRequired();
        }
    }
}