
namespace ElectronicHealthProfile.DTOs;

public class ConsultationCreateDto
{
    public string Notes { get; set; }
    public Guid MedicalConcernId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }  
}