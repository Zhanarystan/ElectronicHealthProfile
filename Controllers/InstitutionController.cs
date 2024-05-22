using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Controllers;

public class InstitutionController : BaseApiController
{
    private readonly DataContext _context;

    public InstitutionController(DataContext context)
    {
        _context = context;    
    }

    
    [HttpGet]
    public async Task<IActionResult> List([FromQuery]string type)
    {
        
        var institutions = await _context.Institutions.Where(i => i.InstitutionType == GetInstitutionType(type)).ToListAsync();
        var institutionListDto = institutions
                                    .Select(i => 
                                        new InstitutionItemDto
                                        {
                                            Id = i.Id,
                                            Name = i.Name,
                                            Address = i.Address,
                                            InstitutionType = GetInstitutionTypeString(i.InstitutionType),
                                            InstitutionSubType = GetInstitutionSubTypeString(i.InstitutionSubType),
                                            City = _context.Cities.Find(i.CityId)
                                        });

        return HandleResult(Result<IEnumerable<InstitutionItemDto>>.Success(institutionListDto));
    }

    [HttpGet("{institutionId}/students")]
    public async Task<IActionResult> ListStudents(Guid institutionId)
    {
        var positions = await _context
                                .Positions
                                .Where(p => p.CodeName == "STUDENT" || p.CodeName == "SCHOOL_STUDENT")
                                .ToListAsync();

        var users = await _context
                            .Users
                            .Where(u => u.InstitutionId == institutionId)
                            .ToListAsync();

        var filteredUser = users.Where(u => positions.Exists(p => p.Id == u.PositionId)).ToList();

        var students = filteredUser.Select(CreateUserObject).ToList();

        return HandleResult(Result<IEnumerable<UserDto>>.Success(students));
    }

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

    private static InstitutionType GetInstitutionType(string type) 
    {
        switch (type)
        {
            case "educational":
                return InstitutionType.Educational;
            case "medical":
                return InstitutionType.Medical;
            default:
                return InstitutionType.Undefined;
        }
    }

    public static string GetInstitutionTypeString(InstitutionType type) 
    {
        switch (type)
        {
            case InstitutionType.Medical:
                return "Медицинский";
            case InstitutionType.Educational: 
                return "Образовательный";
            default:
                return "Неизвестно";
        }
    }

    public static string GetInstitutionSubTypeString(InstitutionSubType type) 
    {
        switch (type)
        {
            case InstitutionSubType.Clinic:
                return "Клиника";
            case InstitutionSubType.PolyClinic: 
                return "Поликлиника";
            case InstitutionSubType.School:
                return "Школа";
            case InstitutionSubType.University: 
                return "Университет";
            case InstitutionSubType.College: 
                return "Колледж";
            default:
                return "Неизвестно";
        }
    }
}
