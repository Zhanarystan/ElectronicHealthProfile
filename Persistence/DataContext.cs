using ElectronicHealthProfile.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ElectronicHealthProfile.Persistence;
public class DataContext : IdentityDbContext<AppUser>
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Institution> Institutions { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<SickNote> SickNotes { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Analysis> Analysis { get; set; }
    public DbSet<LabResultSet> LabResultSets { get; set; }
    public DbSet<LabResult> LabResults { get; set; }
    public DbSet<MedicalData> MedicalData { get; set; }
    public DbSet<DailySteps> DailySteps { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {
    }
}
