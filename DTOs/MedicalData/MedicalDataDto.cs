namespace ElectronicHealthProfile.DTOs;

public class MedicalDataDto
{
    public Guid Id { get; set; }
    public UserDto Student { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public string BloodType { get; set; }  
}