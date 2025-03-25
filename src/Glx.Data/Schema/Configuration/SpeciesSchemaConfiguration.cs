namespace Glx.Data.Schema.Configuration {
    using Glx.Data.Schema;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class SpeciesSchemaConfiguration : IEntityTypeConfiguration<SpeciesSchema> {
        public void Configure(EntityTypeBuilder<SpeciesSchema> builder) {
            builder
                .HasKey(e => e.Id)
                .IsClustered();

            builder
                 .Property(e => e.Name)
                 .IsRequired();

            builder
                .Property(m => m.AverageLifespan)
                .IsRequired();

            builder
                .Property(m => m.Classification)
                .IsRequired();

            builder
                .Property(m => m.Designation)
                .IsRequired();

            builder
                .Property(m => m.EyeColor)
                .IsRequired();

            builder
                .Property(m => m.HairColor)
                .IsRequired();

            builder
                .Property(m => m.Height)
                .IsRequired();

            builder
                .Property(m => m.Language)
                .IsRequired();

            builder
                .Property(m => m.SkinColor)
                .IsRequired();

            builder
                .ToTable("Species");
        }
    }
}
