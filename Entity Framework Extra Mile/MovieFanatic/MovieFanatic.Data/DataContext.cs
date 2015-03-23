using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using Elmah;
using MovieFanatic.Data.Extensions.Configurations;
using MovieFanatic.Domain;
using MovieFanatic.Domain.Model;
using MovieFanatic.Utility;

namespace MovieFanatic.Data
{
    public class DataContext : DbContext
    {
        private readonly IAuthenticator _authenticator;

        // ReSharper disable once MemberCanBePrivate.Global
        public DataContext()
            : base("MovieFanatic")
        {
            //Migrations should be the only thing using this constructor. Use faked authenticator.
            _authenticator = new MigrationsAuthenticator();
        }

        public DataContext(IAuthenticator authenticator)
            : base("MovieFanatic")
        {
            _authenticator = authenticator;
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<ProductionCompanyMovie> ProductionCompanyMovies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieStatus> MovieStatuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new MovieConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new ProductionCompanyConfiguration());
            modelBuilder.Configurations.Add(new CharacterConfiguration());
            modelBuilder.Configurations.Add(new ActorConfiguration());
            modelBuilder.Configurations.Add(new MovieGenreConfiguration());
            modelBuilder.Configurations.Add(new ProductionCompanyMovieConfiguration());
            modelBuilder.Configurations.Add(new MovieStatusConfiguration());

            var conv = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
                "SoftDeleteColumnName",
                (type, attributes) => attributes.Single().ColumnName);

            modelBuilder.Conventions.Add(conv);
        }

        public override int SaveChanges()
        {
            var now = DateTime.Now;
            var user = _authenticator.IsAuthenticated() ? _authenticator.GetCurrentUser() : "Anonymous";
            var changeSet = ChangeTracker.Entries<EntityBase>();

            if (changeSet != null)
            {
                foreach (var item in changeSet)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            item.Entity.AddedBy = user;
                            item.Entity.AddedDate = now;
                            item.Entity.UpdatedBy = user;
                            item.Entity.UpdatedDate = now;
                            break;
                        case EntityState.Modified:
                            item.Entity.UpdatedBy = user;
                            item.Entity.UpdatedDate = now;
                            break;
                    }
                }
            }

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entity in ex.EntityValidationErrors)
                {
                    foreach (var item in entity.ValidationErrors)
                    {
                        ErrorSignal.FromCurrentContext().Raise(new Exception(String.Format("Validation Error :: {0}.{1} - {2}. Attempted to save {3}.", entity.Entry.Entity, item.PropertyName, item.ErrorMessage, entity.Entry.CurrentValues)));
                    }
                }

                throw;
            }
        }
    }
}