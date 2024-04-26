using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectronicHealthProfile.DTOs;

public class RegisterDto
{   
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }

    [Required]
    public Guid? InstitutionId { get; set; }
    public DateTime BirthDate { get; set; }
    public IList<string> Roles { get; set; }
}
