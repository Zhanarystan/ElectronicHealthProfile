using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IConsultationService
{
    Task<Result<Consultation>> GetConsultation(Guid id);
    Task<Result<IEnumerable<Consultation>>> ListConsultation();
    Task<Result<Consultation>> CreateConsultation(ConsultationCreateDto dto);
    Task<Result<Consultation>> UpdateConsultation(Guid id, ConsultationCreateDto dto);
    Task<Result<string>> RemoveConsultation(Guid id);
}