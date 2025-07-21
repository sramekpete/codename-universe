namespace Glx.OData {
    using Asp.Versioning;
    using Glx.Data.Extensions;
    using Glx.OData.Diagnostics;
    using Glx.OData.Diagnostics.Extensions;
    using Glx.OData.Versioning;
    using Glx.ServiceDefaults;
    using Microsoft.AspNetCore.OData;
    using Microsoft.Extensions.Options;
    using Microsoft.OData.ModelBuilder;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            builder
                .AddServiceDefaults();

            builder.Services.AddOpenTelemetry()
                .WithMetrics(metric => {
                    metric
                        .AddMeter(GlxODataDiagnostics.ODataQueryMeter.Name);
                })
                .WithTracing(tracing => {
                    tracing
                        .AddSource(GlxODataDiagnostics.ActivitySource.Name);
                });

            // Add services to the container.
            builder.Services
                .AddControllers(options => {
                    options.InputFormatters.Clear();
                    options.OutputFormatters.Clear();
                })
                .AddOData(options => {
                    options
                        .SetMaxTop(null)
                        .SkipToken();

                    options.RouteOptions.EnableKeyAsSegment = true;
                    options.RouteOptions.EnableKeyInParenthesis = false;
                });

            // Add problem details
            builder.Services.AddProblemDetails();

            builder.Services
               .AddApiVersioning(options => {
                   options.DefaultApiVersion = new ApiVersion(1.0);
                   options.ReportApiVersions = true;
                   options.AssumeDefaultVersionWhenUnspecified = true;
                   options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
                   options.RouteConstraintName = ApiVersions.VersionRouteConstraintName;
               })
               .AddOData(options => {
                   options.AddRouteComponents($"api/v{{{ApiVersions.VersionRouteParameterName}:{ApiVersions.VersionRouteConstraintName}}}");
                   options.ModelBuilder.ModelBuilderFactory = () => new ODataModelBuilder();
               })
               .AddODataApiExplorer(options => {
                   // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                   // note: the specified format code will format the version as "'v'major[.minor][-status]"
                   options.GroupNameFormat = "'v'VVVV";
                   options.SubstitutionFormat = "VVVV";

                   // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                   // can also be used to control the format of the API version in route templates
                   options.SubstituteApiVersionInUrl = true;
               });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            //builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options => {
                // add a custom operation filter which sets default values
                options.OperationFilter<SwaggerDefaultValues>();

                //var fileName = typeof(Program).Assembly.GetName().Name + ".xml";
                //var filePath = Path.Combine(AppContext.BaseDirectory, fileName);

                // integrate xml comments
                //options.IncludeXmlComments(filePath);
            });

            builder.Services
                .AddDatabase(builder.Configuration["ConnectionStrings:GlxContext"]);

            builder.Services
                .AddODataQueryCounter();

            builder.Services
                .AddODataQueryMetricMiddelware();

            var app = builder.Build();

            app.MapDefaultEndpoints();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                // Send "~/$odata" to debug routing if enable the following middleware
                app.UseODataRouteDebug();

                app.UseSwagger();
                app.UseSwaggerUI(options => {
                    var descriptions = app.DescribeApiVersions();

                    // build a swagger endpoint for each discovered API version
                    foreach (var description in descriptions) {
                        var url = $"/swagger/{description.GroupName}/swagger.json";
                        var name = description.GroupName.ToUpperInvariant();
                        options.SwaggerEndpoint(url, name);
                    }
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<ODataQueryMetricMiddelware>();

            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
