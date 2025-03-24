namespace DropoutCoder.StarWars.OData.Diagnostics;

using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;

public static class StarWarsODataDiagnostics {
    public static ActivitySource ActivitySource = new ActivitySource(Assembly.GetExecutingAssembly().FullName, Assembly.GetExecutingAssembly().GetName().Version.ToString());
    
    public static Meter ODataQueryMeter = new Meter(Assembly.GetExecutingAssembly().FullName);

    public static Counter<long> ODataQueryCounter = ODataQueryMeter.CreateCounter<long>("odata.query");
}
