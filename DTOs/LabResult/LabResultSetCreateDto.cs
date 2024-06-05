namespace ElectronicHealthProfile.DTOs;

public class LabResultSetCreateDto
{
    public string StudentId { get; set; }
    public string Name { get; set; }
    public List<LabResultCreateDto> LabResults { get; set; }
}