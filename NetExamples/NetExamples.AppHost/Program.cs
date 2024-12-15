var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.NetExamples>("netexamples");

builder.AddProject<Projects.Swagger>("swagger");

builder.AddProject<Projects.SwaggerCustom>("swaggercustom");

builder.Build().Run();
