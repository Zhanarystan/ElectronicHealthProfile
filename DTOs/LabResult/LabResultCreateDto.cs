namespace ElectronicHealthProfile.DTOs;

public class LabResultCreateDto
{
    public string Value { get; set; }
    public Guid AnalysisId  { get; set; }
    public Guid LabResultSetId { get; set; }
}