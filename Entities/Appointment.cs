
namespace ElectronicHealthProfile.Entities;

public class Appointment
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Notes { get; set; }
    public string MedicalStaffId { get; set; }
    public string StudentId { get; set; }  
    public DateTime ConductedDate { get; set; }
}