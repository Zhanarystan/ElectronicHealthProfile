using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface ILabResultRepository
{
    Task<LabResult> GetLabResult(Guid id);
    Task<IEnumerable<LabResult>> ListLabResult();
    Task<LabResult> CreateLabResult(LabResult labResult);
    Task<LabResult> UpdateLabResult(LabResult labResult);
    Task<int> RemoveLabResult(LabResult labResult);
}
