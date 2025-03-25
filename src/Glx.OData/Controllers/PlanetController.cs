namespace DropoutCoder.StarWars.OData.Controllers {
    using Asp.Versioning;
    using DropoutCoder.StarWars.Data.Schema;
    using DropoutCoder.StarWars.OData.Diagnostics;
    using DropoutCoder.StarWars.OData.Versioning;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Query;
    using Microsoft.AspNetCore.OData.Routing.Controllers;
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics;

    public class PlanetController(IQueryable<PlanetSchema> Planets) : ODataController {
        [EnableQuery]
        [ApiVersion(ApiVersions.v1_0)]
        [ApiVersion(ApiVersions.v1_1)]
        public ActionResult<IEnumerable<PlanetSchema>> Get(ODataQueryOptions<PlanetSchema> options) {
            //var version = options.Request.RouteValues[ApiVersions.VersionRouteParameterName];

            //StarWarsODataDiagnostics.ODataPlanetQueryCounter.Add(1, new TagList { { nameof(version), version } });

            return Ok(Planets);
        }

        [EnableQuery]
        [ApiVersion(ApiVersions.v1_1)]
        public async Task<ActionResult<PlanetSchema>> Get(long key, ODataQueryOptions<PlanetSchema> options) {
            //var version = options.Request.RouteValues[ApiVersions.VersionRouteParameterName];

            //StarWarsODataDiagnostics.ODataPlanetDetailCounter.Add(1, new TagList { { nameof(key), key }, { nameof(version), version } });

            var result = await Planets.Where(ch => ch.Id == key).SingleOrDefaultAsync();

            if (result == null) {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
