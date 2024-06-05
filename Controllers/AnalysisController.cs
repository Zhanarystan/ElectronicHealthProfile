using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Controllers;

[ApiController]
[Route("api/analysis")]
public class AnalysisController : BaseApiController
{
    private readonly DataContext _context;
    public AnalysisController(DataContext context)
    {
        _context = context;    
    }

    [HttpGet]
    public async Task<IActionResult> List() 
    {
        var analysis = await _context.Analysis.ToListAsync();
        return HandleResult(Result<List<Analysis>>.Success(analysis));
    }
}
