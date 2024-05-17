using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.DTOs;

public class MedicamentCreateDto
{
    public string Name { get; set; }
    public ApplicationMethod ApplicationMethod { get; set; }
}