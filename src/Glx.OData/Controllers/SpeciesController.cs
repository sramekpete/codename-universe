namespace Glx.OData.Controllers {
    using Asp.Versioning;
    using Glx.Data.Schema;
    using Glx.OData.Versioning;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Query;
    using Microsoft.AspNetCore.OData.Routing.Controllers;
    using Microsoft.EntityFrameworkCore;

    public class SpeciesController(IQueryable<SpeciesSchema> Speciess) : ODataController {
        [EnableQuery]
        [ApiVersion(ApiVersions.v1_0)]
        [ApiVersion(ApiVersions.v1_1)]
        public ActionResult<IEnumerable<SpeciesSchema>> Get(ODataQueryOptions<SpeciesSchema> options) {
            //var version = options.Request.RouteValues[ApiVersions.VersionRouteParameterName];

            //StarWarsODataDiagnostics.ODataSpeciesQueryCounter.Add(1, new TagList { { nameof(version), version } });

            return Ok(Speciess);
        }

        [EnableQuery]
        [ApiVersion(ApiVersions.v1_1)]
        public async Task<ActionResult<SpeciesSchema>> Get(long key, ODataQueryOptions<SpeciesSchema> options) {
            //var version = options.Request.RouteValues[ApiVersions.VersionRouteParameterName];

            //StarWarsODataDiagnostics.ODataSpeciesDetailCounter.Add(1, new TagList { { nameof(key), key }, { nameof(version), version } });

            var result = await Speciess
                .Where(ch => ch.Id == key)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (result == null) {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
