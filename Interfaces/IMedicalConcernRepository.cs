using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IMedicalConcernRepository
{
    Task<MedicalConcern> GetMedicalConcern(Guid id);
    Task<IEnumerable<MedicalConcern>> ListMedicalConcern();
    Task<MedicalConcern> CreateMedicalConcern(MedicalConcern medicalConcern);
    Task<MedicalConcern> UpdateMedicalConcern(MedicalConcern medicalConcern);
    Task<int> RemoveMedicalConcern(MedicalConcern medicalConcern);
}
