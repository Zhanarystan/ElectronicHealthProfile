using Microsoft.AspNetCore.Identity;

namespace ElectronicHealthProfile.Entities;

public enum Gender
{
    Undefined,
    Male, 
    Female
}

public enum UserType
{
    Undefined,
    Admin,
    InstitutionAdmin,
    Doctor,
    Nurse, 
    Surgeon,
    UniversityStudent,
    SchoolStudent
}

public class AppUser : IdentityUser
{
    public string? FullName { get; set; }
    public Gender? Gender { get; set; } 
    public UserType? UserType { get; set; }
    public DateTime? BirthDate { get; set; }
    public Guid? InstitutionId { get; set; }
}