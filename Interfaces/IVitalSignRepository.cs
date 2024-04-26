using ElectronicHealthProfile.Entities;
namespace ElectronicHealthProfile.Interfaces;


public interface IVitalSignRepository
{
    Task<VitalSign> GetVitalSign(Guid id);
    Task<IEnumerable<VitalSign>> ListVitalSign();
    Task<VitalSign> CreateVitalSign(VitalSign vitalSign);
    Task<VitalSign> UpdateVitalSign(VitalSign metric);
    Task<int> RemoveVitalSign(VitalSign metric);
}