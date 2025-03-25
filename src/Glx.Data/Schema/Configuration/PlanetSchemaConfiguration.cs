namespace Glx.Data.Schema.Configuration {
    using Glx.Data.Schema;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class PlanetSchemaConfiguration : IEntityTypeConfiguration<PlanetSchema> {
        public void Configure(EntityTypeBuilder<PlanetSchema> builder) {
            builder
                .HasKey(e => e.Id)
                .IsClustered();

            builder
                 .Property(e => e.Name)
                 .IsRequired();

            builder
                .Property(m => m.Climate)
                .IsRequired();

            builder
                .Property(m => m.Diameter)
                .IsRequired();

            builder
                .Property(m => m.Gravity)
                .IsRequired();

            builder
                .Property(m => m.OrbitalPeriod)
                .IsRequired();

            builder
                .Property(m => m.Population)
                .IsRequired();

            builder
                .Property(m => m.RotationPeriod)
                .IsRequired();

            builder
                .Property(m => m.Terrain)
                .IsRequired();

            builder
                .Property(m => m.WaterCoverage)
                .IsRequired();

            builder
                .ToTable("Planets");
        }
    }
}
