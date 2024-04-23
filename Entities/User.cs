namespace Entities;

public enum Gender
{
    Undefined,
    Male, 
    Female
}
public class AppUser
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; } 
    public DateTime BirthDate { get; set; }
}