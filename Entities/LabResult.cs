

namespace ElectronicHealthProfile.Entities;

public class LabResult
{
    public Guid Id { get; set; }
    public string Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid AnalysisId  { get; set; }
    public Guid LabResultSetId { get; set; }
}