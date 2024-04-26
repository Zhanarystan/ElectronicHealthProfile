namespace ElectronicHealthProfile.Entities;


public class MedicalConcern
{
    public Guid Id { get; set; } 
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid PatientId { get; set; }
}