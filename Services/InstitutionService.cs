using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public class InstitutionService : IInstitutionService
{
    private readonly IInstitutionRepository _institutionRepository;
    public InstitutionService(IInstitutionRepository institutionRepository)
    {
        _institutionRepository = institutionRepository;
    }

    public async Task<Result<Institution>> CreateInstitution(InstitutionCreateDto dto)
    {
        var institution = new Institution 
        {
            Name = dto.Name, 
            Address = dto.Address,
            InstitutionType = dto.InstitutionType,
            InstitutionSubType = dto.InstitutionSubType,
            CityId = dto.CityId 
        };

        if (! await _institutionRepository.CreateInstitution(institution)) 
            return Result<Institution>.Failure(new List<string>() { "Запись не создано!" });
        
        return Result<Institution>.Success(institution);
    }

    public async Task<Result<Institution>> GetInstitution(Guid id)
    {
        return Result<Institution>.Success(await _institutionRepository.GetInstitution(id));
    }

    public async Task<Result<IEnumerable<Institution>>> ListInstitution()
    {
        return Result<IEnumerable<Institution>>.Success(await _institutionRepository.ListInstitution());
    }

    public async Task<Result<string>> RemoveInstitution(Guid id)
    {
        var institution = await _institutionRepository.GetInstitution(id);

        if (institution == null)
            return Result<string>.Failure(new List<string>() { $"Institution with {id} not found!" });

        var changeFactor = await _institutionRepository.RemoveInstitution(institution);
        if (changeFactor <= 0)
            return Result<string>.Failure(new List<string>() { $"Institution with {institution.Id} not deleted!" });
        return Result<string>.Success($"Institution with {institution.Id} successfully deleted!");
    }

    public async Task<Result<Institution>> UpdateInstitution(Guid id, InstitutionCreateDto dto)
    {
        var institution = await _institutionRepository.GetInstitution(id);
        
        if (institution == null)
            return Result<Institution>.Failure(new List<string>() { $"Institution with {id} not found!" });

        var updatedInstitution = new Institution
        {
            Id = id,
            Name = dto.Name,
            Address = dto.Address,
            InstitutionType = dto.InstitutionType,
            InstitutionSubType = dto.InstitutionSubType,
            CityId = dto.CityId
        };

        if (! await _institutionRepository.UpdateInstitution(updatedInstitution))
            return Result<Institution>.Failure(new List<string>() {  $"Institution with {id} not updated!" });
        
        return Result<Institution>.Success(updatedInstitution);
    }
}
