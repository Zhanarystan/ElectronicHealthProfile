
namespace ElectronicHealthProfile.Entities;

public class Consultation
{
    public Guid Id { get; set; }
    public string Notes { get; set; }
    public Guid MedicalConcernId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }  
}