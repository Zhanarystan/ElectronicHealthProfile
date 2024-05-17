

namespace ElectronicHealthProfile.Entities;

public class LabResultSet
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid MedicalConcernId { get; set; }
}