namespace ElectronicHealthProfile.DTOs;

public class AppointmentDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Notes { get; set; }

    public UserDto MedicalStaff { get; set; }

    public UserDto Student  { get; set; }
    public DateTime ConductedDate { get; set; }
}