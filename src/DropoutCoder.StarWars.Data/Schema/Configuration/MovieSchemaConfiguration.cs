namespace DropoutCoder.StarWars.Data.Schema.Configuration {
    using DropoutCoder.StarWars.Data.Schema;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class MovieSchemaConfiguration : IEntityTypeConfiguration<MovieSchema> {
        public void Configure(EntityTypeBuilder<MovieSchema> builder) {
            builder
                .HasKey(e => e.Id)
                .IsClustered();

            builder
                 .Property(e => e.Name)
                 .IsRequired();

            builder
                .Property(m => m.Director)
                .IsRequired();

            builder
                .Property(m => m.Episode)
                .IsRequired();

            builder
                .Property(m => m.Introduction)
                .IsRequired();

            builder
                .Property(m => m.Producer)
                .IsRequired();

            builder
                .Property(m => m.Released)
                .IsRequired();

            builder
                .HasMany(m => m.Characters)
                .WithMany(c => c.Movies)
                .UsingEntity("Movies_Characters");

            builder
                .HasMany(m => m.Planets)
                .WithMany(c => c.Movies)
                .UsingEntity("Movies_Planets");

            builder
                .HasMany(m => m.Species)
                .WithMany(s => s.Movies)
                .UsingEntity("Movies_Species");

            builder
                .HasMany(m => m.Starships)
                .WithMany(s => s.Movies)
                .UsingEntity("Movies_Starships");

            builder
                .HasMany(m => m.Vehicles)
                .WithMany(v => v.Movies)
                .UsingEntity("Movies_Vehicles");
            ;

            builder
                .ToTable("Movies");
        }
    }
}
