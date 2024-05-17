using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface ILabResultRepository
{
    Task<LabResult> GetLabResult(Guid id);
    Task<IEnumerable<LabResult>> ListLabResult();
    Task<bool> CreateLabResult(LabResult labResult);
    Task<bool> UpdateLabResult(LabResult labResult);
    Task<bool> RemoveLabResult(LabResult labResult);
}
