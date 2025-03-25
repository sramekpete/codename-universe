namespace DropoutCoder.StarWars.Data.Schema.Configuration {
    using DropoutCoder.StarWars.Data.Schema;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CharacterSchemaConfiguration : IEntityTypeConfiguration<CharacterSchema> {
        public void Configure(EntityTypeBuilder<CharacterSchema> builder) {
            builder
                .HasKey(e => e.Id)
                .IsClustered();

            builder
                 .Property(e => e.Name)
                 .IsRequired();

            builder
                .Property(c => c.EyeColor)
                .IsRequired();

            builder
                .Property(c => c.Gender)
                .IsRequired();

            builder
                .Property(c => c.HairColor)
                .IsRequired();

            builder
                .Property(c => c.Height)
                .IsRequired();

            builder
                .Property(c => c.SkinColor)
                .IsRequired();

            builder
                .Property(c => c.YearOfBirth)
                .IsRequired();

            builder
                .Navigation(c => c.Planet)
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .EnableLazyLoading()
                .IsRequired();

            builder
                .HasMany(c => c.Species)
                .WithMany(p => p.Characters)
                .UsingEntity("Characters_Species");

            builder
                .HasMany(c => c.Starships)
                .WithMany(p => p.Pilots)
                .UsingEntity("Characters_Starships");

            builder
                .HasMany(c => c.Vehicles)
                .WithMany(p => p.Pilots)
                .UsingEntity("Characters_Vehicles");

            builder
                .ToTable("Characters");
        }
    }
}
