using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IMedicamentRepository
{
    Task<Medicament> GetMedicament(Guid id);
    Task<IEnumerable<Medicament>> ListMedicament();
    Task<Medicament> CreateMedicament(Medicament medicament);
    Task<Medicament> UpdateMedicament(Medicament medicament);
    Task<int> RemoveMedicament(Medicament medicament);
}
