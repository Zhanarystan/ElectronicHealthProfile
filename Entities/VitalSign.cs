namespace ElectronicHealthProfile.Entities;

public class VitalSign
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public double Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid MetricId { get; set; }
}