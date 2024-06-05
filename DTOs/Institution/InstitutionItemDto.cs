using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.DTOs;

public class InstitutionItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string InstitutionType { get; set; }
    public string InstitutionSubType { get; set; }
    public City City { get; set; }
}