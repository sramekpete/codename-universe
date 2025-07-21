namespace Glx.OData.Diagnostics;

using Microsoft.AspNetCore.OData.Extensions;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

public class ODataQueryMetricMiddelware : IMiddleware {
    public ODataQueryMetricMiddelware([FromKeyedServices(nameof(GlxODataDiagnostics.ODataQueryCounter))] Counter<long> queryCounter) {
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
