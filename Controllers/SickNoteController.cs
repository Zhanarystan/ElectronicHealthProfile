using ElectronicHealthProfile.Constants;
using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Controllers;

    
[ApiController]
[Route("api/sick-note")]
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

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<SickNote>> Get(Guid id)
    {
        var sickNote = await _context.SickNotes.FindAsync(id);
        var student = await _context.Users.FindAsync(sickNote.StudentId);
        var medicalStaff = await _context.Users.FindAsync(sickNote.MedicalStaffId);
        var studentDto = CreateUserDto(student);
        var medicalStaffDto = CreateUserDto(medicalStaff);

        var sickNoteDto = new SickNoteItemDto
        {
            Id = sickNote.Id,
            NoteTitle = sickNote.NoteTitle,
            NoteNumber = sickNote.NoteNumber,
            IssueDate = sickNote.IssueDate,
            Student = studentDto,
            MedicalStaff = medicalStaffDto,
            AbsenceReason = sickNote.AbsenceReason, // этот текст должно браться из Diagnosis
            AbsenceStartDate = sickNote.AbsenceStartDate,
            AbsenceEndDate = sickNote.AbsenceEndDate
        };

        return HandleResult(Result<SickNoteItemDto>.Success(sickNoteDto));
    }

    private UserDto CreateUserDto(AppUser user) 
    {
        var position = _context.Positions.Find(user.PositionId);
        var institution =  _context.Institutions.Find(user.InstitutionId);
        return new UserDto
        {
            Id = user.Id,
            Token = "",
            Username = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            IIN = user.IIN,
            BirthDate = user.BirthDate,
            Gender = (Gender)user.Gender,
            GenderName = user.Gender == Gender.Male ? "Мужской" : "Женский",
            InstitutionId = user.InstitutionId,
            InstitutionName = institution.Name,
            PositionId = user.PositionId,
            PositionName = position.Name,
            Roles = new List<string>()
        };
    }
}