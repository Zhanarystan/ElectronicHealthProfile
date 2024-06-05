using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.DTOs;

public class InstitutionCreateDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public InstitutionType InstitutionType { get; set; }
    public InstitutionSubType InstitutionSubType { get; set; }
    public Guid CityId { get; set; }
}