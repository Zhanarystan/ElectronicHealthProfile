using System.Collections.Generic;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.DTOs;

public class UserDto
{
    public string Token { get; set; }
    public string Username { get; set; }
    public Guid? InstitutionId { get; set; }
    public UserType UserType { get; set; }
    public IList<string> Roles { get; set; }
}
