using ElectronicHealthProfile.Middleware;
using ElectronicHealthProfile.Extensions;
using ElectronicHealthProfile.Persistence;
using Microsoft.AspNetCore.Identity;
using ElectronicHealthProfile.Entities;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var _config = builder.Configuration;
builder.Services.AddApplicationServices(_config);
builder.Services.AddIdentityServices(_config);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
var services = builder.Services.BuildServiceProvider();
try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(context, userManager, roleManager);
    await Seed.SeedData(context);
} 
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}
app.Run();
