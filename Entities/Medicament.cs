namespace ElectronicHealthProfile.Entities;

public enum ApplicationMethod
{
    Undefined,
    Oral,
    Injection,
    ExternalUse
}

public class Medicament
{
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public ApplicationMethod ApplicationMethod { get; set; }
}