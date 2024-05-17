namespace ElectronicHealthProfile.DTOs;

public class MedicalConcernCreateDto
{
    public string Description { get; set; }
    public Guid PatientId { get; set; }
}