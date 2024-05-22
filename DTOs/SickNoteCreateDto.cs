namespace ElectronicHealthProfile.DTOs;

public class SickNoteCreateDto 
{
    public long NoteNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public string StudentId { get; set; }
    public string AbsenceReason { get; set; } // Диагноз и прочие причины отсутствия
    public DateTime AbsenceStartDate { get; set; }
    public DateTime AbsenceEndDate { get; set; }
}