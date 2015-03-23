namespace MovieFanatic.Domain.Model
{
    public class ProductionCompanyMovie : EntityBase
    {
        public ProductionCompanyMovie(ProductionCompany productionCompany, Movie movie)
            : this()
        {
            ProductionCompany = productionCompany;
            Movie = movie;
        }
        private ProductionCompanyMovie() { }

        public virtual ProductionCompany ProductionCompany { get; protected set; }
        public virtual Movie Movie { get; protected set; }
    }
}