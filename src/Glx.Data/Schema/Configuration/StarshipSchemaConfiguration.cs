namespace Glx.Data.Schema.Configuration {
    using Glx.Data.Schema;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class StarshipSchemaConfiguration : IEntityTypeConfiguration<StarshipSchema> {
        public void Configure(EntityTypeBuilder<StarshipSchema> builder) {
            builder
                .HasKey(e => e.Id)
                .IsClustered();

            builder
                 .Property(e => e.Name)
                 .IsRequired();

            builder
                .Property(c => c.CargoCapacity)
                .IsRequired();

            builder
                .Property(c => c.Class)
                .IsRequired();

            builder
                .Property(c => c.Consumables)
                .IsRequired();

            builder
                .Property(c => c.Crew)
                .IsRequired();

            builder
                .Property(s => s.HyperdriveRating)
                .IsRequired();

            builder
                .Property(c => c.Length)
                .IsRequired();

            builder
                .Property(c => c.Manufacturer)
                .IsRequired();

            builder
                .Property(c => c.MaxAtmosphericSpeed)
                .IsRequired();

            builder
                .Property(s => s.MaxMegaLightsSpeed)
                .IsRequired();

            builder
                .Property(c => c.Model)
                .IsRequired();

            builder
                .Property(c => c.Passengers)
                .IsRequired();

            builder
                .Property(c => c.Price)
                .IsRequired();

            builder
                .ToTable("Starships");
        }
    }
}
