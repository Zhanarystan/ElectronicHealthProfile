namespace ElectronicHealthProfile.DTOs;

public class UserInfoDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string InstitutionName { get; set; }
    public string Position { get; set; }
}