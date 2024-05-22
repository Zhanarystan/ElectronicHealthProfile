using Microsoft.AspNetCore.Identity;

namespace ElectronicHealthProfile.Entities;

public enum Gender
{
    Undefined,
    Male, 
    Female
}

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string IIN { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender? Gender { get; set; } 
    public Guid? CityId { get; set; }
    public string? Address { get; set; }
    public Guid PositionId { get; set; }    
    public Guid? InstitutionId { get; set; }
}