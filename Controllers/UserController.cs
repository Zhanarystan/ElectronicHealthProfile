using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Controllers;

public class UserController : BaseApiController
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;    
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id) 
    {
        var student = await _context.Users.FindAsync(id);
        var studentDto = CreateUserObject(student);
        return HandleResult(Result<UserDto>.Success(studentDto));
    }  


    [Authorize]
    [HttpGet("{studentId}/sick-notes")]
    public async Task<IActionResult> ListForStudent(string studentId)
    {
        var student = await _context.Users.FindAsync(studentId);

        var sickNotes = await _context
                                .SickNotes
                                .Where(sn => sn.StudentId == studentId)
                                .OrderByDescending(sn => sn.IssueDate)
                                .ToListAsync();

        var studentInfoDto = CreateUserObject(student);
        
        var sickNoteDtoList = sickNotes
                                .Select(sn => 
                                    new SickNoteItemDto
                                    {
                                        Id = sn.Id,
                                        NoteNumber = sn.NoteNumber,
                                        IssueDate = sn.IssueDate,
                                        Student = studentInfoDto,
                                        MedicalStaff = CreateUserObject(_context.Users.Find(sn.MedicalStaffId)),
                                        AbsenceReason = sn.AbsenceReason, // этот текст должно браться из Diagnosis
                                        AbsenceStartDate = sn.AbsenceStartDate,
                                        AbsenceEndDate = sn.AbsenceEndDate
                                    })
                                .ToList();
        
        return HandleResult(Result<IEnumerable<SickNoteItemDto>>.Success(sickNoteDtoList));
    }

    // private static InstitutionType GetInstitutionType(string type) 
    // {
    //     switch (type)
    //     {
    //         case "educational":
    //             return InstitutionType.Educational;
    //         case "medical":
    //             return InstitutionType.Medical;
    //         default:
    //             return InstitutionType.Undefined;
    //     }
    // }

    // public static string GetInstitutionTypeString(InstitutionType type) 
    // {
    //     switch (type)
    //     {
    //         case InstitutionType.Medical:
    //             return "Медицинский";
    //         case InstitutionType.Educational: 
    //             return "Образовательный";
    //         default:
    //             return "Неизвестно";
    //     }
    // }

    // public static string GetInstitutionSubTypeString(InstitutionSubType type) 
    // {
    //     switch (type)
    //     {
    //         case InstitutionSubType.Clinic:
    //             return "Клиника";
    //         case InstitutionSubType.PolyClinic: 
    //             return "Поликлиника";
    //         case InstitutionSubType.School:
    //             return "Школа";
    //         case InstitutionSubType.University: 
    //             return "Университет";
    //         case InstitutionSubType.College: 
    //             return "Колледж";
    //         default:
    //             return "Неизвестно";
    //     }
    // }

    private UserDto CreateUserObject(AppUser user)
    {
        var position = _context.Positions.Find(user.PositionId);
        var institution = _context.Institutions.Find(user.InstitutionId);
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
