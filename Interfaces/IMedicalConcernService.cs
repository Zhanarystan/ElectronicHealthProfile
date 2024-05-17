using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IMedicalConcernService
{
    Task<Result<MedicalConcern>> GetMedicalConcern(Guid id);
    Task<Result<IEnumerable<MedicalConcern>>> ListMedicalConcern();
    Task<Result<MedicalConcern>> CreateMedicalConcern(MedicalConcernCreateDto dto);
    Task<Result<MedicalConcern>> UpdateMedicalConcern(Guid id, MedicalConcernCreateDto dto);
    Task<Result<string>> RemoveMedicalConcern(Guid id);
}
