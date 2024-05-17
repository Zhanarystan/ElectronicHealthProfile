namespace ElectronicHealthProfile.Entities;

public class SickNote 
{
    public Guid Id { get; set; }
    public long NoteNumber { get; set; }
    public string NoteTitle { get; set; }
    public DateTime IssueDate { get; set; }
    public Guid StudentId { get; set; }
    public string AbsenceReason { get; set; } // Диагноз и прочие причины отсутствия
    public DateTime AbsenceStartDate { get; set; }
    public DateTime AbsenceEndDate { get; set; }
}