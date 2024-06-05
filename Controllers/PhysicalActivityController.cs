using ElectronicHealthProfile.Constants;
using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ElectronicHealthProfile.Controllers;

public class DailyStepsCreateDto
{
    public string StudentId { get; set; }
    public int Steps { get; set; }
}

public class PeriodicDailySteps
{
    public string StudentId { get; set; }
    public List<DailySteps> DailySteps { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class PeriodDailyStepsRequestDto 
{
    public string StudentId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; } 
}


[ApiController]
[Route("api/physical-activity")]
public class PhysicalActivityController : BaseApiController
{
    private readonly DataContext _context;
    public PhysicalActivityController(DataContext context)
    {
        _context = context;
    }
    [HttpPost("daily-steps")]
    public async Task<IActionResult> CreateOrUpdateDailySteps([FromBody] DailyStepsCreateDto dto) 
    {
        var now = DateTime.Now;
        var todaySteps = await _context.DailySteps.FirstOrDefaultAsync(ds => ds.StudentId == dto.StudentId && ds.Date.Date == now.Date);
        if (todaySteps != null)
        {
            todaySteps = new DailySteps
            {
                Id = todaySteps.Id,
                Steps = dto.Steps,
                Date = now,
                StudentId = dto.StudentId
            };
            _context.DailySteps.Update(todaySteps);
        } 
        else 
        {
            todaySteps = new DailySteps
            {
                Steps = dto.Steps,
                Date = now,
                StudentId = dto.StudentId
            };
            _context.DailySteps.Add(todaySteps);
        }

        int saveFactor = await _context.SaveChangesAsync();
        
        if (saveFactor <= 0)
            return HandleResult(Result<DailySteps>.Failure(new List<string>() {  $"MedicalData не создано!" }));

        return HandleResult(Result<DailySteps>.Success(todaySteps));
    }

    [HttpGet("grouped-daily-steps/{studentId}")]
    public async Task<IActionResult> ListDailySteps(string studentId) 
    {
        var dailyStepsList = await _context.DailySteps
                                    .Where(ds => ds.StudentId == studentId)
                                    .OrderBy(ds => ds.Date)
                                    .ToListAsync();
        if (dailyStepsList.Count == 0)
            return HandleResult(Result<List<PeriodicDailySteps>>.Success(new List<PeriodicDailySteps>()));

        var groupedDailySteps = new List<PeriodicDailySteps>();

        var dailySteps = new List<DailySteps>();
        
        var lastDailySteps = dailyStepsList[0];
        var startDailySteps = dailyStepsList[0];
        dailySteps.Add(lastDailySteps);
        for (int i = 1; i < dailyStepsList.Count; i++)
        {
            if (dailyStepsList[i].Date != lastDailySteps.Date.AddDays(1))
            {
                var period = new PeriodicDailySteps
                {
                    StudentId = studentId,
                    DailySteps = dailySteps,
                    StartDate = startDailySteps.Date,
                    EndDate = lastDailySteps.Date
                };
                groupedDailySteps.Add(period);
                lastDailySteps = dailyStepsList[i];
                startDailySteps = dailyStepsList[i];
                dailySteps = new List<DailySteps>();
                dailySteps.Add(lastDailySteps);
            }
            else 
            {
                dailySteps.Add(dailyStepsList[i]);
                lastDailySteps = dailyStepsList[i];
            }
        }

        var lastPeriod = new PeriodicDailySteps
        {
            StudentId = studentId,
            DailySteps = dailySteps,
            StartDate = startDailySteps.Date,
            EndDate = lastDailySteps.Date
        };
        groupedDailySteps.Add(lastPeriod);

        groupedDailySteps = groupedDailySteps.OrderByDescending(gds => gds.StartDate).ToList();
        
        return HandleResult(Result<List<PeriodicDailySteps>>.Success(groupedDailySteps));
    }

    [HttpGet("daily-steps/{studentId}")]
    public async Task<IActionResult> GetDailySteps(string studentId, [FromQuery]DateTime startDate, DateTime endDate) 
    {
        var dailyStepsList = await _context.DailySteps
                                    .Where(ds => ds.StudentId == studentId && ds.Date >= startDate && ds.Date <= endDate)
                                    .OrderBy(ds => ds.Date)
                                    .ToListAsync();

        if (dailyStepsList.Count == 0)
            return HandleResult(Result<List<PeriodicDailySteps>>.Success(new List<PeriodicDailySteps>()));

        var groupedDailySteps = new PeriodicDailySteps
        {
            StudentId = studentId,
            DailySteps = dailyStepsList,
            StartDate = dailyStepsList.First().Date,
            EndDate = dailyStepsList.Last().Date
        };
        
        return HandleResult(Result<PeriodicDailySteps>.Success(groupedDailySteps));
    }

    [HttpPost("grouped-daily-steps/generate-random")]
    public async Task<IActionResult> GenerateRandom()
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == "sultanova_akerke");
        var random = new Random();
        var startDate = new DateTime(2024, 5, 15);
        var endDate = new DateTime(2024, 5, 27);

        var date = startDate;
        var groupedList = new List<DailySteps>();
        while (date <= endDate)
        {
            var randomSteps = random.Next(5000, 10000);
            var dailyStepsObj = new DailySteps
            {
                StudentId = user.Id,
                Steps = randomSteps,
                Date = date
            };
            groupedList.Add(dailyStepsObj);
            date = date.AddDays(1);
        }
        _context.DailySteps.AddRange(groupedList);
        await _context.SaveChangesAsync();
        return Ok();
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