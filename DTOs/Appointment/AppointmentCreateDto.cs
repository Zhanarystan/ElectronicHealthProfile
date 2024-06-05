namespace ElectronicHealthProfile.DTOs;

public class AppointmentCreateDto
{
    public string Title { get; set; }
    public string Notes { get; set; }

    public string MedicalStaffId { get; set; }

    public string StudentId  { get; set; }
}