namespace ElectronicHealthProfile.DTOs;

public class SickNoteItemDto 
{
    public Guid Id { get; set; }
    public string NoteTitle { get; set; }
    public long NoteNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public UserDto Student { get; set; }
    public UserDto MedicalStaff { get; set; }
    public string AbsenceReason { get; set; } // Диагноз и прочие причины отсутствия
    public DateTime AbsenceStartDate { get; set; }
    public DateTime AbsenceEndDate { get; set; }   
}