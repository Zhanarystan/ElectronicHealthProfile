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

        //Repository register
        services.AddScoped<IUserAccessor, UserAccessor>();
        // services.AddScoped<IPhotoAccessor, PhotoAccessor>();
        // services.AddScoped<IAnalysisRepository, AnalysisRepository>();
        // services.AddScoped<ICityRepository, CityRepository>();
        // services.AddScoped<IConsultationRepository, ConsultationRepository>();
        // services.AddScoped<IUserRepository, UserRepository>();
        // services.AddScoped<IInstitutionRepository, InstitutionRepository>();
        // services.AddScoped<IAnalysisRepository, AnalysisRepository>();
        // services.AddScoped<ILabResultRepository, LabResultRepository>();
        // services.AddScoped<IMedicalConcernRepository, MedicalConcernRepository>();
        // services.AddScoped<IMedicamentRepository, MedicamentRepository>();
        // services.AddScoped<IVitalSignRepository, VitalSignRepository>();
        // services.AddScoped<IMetricRepository, MetricRepository>();

        //Service register
        // services.AddScoped<IConsultationService, ConsultationService>();
        // services.AddScoped<IUserService, UserService>();
        // services.AddScoped<IInstitutionService, InstitutionService>();
        // services.AddScoped<IAnalysisService, AnalysisService>();
        // services.AddScoped<IServiceService, ServiceService>();
        // services.AddScoped<ILabResultService, LabResultService>();
        // services.AddScoped<IMetricService, MetricService>();

        // services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        // services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));
        // services.AddSignalR();        
        return services;
    }
}
