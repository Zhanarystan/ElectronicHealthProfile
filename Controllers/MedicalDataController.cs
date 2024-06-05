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
[Route("api/medical-data")]
public class MedicalDataController : BaseApiController
{
    private readonly DataContext _context;
    public MedicalDataController(DataContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> Create(MedicalDataCreateDto dto) 
    {
        var medicalData = new MedicalData
        {
            StudentId = dto.StudentId,
            Weight = dto.Weight,
            Height = dto.Height,
            BloodType = dto.BloodType
        };

        _context.MedicalData.Add(medicalData);

        var saveFactor = await _context.SaveChangesAsync();

        if (saveFactor <= 0) 
            return HandleResult(Result<MedicalData>.Failure(new List<string>() {  $"MedicalData не создано!" }));
        return HandleResult(Result<MedicalData>.Success(medicalData));
    }

    [HttpGet("{studentId}")]
    public async Task<IActionResult> Get(string studentId) 
    {

        var medicalData = await _context.MedicalData.Where(m => m.StudentId == studentId).FirstAsync();

        var student = await _context.Users.FindAsync(studentId);

        var medicalDataDto = new MedicalDataDto
        {
            Id = medicalData.Id,
            Student = CreateUserDto(student),
            Weight = medicalData.Weight,
            Height = medicalData.Height,
            BloodType = medicalData.BloodType
        };

        return HandleResult(Result<MedicalDataDto>.Success(medicalDataDto));
    }

    [HttpPut("{studentId}")]
    public async Task<IActionResult> Update(string studentId, [FromBody] MedicalDataCreateDto dto) 
    {
        var medicalData = await _context.MedicalData.FindAsync(studentId);

        medicalData = new MedicalData
        {
            Id = medicalData.Id,
            StudentId = medicalData.StudentId,
            Weight = dto.Weight,
            Height = dto.Height,
            BloodType = dto.BloodType
        };

        _context.MedicalData.Update(medicalData);
        var saveFactor = await _context.SaveChangesAsync();

        if (saveFactor <= 0) 
            return HandleResult(Result<MedicalData>.Failure(new List<string>() {  $"MedicalData не обновлено!" }));
        return HandleResult(Result<MedicalData>.Success(medicalData));
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