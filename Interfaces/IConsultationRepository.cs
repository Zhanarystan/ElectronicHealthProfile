using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IConsultationRepository
{
    Task<Consultation> GetConsultation(Guid id);
    Task<IEnumerable<Consultation>> ListConsultation();
    Task<Consultation> CreateConsultation(Consultation consultation);
    Task<Consultation> UpdateConsultation(Consultation consultation);
    Task<int> RemoveConsultation(Consultation consultation);
}