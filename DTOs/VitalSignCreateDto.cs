namespace ElectronicHealthProfile.DTOs;

public class VitalSignCreateDto
{
    public string Name { get; set; } 
    public double Value { get; set; }
    public Guid MetricId { get; set; }
}