using System.Collections.Generic;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.DTOs;

public class UserDto
{
    public string Id { get; set; }
    public string? Token { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string IIN { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string GenderName { get; set; }
    public Guid? InstitutionId { get; set; }
    public string InstitutionName { get; set; }
    public Guid PositionId { get; set; }
    public string PositionName { get; set; }
    public IList<string>? Roles { get; set; }
}
