namespace Glx.OData.OData.Configurations;

using Asp.Versioning;
using Asp.Versioning.OData;
using Glx.Data.Schema;
using Microsoft.OData.ModelBuilder;

public sealed class MovieModelConfiguration : IModelConfiguration {
    public void Apply(ODataModelBuilder builder, ApiVersion apiVersion, string? routePrefix) {
        var set = builder
            .EntitySet<MovieSchema>("Movie");

        var type = set.EntityType;

        type.Count();
        type.Expand(1, SelectExpandType.Allowed, nameof(MovieSchema.Planets), nameof(MovieSchema.Characters));
        type.Select(SelectExpandType.Allowed, nameof(MovieSchema.Planets), nameof(MovieSchema.Characters));
        type.Filter();
        type.OrderBy();
        type.Page(20, 20);

        ConfigureVersion1_0(type, apiVersion);
        ConfigureVersion1_1(type, apiVersion);
    }

    private static void ConfigureVersion1_0(EntityTypeConfiguration<MovieSchema> type, ApiVersion apiVersion) {
        if (apiVersion.MajorVersion == 1 && apiVersion.MinorVersion < 0 || apiVersion.MajorVersion < 1) {
            return;
        }

        type
            .HasKey(t => t.Id);

        type
            .Property(t => t.Director);

        type
            .Property(t => t.Episode);

        type
            .Property(t => t.Introduction);

        type
            .Property(t => t.Name);

        type
            .Property(t => t.Producer);

        type
            .Property(t => t.Released);
    }

    private static void ConfigureVersion1_1(EntityTypeConfiguration<MovieSchema> type, ApiVersion apiVersion) {
        if (apiVersion.MajorVersion == 1 && apiVersion.MinorVersion < 1 || apiVersion.MajorVersion < 1) {
            return;
        }

        type
            .HasMany(c => c.Planets)
            .Expand(SelectExpandType.Automatic, nameof(PlanetSchema.Id), nameof(PlanetSchema.Name))
            .Select(SelectExpandType.Automatic, nameof(PlanetSchema.Id), nameof(PlanetSchema.Name));

        type
            .HasMany(c => c.Characters)
            .Expand(SelectExpandType.Automatic, nameof(CharacterSchema.Id), nameof(CharacterSchema.Name))
            .Select(SelectExpandType.Automatic, nameof(CharacterSchema.Id), nameof(CharacterSchema.Name));

        //type
        //    .ContainsMany(t => t.Movies)
        //    .Expand(1, SelectExpandType.Allowed, nameof(MovieSchema.Id), nameof(MovieSchema.Name))
        //    .Select(SelectExpandType.Automatic, nameof(MovieSchema.Id), nameof(MovieSchema.Name));

        //type
        //    .CollectionProperty(t => t.Species)
        //    .Expand(1, SelectExpandType.Allowed);

        //type
        //    .CollectionProperty(t => t.Starships)
        //    .Expand(1, SelectExpandType.Allowed);

        //type
        //    .CollectionProperty(t => t.Vehicles)
        //    .Expand(1, SelectExpandType.Allowed);
    }
}
