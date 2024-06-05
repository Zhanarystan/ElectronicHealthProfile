namespace ElectronicHealthProfile.Entities;

public class MedicalData
{
    public Guid Id { get; set; }
    public string StudentId { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public string BloodType { get; set; }  
}