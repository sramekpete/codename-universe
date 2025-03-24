namespace DropoutCoder.StarWars.OData.Models.Configurations;

using Asp.Versioning;
using Asp.Versioning.OData;
using DropoutCoder.StarWars.Data.Schema;
using Microsoft.OData.ModelBuilder;

public sealed class CharacterModelConfiguration : IModelConfiguration {
    public void Apply(ODataModelBuilder builder, ApiVersion apiVersion, string? routePrefix) {
        var set = builder
            .EntitySet<CharacterSchema>("Character");

        var type = set.EntityType;

        type.Count();
        type.Expand(1, SelectExpandType.Allowed, nameof(CharacterSchema.Planet), nameof(CharacterSchema.Movies));
        type.Select(SelectExpandType.Allowed, nameof(CharacterSchema.Planet), nameof(CharacterSchema.Movies));
        type.Filter();
        type.OrderBy();
        type.Page(20, 20);

        ConfigureVersion1_0(type, apiVersion);
        ConfigureVersion1_1(type, apiVersion);
    }

    private static void ConfigureVersion1_0(EntityTypeConfiguration<CharacterSchema> type, ApiVersion apiVersion) {
        if ((apiVersion.MajorVersion == 1 && apiVersion.MinorVersion < 0) || apiVersion.MajorVersion < 1) {
            return;
        }

        type
            .HasKey(t => t.Id);

        type
            .Property(t => t.EyeColor);

        type
            .Property(t => t.Gender);

        type
            .Property(t => t.HairColor);

        type
            .Property(t => t.Height);

        type
            .Property(t => t.Name);

        type
            .Property(t => t.SkinColor);

        type
            .Property(t => t.YearOfBirth);
    }

    private static void ConfigureVersion1_1(EntityTypeConfiguration<CharacterSchema> type, ApiVersion apiVersion) {
        if ((apiVersion.MajorVersion == 1 && apiVersion.MinorVersion < 1) || apiVersion.MajorVersion < 1) {
            return;
        }

        type
            .ContainsRequired(c => c.Planet)
            .Expand(SelectExpandType.Automatic, nameof(PlanetSchema.Id), nameof(PlanetSchema.Name))
            .Select(SelectExpandType.Automatic, nameof(PlanetSchema.Id), nameof(PlanetSchema.Name));

        type
            .ContainsMany(t => t.Movies)
            .Expand(1, SelectExpandType.Automatic, nameof(MovieSchema.Id), nameof(MovieSchema.Name))
            .Select(SelectExpandType.Automatic, nameof(MovieSchema.Id), nameof(MovieSchema.Name));

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
