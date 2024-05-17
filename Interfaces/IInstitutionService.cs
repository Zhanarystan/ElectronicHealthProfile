using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IInstitutionService
{
    Task<Result<Institution>> GetInstitution(Guid id);
    Task<Result<IEnumerable<Institution>>> ListInstitution();
    Task<Result<Institution>> CreateInstitution(InstitutionCreateDto dto);
    Task<Result<Institution>> UpdateInstitution(Guid id, InstitutionCreateDto dto);
    Task<Result<string>> RemoveInstitution(Guid id);
}
