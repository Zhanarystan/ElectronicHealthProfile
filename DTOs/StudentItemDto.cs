using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.DTOs;

public class StudentItemDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string InstitutionName { get; set; }
}