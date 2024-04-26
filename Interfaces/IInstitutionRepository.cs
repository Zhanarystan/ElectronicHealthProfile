using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IInstitutionRepository
{
    Task<Institution> GetInstitution(Guid id);
    Task<IEnumerable<Institution>> ListInstitution();
    Task<Institution> CreateInstitution(Institution institution);
    Task<Institution> UpdateInstitution(Institution institution);
    Task<int> RemoveInstitution(Institution institution);
}
