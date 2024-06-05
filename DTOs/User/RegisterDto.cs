using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.DTOs;

public class RegisterDto
{   
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string MiddleName { get; set; }
    public string IIN { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender? Gender { get; set; } 
    public Guid? CityId { get; set; }
    public string? Address { get; set; }
    public Guid? PositionId { get; set; }    
    public Guid? InstitutionId { get; set; }
}
