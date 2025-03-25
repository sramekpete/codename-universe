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

    public class CharacterController : ODataController {
        [EnableQuery]
        [ApiVersion(ApiVersions.v1_0)]
        [ApiVersion(ApiVersions.v1_1)]
        [ApiVersion(ApiVersions.v1_2)]
        public ActionResult<IEnumerable<CharacterSchema>> Get([FromServices] ODataQueryOptions<CharacterSchema> options, [FromServices] IQueryable<CharacterSchema> characters) {
            //var version = options.Request.RouteValues[ApiVersions.VersionRouteParameterName];

            //StarWarsODataDiagnostics.ODataCharacterQueryCounter.Add(1, new TagList { { nameof(version), version } });

            return Ok(characters);
        }

        [EnableQuery]
        [ApiVersion(ApiVersions.v1_1)]
        [ApiVersion(ApiVersions.v1_2)]
        public async Task<ActionResult<CharacterSchema>> Get(long key, ODataQueryOptions<CharacterSchema> options, [FromServices] IQueryable<CharacterSchema> characters) {
            //var version = options.Request.RouteValues[ApiVersions.VersionRouteParameterName];

            //StarWarsODataDiagnostics.ODataCharacterDetailCounter.Add(1, new TagList { { nameof(key), key }, { nameof(version), version } });

            var result = await characters
                .Where(ch => ch.Id == key)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (result == null) {
                return NotFound();
            }

            return Ok(result);
        }

        [EnableQuery]
        [ApiVersion(ApiVersions.v1_2)]
        public ActionResult<MovieSchema> GetMovies(long key, ODataQueryOptions<MovieSchema> options, [FromServices] IQueryable<MovieSchema> movies) {
            //var version = options.Request.RouteValues[ApiVersions.VersionRouteParameterName];

            //StarWarsODataDiagnostics.ODataCharacterDetailCounter.Add(1, new TagList { { nameof(key), key }, { nameof(version), version } });

            var result = movies.Where(m => m.Characters.Any(c => c.Id == key));

            if (result == null) {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
