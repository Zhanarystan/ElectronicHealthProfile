namespace ElectronicHealthProfile.DTOs;

public class LabResultSetDto 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<LabResultDto> LabResults { get; set; }

}