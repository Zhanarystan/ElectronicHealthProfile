using ElectronicHealthProfile.Constants;
using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Controllers;

    
[ApiController]
[Route("api/[controller]")]
public class SickNoteController : BaseApiController
{
    private readonly DataContext _context;

    public SickNoteController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<SickNote>> Create(SickNoteCreateDto dto) 
    {
        var sickNote = new SickNote
        {
            NoteNumber = dto.NoteNumber,
            NoteTitle = ConstantValues.SickNoteTitle,
            IssueDate = dto.IssueDate,
            StudentId = dto.StudentId,
            AbsenceReason = dto.AbsenceReason,
            AbsenceStartDate = dto.AbsenceStartDate,
            AbsenceEndDate = dto.AbsenceEndDate
        };

        _context.SickNotes.Add(sickNote);
        var saveFactor = await _context.SaveChangesAsync();

        if (saveFactor <= 0) 
            return HandleResult(Result<SickNote>.Failure(new List<string>() {  $"SickNote не создано!" }));
        return HandleResult(Result<SickNote>.Success(sickNote));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SickNote>> Get(Guid id)
    {
        var sickNote = await _context.SickNotes.FindAsync(id);
        var student = await _context.Users.FindAsync(sickNote.StudentId);
        var institution = await _context.Institutions.FindAsync(student.InstitutionId);
        
        var studentDto = new StudentItemDto
        {
            Id = Guid.Parse(student.Id),
            Email = student.Email,
            FirstName = student.FirstName,
            LastName = student.SecondName,
            MiddleName = student.MiddleName,
            BirthDate = student.BirthDate,
            InstitutionName = institution.Name
        };

        var sickNoteDto = new SickNoteItemDto
        {
            Id = sickNote.Id,
            NoteNumber = sickNote.NoteNumber,
            IssueDate = sickNote.IssueDate,
            Student = studentDto,
            AbsenceReason = "Some reason", // этот текст должно браться из Diagnosis
            AbsenceStartDate = sickNote.AbsenceStartDate,
            AbsenceEndDate = sickNote.AbsenceEndDate
        };

        return HandleResult(Result<SickNoteItemDto>.Success(sickNoteDto));
    }

    [HttpGet("student/{studentId}")]
    public async Task<ActionResult<IEnumerable<SickNote>>> ListForStudent(Guid studentId)
    {
        var student = await _context.Users.FindAsync(studentId);
        var institution = await _context.Institutions.FindAsync(student.InstitutionId);
        var sickNotes = await _context.SickNotes.Where(sn => sn.StudentId == studentId).ToListAsync();

        var studentDto = new StudentItemDto
        {
            Id = Guid.Parse(student.Id),
            Email = student.Email,
            FirstName = student.FirstName,
            LastName = student.SecondName,
            MiddleName = student.MiddleName,
            BirthDate = student.BirthDate,
            InstitutionName = institution.Name
        };
        
        var sickNoteDtoList = sickNotes
                                .Select(sn => 
                                    new SickNoteItemDto
                                    {
                                        Id = sn.Id,
                                        NoteNumber = sn.NoteNumber,
                                        IssueDate = sn.IssueDate,
                                        Student = studentDto,
                                        AbsenceReason = "Some reason", // этот текст должно браться из Diagnosis
                                        AbsenceStartDate = sn.AbsenceStartDate,
                                        AbsenceEndDate = sn.AbsenceEndDate
                                    })
                                .ToList();
        

        return HandleResult(Result<IEnumerable<SickNoteItemDto>>.Success(sickNoteDtoList));
    }
}