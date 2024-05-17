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
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string MiddleName { get; set; }
    public string IIN { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender? Gender { get; set; } 
    public Guid? CityId { get; set; }
    public string? Address { get; set; }
    public UserType? UserType { get; set; }    
    public Guid? InstitutionId { get; set; }
}