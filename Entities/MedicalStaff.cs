namespace Entities;


public enum StaffType
{
    Undefined,
    Doctor,
    Nurse, 
    Surgeon
}

public class MedicalStaff 
{
    public Guid Id { get; set; }
    public StaffType StaffType { get; set; }   
    public Guid InstitutionId { get; set; }
    public Guid UserId { get; set; }
}