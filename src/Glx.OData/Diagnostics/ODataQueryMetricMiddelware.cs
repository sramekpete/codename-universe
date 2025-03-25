namespace DropoutCoder.StarWars.OData.Diagnostics;

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder.Annotations;
using Microsoft.OData.UriParser;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

public class ODataQueryMetricMiddelware : IMiddleware {
    public ODataQueryMetricMiddelware([FromKeyedServices(nameof(StarWarsODataDiagnostics.ODataQueryCounter))] Counter<long> queryCounter, QueryOption) {
        QueryCounter = queryCounter ?? throw new ArgumentNullException(nameof(queryCounter));
    }

    public Counter<long> QueryCounter { get; }

    public Task InvokeAsync(HttpContext context, RequestDelegate next) {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(next);

        var batch = context.ODataBatchFeature();
        var feature = context.ODataFeature();
        var options = context.ODataOptions();

        QueryCounter.Add(1);

        return next.Invoke(context);
    }
}
}
