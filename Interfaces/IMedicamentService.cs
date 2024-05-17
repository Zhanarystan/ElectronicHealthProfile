using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IMedicamentService
{
    Task<Result<Medicament>> GetMedicament(Guid id);
    Task<Result<IEnumerable<Medicament>>> ListMedicament();
    Task<Result<Medicament>> CreateMedicament(MedicamentCreateDto dto);
    Task<Result<Medicament>> UpdateMedicament(Guid id, MedicamentCreateDto dto);
    Task<Result<string>> RemoveMedicament(Guid id);
}
