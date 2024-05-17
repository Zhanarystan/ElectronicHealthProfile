using ElectronicHealthProfile.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Persistence;

public class DataContext : IdentityDbContext<AppUser>
{
    public DbSet<Analysis> Analysis { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<Institution> Institutions { get; set; }
    public DbSet<LabResult> LabResults { get; set; }
    public DbSet<LabResultSet> LabResultSet { get; set; }
    public DbSet<MedicalConcern> MedicalConcerns { get; set; }
    public DbSet<MedicalStaff> MedicalStaffs { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Metric> Metrics { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<VitalSign> VitalSigns { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<SickNote> SickNotes { get; set; }


    public DataContext(DbContextOptions options) : base(options)
    {

    }
}
