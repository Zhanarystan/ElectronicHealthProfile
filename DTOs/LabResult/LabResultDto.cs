namespace ElectronicHealthProfile.DTOs;

public class LabResultDto 
{
    public Guid Id { get; set; }
    public Guid AnalysisId { get; set; }
    public string AnalysisName { get; set; }
    public string Value { get; set; }
    public string NormValue { get; set; }
    public string Unit { get; set; }   
    public DateTime CreatedAt { get; set; } 
    public Guid LabResultSetId { get; set; }
}