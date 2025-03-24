var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DropoutCoder_StarWars_OData>("dropoutcoder-starwars-odata");

builder.Build().Run();
