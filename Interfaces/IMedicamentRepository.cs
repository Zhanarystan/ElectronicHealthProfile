using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IMedicamentRepository
{
    Task<Medicament> GetMedicament(Guid id);
    Task<IEnumerable<Medicament>> ListMedicament();
    Task<bool> CreateMedicament(Medicament medicament);
    Task<bool> UpdateMedicament(Medicament medicament);
    Task<bool> RemoveMedicament(Medicament medicament);
}
