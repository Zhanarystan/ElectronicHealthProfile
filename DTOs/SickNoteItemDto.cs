namespace ElectronicHealthProfile.DTOs;

public class SickNoteItemDto 
{
    public Guid Id { get; set; }
    public long NoteNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public StudentItemDto Student { get; set; }
    public string AbsenceReason { get; set; } // Диагноз и прочие причины отсутствия
    public DateTime AbsenceStartDate { get; set; }
    public DateTime AbsenceEndDate { get; set; }
}