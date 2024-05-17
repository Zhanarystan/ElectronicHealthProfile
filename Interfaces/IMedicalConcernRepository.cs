using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IMedicalConcernRepository
{
    Task<MedicalConcern> GetMedicalConcern(Guid id);
    Task<IEnumerable<MedicalConcern>> ListMedicalConcern();
    Task<bool> CreateMedicalConcern(MedicalConcern medicalConcern);
    Task<bool> UpdateMedicalConcern(MedicalConcern medicalConcern);
    Task<bool> RemoveMedicalConcern(MedicalConcern medicalConcern);
}
