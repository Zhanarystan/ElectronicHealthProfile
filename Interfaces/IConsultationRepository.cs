using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IConsultationRepository
{
    Task<Consultation> GetConsultation(Guid id);
    Task<IEnumerable<Consultation>> ListConsultation();
    Task<bool> CreateConsultation(Consultation consultation);
    Task<bool> UpdateConsultation(Consultation consultation);
    Task<int> RemoveConsultation(Consultation consultation);
}