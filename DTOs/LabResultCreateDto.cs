namespace ElectronicHealthProfile.DTOs;

public class LabResultCreateDto
{
    public double Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid AnalysisId  { get; set; }
    public Guid LabResultSetId { get; set; }
}