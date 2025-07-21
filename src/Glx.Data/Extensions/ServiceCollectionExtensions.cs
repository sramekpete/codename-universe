namespace Glx.Data.Extensions {
    using Glx.Data;
    using Glx.Data.Schema;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq.Expressions;

    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString) {
            return services
                .AddDbContext<GlxContext>(options => {
                    options.UseSqlServer(connectionString, options => {
                        //options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    }).UseLazyLoadingProxies();
                })
                .AddScoped<IQueryable<CharacterSchema>>(sp => sp.GetRequiredService<GlxContext>().Set<CharacterSchema>())
                .AddScoped<IQueryable<MovieSchema>>(sp => sp.GetRequiredService<GlxContext>().Set<MovieSchema>())
                .AddScoped<IQueryable<PlanetSchema>>(sp => sp.GetRequiredService<GlxContext>().Set<PlanetSchema>())
                .AddScoped<IQueryable<SpeciesSchema>>(sp => sp.GetRequiredService<GlxContext>().Set<SpeciesSchema>())
                .AddScoped<IQueryable<StarshipSchema>>(sp => sp.GetRequiredService<GlxContext>().Set<StarshipSchema>())
                .AddScoped<IQueryable<VehicleSchema>>(sp => sp.GetRequiredService<GlxContext>().Set<VehicleSchema>());
        }

        public static IServiceCollection AddQueryOutput<TSource, TResult>(this IServiceCollection services, Expression<Func<TSource, TResult>> projection) {
            return services
                .AddScoped(sp => sp.GetRequiredService<IQueryable<TSource>>().Select(projection));
        }
    }
}
