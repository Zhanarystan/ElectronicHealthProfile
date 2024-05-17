using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public class ConsultationService : IConsultationService
{
    private readonly IConsultationRepository _consultationRepository;
    
    public ConsultationService(IConsultationRepository consultationRepository)
    {
        _consultationRepository = consultationRepository;
    }
    public async Task<Result<Consultation>> CreateConsultation(ConsultationCreateDto dto)
    {
        var consultation = new Consultation 
        {
            Notes = dto.Notes,
            MedicalConcernId = dto.MedicalConcernId,
            DoctorId = dto.DoctorId,
            PatientId = dto.PatientId
        };

        if (!await _consultationRepository.CreateConsultation(consultation)) 
            return Result<Consultation>.Failure(new List<string>() { "Запись не создано!" });
        
        return Result<Consultation>.Success(consultation);
    }

    public async Task<Result<Consultation>> GetConsultation(Guid id)
    {
        return Result<Consultation>.Success(await _consultationRepository.GetConsultation(id));
    }

    public async Task<Result<IEnumerable<Consultation>>> ListConsultation()
    {
        return Result<IEnumerable<Consultation>>.Success(await _consultationRepository.ListConsultation());
    }

    public async Task<Result<string>> RemoveConsultation(Guid id)
    {
        var consultation = await _consultationRepository.GetConsultation(id);

        if (consultation == null)
            return Result<string>.Failure(new List<string>() { $"Consultation with {id} not found!" });

        var changeFactor = await _consultationRepository.RemoveConsultation(consultation);
        if (changeFactor <= 0)
            return Result<string>.Failure(new List<string>() { $"Consultation with {id} not deleted!" });
        return Result<string>.Success($"Consultation with {id} successfully deleted!");
    }

    public async Task<Result<Consultation>> UpdateConsultation(Guid id, ConsultationCreateDto dto)
    {
        var consultation = await _consultationRepository.GetConsultation(id);

        if (consultation == null)
            return Result<Consultation>.Failure(new List<string>() { $"Consultation with {id} not found!" });

        var updatedConsultation = new Consultation
        {
            Id = id,
            MedicalConcernId = dto.MedicalConcernId,
            DoctorId = dto.DoctorId,
            PatientId = dto.PatientId
        };

        if (! await _consultationRepository.UpdateConsultation(updatedConsultation))
            return Result<Consultation>.Failure(new List<string>() {  $"Consultation with {id} not updated!" });

        return Result<Consultation>.Success(updatedConsultation);
    }

}