using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IInstitutionRepository
{
    Task<Institution> GetInstitution(Guid id);
    Task<IEnumerable<Institution>> ListInstitution();
    Task<bool> CreateInstitution(Institution institution);
    Task<bool> UpdateInstitution(Institution institution);
    Task<int> RemoveInstitution(Institution institution);
}
