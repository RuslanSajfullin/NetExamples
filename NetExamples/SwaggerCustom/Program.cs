
using CryptoAPI.Extensions;

namespace SwaggerCustom;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // Configure the API versioning properties of the project. 
        builder.Services.AddApiVersioningConfigured();
        // Add a Swagger generator and Automatic Request and Response annotations:
        builder.Services.AddSwaggerSwashbuckleConfigured();

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            // Enable middleware to serve the generated OpenAPI definition as JSON files.
            app.UseSwagger();

            // Enable middleware to serve Swagger-UI (HTML, JS, CSS, etc.) by specifying the Swagger JSON files(s).
            var descriptionProvider = app.Services.GetRequiredService<Microsoft.AspNetCore.Mvc.ApiExplorer.IApiVersionDescriptionProvider>();
            app.UseSwaggerUI(options =>
            {
                // Build a swagger endpoint for each discovered API version
                foreach (var description in descriptionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
        }



        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
