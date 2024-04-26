namespace ElectronicHealthProfile.Entities;

public class Metric
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string Marker { get; set; }
    public string Description { get; set; }
}