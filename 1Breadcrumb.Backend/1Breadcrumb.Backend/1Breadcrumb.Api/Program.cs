using _1Breadcrumb.Api.Middleware;
using _1Breadcrumb.Application.IoC;
using _1Breadcrumb.Infra.IoC;
using _1Breadcrumb.Infra.Persistance;
using Microsoft.OpenApi.Models;

namespace _1Breadcrumb.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        ApplicationIoC.ApplicationRegisterServices(builder.Services);
        InfraIoC.InfraRegisterServices(builder.Services);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend",
                policy => policy.WithOrigins("http://localhost:5173")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "_1Breadcrumb API", Version = "v1" });

            // API Key definition
            c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Description = "API Key needed to access the endpoints. Enter in the format: X-API-KEY: {your-api-key}",
                In = ParameterLocation.Header,
                Name = "X-API-KEY",
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        var app = builder.Build();
        
        app.UseCors("AllowFrontend");

        // Seed the database
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            DbSeeder.Seed(context);
        }
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // API Key middleware
        app.UseMiddleware<ApiKeyMiddleware>();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}