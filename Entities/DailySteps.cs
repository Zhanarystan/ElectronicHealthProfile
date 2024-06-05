namespace ElectronicHealthProfile.Entities;

public class DailySteps 
{
    public Guid Id { get; set; }
    public string StudentId { get; set; }
    public int Steps { get; set; }
    public DateTime Date { get; set; }
}