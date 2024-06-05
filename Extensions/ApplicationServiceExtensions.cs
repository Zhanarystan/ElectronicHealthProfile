using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using ElectronicHealthProfile.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
namespace ElectronicHealthProfile.Extensions;
public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
          IConfiguration config)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
        });
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString("DatabaseConnection"));
        });
        services.AddCors(opt => 
        {
            opt.AddPolicy("CorsPolicy", policy => 
            {
                policy
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:3000");
            });
        });
        services.AddScoped<IUserAccessor, UserAccessor>();
        return services;
    }
}
