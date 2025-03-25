namespace Glx.OData.OData.Configurations;

using Asp.Versioning;
using Asp.Versioning.OData;
using Glx.Data.Schema;
using Microsoft.OData.ModelBuilder;

public sealed class PlanetModelConfiguration : IModelConfiguration {
    public void Apply(ODataModelBuilder builder, ApiVersion apiVersion, string? routePrefix) {
        var set = builder
            .EntitySet<PlanetSchema>("Planet");

        var type = set.EntityType;

        type.Count();
        type.Expand(1, SelectExpandType.Allowed, nameof(PlanetSchema.Residents), nameof(PlanetSchema.Movies));
        type.Select(SelectExpandType.Allowed, nameof(PlanetSchema.Residents), nameof(PlanetSchema.Movies));
        type.Filter();
        type.OrderBy();
        type.Page(20, 20);

        ConfigureVersion1_0(type, apiVersion);
        ConfigureVersion1_1(type, apiVersion);
    }

    private static void ConfigureVersion1_0(EntityTypeConfiguration<PlanetSchema> type, ApiVersion apiVersion) {
        if (apiVersion.MajorVersion == 1 && apiVersion.MinorVersion < 0 || apiVersion.MajorVersion < 1) {
            return;
        }

        type
            .HasKey(t => t.Id);

        type
            .Property(t => t.Climate);

        type
            .Property(t => t.Diameter);

        type
            .Property(t => t.Gravity);

        type
            .Property(t => t.Name);

        type
            .Property(t => t.OrbitalPeriod);

        type
            .Property(t => t.Population);

        type
            .Property(t => t.RotationPeriod);

        type
            .Property(t => t.Terrain);

        type
           .Property(t => t.WaterCoverage);
    }

    private static void ConfigureVersion1_1(EntityTypeConfiguration<PlanetSchema> type, ApiVersion apiVersion) {
        if (apiVersion.MajorVersion == 1 && apiVersion.MinorVersion < 1 || apiVersion.MajorVersion < 1) {
            return;
        }

        type
            .HasMany(t => t.Residents)
            .Expand(1, SelectExpandType.Automatic, nameof(CharacterSchema.Id), nameof(CharacterSchema.Name))
            .Expand(1, SelectExpandType.Automatic, nameof(CharacterSchema.Id), nameof(CharacterSchema.Name));

        type
            .HasMany(t => t.Movies)
            .Expand(1, SelectExpandType.Automatic, nameof(MovieSchema.Id), nameof(MovieSchema.Name))
            .Expand(1, SelectExpandType.Automatic, nameof(MovieSchema.Id), nameof(MovieSchema.Name));
    }
}
