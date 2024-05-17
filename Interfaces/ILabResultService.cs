using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface ILabResultService
{
    Task<Result<LabResult>> GetLabResult(Guid id);
    Task<Result<IEnumerable<LabResult>>> ListLabResult();
    Task<Result<LabResult>> CreateLabResult(LabResultCreateDto dto);
    Task<Result<LabResult>> UpdateLabResult(Guid id, LabResultCreateDto dto);
    Task<Result<string>> RemoveLabResult(Guid id);
}
