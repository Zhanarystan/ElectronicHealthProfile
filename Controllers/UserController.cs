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
