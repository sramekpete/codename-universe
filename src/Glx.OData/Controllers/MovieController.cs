namespace Glx.OData.Controllers {
    using Asp.Versioning;
    using Glx.Data.Schema;
    using Glx.OData.Versioning;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Query;
    using Microsoft.AspNetCore.OData.Routing.Controllers;
    using Microsoft.EntityFrameworkCore;

    public class MovieController(IQueryable<MovieSchema> Movies) : ODataController {
        [EnableQuery]
        [ApiVersion(ApiVersions.v1_0)]
        [ApiVersion(ApiVersions.v1_1)]
        public ActionResult<IEnumerable<MovieSchema>> Get(ODataQueryOptions<MovieSchema> options) {
            //var version = options.Request.RouteValues[ApiVersions.VersionRouteParameterName];

            //GlxODataDiagnostics.ODataMovieQueryCounter.Add(1, new TagList { { nameof(version), version } });

            return Ok(Movies);
        }

        [EnableQuery]
        [ApiVersion(ApiVersions.v1_1)]
        public async Task<ActionResult<MovieSchema>> Get(long key, ODataQueryOptions<MovieSchema> options) {
            //var version = options.Request.RouteValues[ApiVersions.VersionRouteParameterName];

            //GlxODataDiagnostics.ODataMovieDetailCounter.Add(1, new TagList { { nameof(key), key }, { nameof(version), version } });

            var result = await Movies
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
