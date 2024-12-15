var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.NetExamples>("netexamples");

builder.Build().Run();
