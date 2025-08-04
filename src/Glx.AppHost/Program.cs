using Scalar.Aspire;

var builder = DistributedApplication.CreateBuilder(args);

var odata = builder
    .AddProject<Projects.Glx_OData>("glx-odata");

builder.Build().Run();
