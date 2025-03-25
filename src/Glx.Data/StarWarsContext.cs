namespace DropoutCoder.StarWars.Data {
    using DropoutCoder.StarWars.Data.Schema.Configuration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Conventions;

    public class StarWarsContext : DbContext {
        public StarWarsContext(DbContextOptions<StarWarsContext> options)
            : base(options) { }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
            configurationBuilder
                .Conventions
                .Remove(typeof(CascadeDeleteConvention));
            configurationBuilder
                .Conventions
                .Remove(typeof(SqlServerOnDeleteConvention));

            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder
                .ApplyConfiguration(new CharacterSchemaConfiguration())
                .ApplyConfiguration(new MovieSchemaConfiguration())
                .ApplyConfiguration(new PlanetSchemaConfiguration())
                .ApplyConfiguration(new SpeciesSchemaConfiguration())
                .ApplyConfiguration(new StarshipSchemaConfiguration())
                .ApplyConfiguration(new VehicleSchemaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
