using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;
namespace ElectronicHealthProfile.Interfaces;


public interface IVitalSignService
{
    Task<Result<VitalSign>> GetVitalSign(Guid id);
    Task<Result<IEnumerable<VitalSign>>> ListVitalSign();
    Task<Result<VitalSign>> CreateVitalSign(VitalSignCreateDto dto);
    Task<Result<VitalSign>> UpdateVitalSign(Guid id, VitalSignCreateDto dto);
    Task<Result<string>> RemoveVitalSign(Guid id);
}