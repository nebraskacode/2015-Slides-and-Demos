using System.Data.Entity.ModelConfiguration;
using MovieFanatic.Domain;
using MovieFanatic.Domain.Model;

namespace MovieFanatic.Data.Extensions.Configurations
{
    public class ProductionCompanyConfiguration : EntityTypeConfiguration<ProductionCompany>
    {
        public ProductionCompanyConfiguration()
        {
            Property(comp => comp.Name).HasMaxLength(100).IsRequired();
        }
    }
}