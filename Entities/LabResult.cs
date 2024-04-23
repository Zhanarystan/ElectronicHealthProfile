

namespace Entities;

public class LabResult
{
    public Guid Id { get; set; }
    public double Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid AnalysisId  { get; set; }
    public Guid MedicalConcernId { get; set; }
}