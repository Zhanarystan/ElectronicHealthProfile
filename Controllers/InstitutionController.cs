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

    [HttpGet("educational")]
    public async Task<ActionResult<IEnumerable<InstitutionCreateDto>>> ListEducationalInstitutions()
    {
        var institutions = await _context.Institutions.Where(i => i.InstitutionType == InstitutionType.Educational).ToListAsync();
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

    public string GetInstitutionTypeString(InstitutionType type) 
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

    public string GetInstitutionSubTypeString(InstitutionSubType type) 
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
