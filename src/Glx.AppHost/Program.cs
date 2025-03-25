var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Glx_OData>("glx-odata");

builder.Build().Run();
