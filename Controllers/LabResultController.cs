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
[Route("api/lab-result")]
public class LabResultController : BaseApiController
{
    private readonly DataContext _context;
    public LabResultController(DataContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> Create(LabResultSetCreateDto dto) 
    {
        var labResultSet = new LabResultSet
        {
            Name = dto.Name,
            CreatedAt = DateTime.Now,
            StudentId = dto.StudentId
        };

        _context.LabResultSets.Add(labResultSet);

        var saveFactor = await _context.SaveChangesAsync();

        var analysisIds = dto.LabResults.Select(lr => lr.AnalysisId);

        var analysis = await _context.Analysis.Where(a => analysisIds.Contains(a.Id)).ToListAsync();
        
        var labResults = dto.LabResults.Select(lr => 
            new LabResult
            {
                Value = lr.Value,
                CreatedAt = DateTime.Now,
                AnalysisId = analysis.First(a => a.Id == lr.AnalysisId).Id,
                LabResultSetId = labResultSet.Id
            }
        );

        _context.LabResults.AddRange(labResults);

        saveFactor = await _context.SaveChangesAsync();

        if (saveFactor <= 0) 
            return HandleResult(Result<LabResultSet>.Failure(new List<string>() {  $"LabResultSet не создано!" }));
        return HandleResult(Result<LabResultSet>.Success(labResultSet));
    }

    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> List(string studentId) 
    {
        var labResultSets = await _context.LabResultSets.Where(lrs => lrs.StudentId == studentId).ToListAsync();

        var labResultSetsDto = labResultSets.Select(lrs => 
            new LabResultSetDto
            {
                Id = lrs.Id,
                Name = lrs.Name,
                CreatedAt = lrs.CreatedAt
            }
        ).ToList();
        
        return HandleResult(Result<List<LabResultSetDto>>.Success(labResultSetsDto));
    }

    // [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var labResultSet = await _context.LabResultSets.FindAsync(id);

        if (labResultSet == null)
            return HandleResult(Result<LabResultSetDto>.Failure(new List<string> { "LabResultSet не найдено!" }));

        var labResults = _context.LabResults.Where(lr => lr.LabResultSetId == labResultSet.Id).ToList();

        var analysisIds = labResults.Select(lr => lr.AnalysisId).ToList();

        var analysisList = _context.Analysis.Where(a => analysisIds.Contains(a.Id)).ToList();

        var labResultsDto = labResults.Select(lr =>
        {
            var analysis = analysisList.Find(a => a.Id == lr.AnalysisId);
            return new LabResultDto
            {
                Id = lr.Id,
                AnalysisId = analysis.Id,
                AnalysisName = analysis.Name,
                Value = lr.Value,
                NormValue = analysis.NormValue,
                Unit = analysis.Unit,
                CreatedAt = lr.CreatedAt,
                LabResultSetId = lr.LabResultSetId
            };
        });

        var labResultSetDto = new LabResultSetDto
        {
            Id = labResultSet.Id,
            Name = labResultSet.Name,
            CreatedAt = labResultSet.CreatedAt,
            LabResults = labResultsDto.Where(lr => lr.LabResultSetId == labResultSet.Id).ToList()
        };

        return HandleResult(Result<LabResultSetDto>.Success(labResultSetDto));
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