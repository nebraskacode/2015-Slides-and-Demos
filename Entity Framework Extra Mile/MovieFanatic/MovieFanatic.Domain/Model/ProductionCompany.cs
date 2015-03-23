using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MovieFanatic.Domain.Model
{
    public class ProductionCompany : EntityBase
    {
        public ProductionCompany(string name)
            : this()
        {
            Name = name;
        }
        private ProductionCompany()
        {
            ProductionCompanyMovies = new Collection<ProductionCompanyMovie>();
        }

        public string Name { get; private set; }

        public virtual ICollection<ProductionCompanyMovie> ProductionCompanyMovies { get; protected set; }
    }
}