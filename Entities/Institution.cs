namespace ElectronicHealthProfile.Entities;
public enum InstitutionType
{
    Undefined,
    Medical,
    Educational
}

public enum InstitutionSubType
{
    Undefined,
    Clinic,
    PolyClinic,
    School,
    University,
    College
}

public class Institution
{   
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public InstitutionType InstitutionType { get; set; }
    public InstitutionSubType InstitutionSubType { get; set; }
    public Guid CityId { get; set; }
}