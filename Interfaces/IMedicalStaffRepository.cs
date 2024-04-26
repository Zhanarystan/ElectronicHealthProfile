using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IMedicalStaffRepository
{
    Task<MedicalStaff> GetMedicalStaff(Guid id);
    Task<IEnumerable<MedicalStaff>> ListMedicalStaff();
    Task<MedicalStaff> CreateMedicalStaff(MedicalStaff medicalStaff);
    Task<MedicalStaff> UpdateMedicalStaff(MedicalStaff medicalStaff);
    Task<int> RemoveMedicalStaff(MedicalStaff medicalStaff);
}
