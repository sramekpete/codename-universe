namespace Glx.OData.Diagnostics.Extensions;

using Glx.OData.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;

public static class ServiceCollectionExtension {
    public static IServiceCollection AddODataQueryCounter(this IServiceCollection services) {
        ArgumentNullException.ThrowIfNull(services);

        return services
            .AddKeyedSingleton(nameof(StarWarsODataDiagnostics.ODataQueryCounter), StarWarsODataDiagnostics.ODataQueryCounter);
    }

    public static IServiceCollection AddODataQueryMetricMiddelware(this IServiceCollection services) {
        ArgumentNullException.ThrowIfNull(services);

        return services
            .AddTransient<ODataQueryMetricMiddelware>();
    }
}
