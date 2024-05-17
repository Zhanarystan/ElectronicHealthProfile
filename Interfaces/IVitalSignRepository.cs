using ElectronicHealthProfile.Entities;
namespace ElectronicHealthProfile.Interfaces;


public interface IVitalSignRepository
{
    Task<VitalSign> GetVitalSign(Guid id);
    Task<IEnumerable<VitalSign>> ListVitalSign();
    Task<bool> CreateVitalSign(VitalSign vitalSign);
    Task<bool> UpdateVitalSign(VitalSign metric);
    Task<bool> RemoveVitalSign(VitalSign metric);
}