using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public class MedicalConcernService : IMedicalConcernService
{
    private readonly IMedicalConcernRepository _medicalConcernRepository;
    
    public MedicalConcernService(IMedicalConcernRepository MedicalConcernRepository)
    {
        _medicalConcernRepository = MedicalConcernRepository;
    }
    public async Task<Result<MedicalConcern>> CreateMedicalConcern(MedicalConcernCreateDto dto)
    {
        var medicalConcern = new MedicalConcern 
        {
            Description = dto.Description,
            CreatedAt = DateTime.Now,
            PatientId = dto.PatientId
        };

        if (!await _medicalConcernRepository.CreateMedicalConcern(medicalConcern)) 
            return Result<MedicalConcern>.Failure(new List<string>() { "Запись не создано!" });
        
        return Result<MedicalConcern>.Success(medicalConcern);
    }

    public async Task<Result<MedicalConcern>> GetMedicalConcern(Guid id)
    {
        return Result<MedicalConcern>.Success(await _medicalConcernRepository.GetMedicalConcern(id));
    }

    public async Task<Result<IEnumerable<MedicalConcern>>> ListMedicalConcern()
    {
        return Result<IEnumerable<MedicalConcern>>.Success(await _medicalConcernRepository.ListMedicalConcern());
    }

    public async Task<Result<string>> RemoveMedicalConcern(Guid id)
    {
        var medicalConcern = await _medicalConcernRepository.GetMedicalConcern(id);

        if (medicalConcern == null)
            return Result<string>.Failure(new List<string>() { $"MedicalConcern with {id} not found!" });

        if (! await _medicalConcernRepository.RemoveMedicalConcern(medicalConcern))
            return Result<string>.Failure(new List<string>() { $"MedicalConcern with {id} not deleted!" });
            
        return Result<string>.Success($"MedicalConcern with {id} successfully deleted!");
    }

    public async Task<Result<MedicalConcern>> UpdateMedicalConcern(Guid id, MedicalConcernCreateDto dto)
    {
        var medicalConcern = await _medicalConcernRepository.GetMedicalConcern(id);

        if (medicalConcern == null)
            return Result<MedicalConcern>.Failure(new List<string>() { $"MedicalConcern with {id} not found!" });

        var updatedMedicalConcern = new MedicalConcern
        {
            Id = id,
            Description = dto.Description,
            CreatedAt = medicalConcern.CreatedAt,
            PatientId = medicalConcern.PatientId
        };

        if (! await _medicalConcernRepository.UpdateMedicalConcern(updatedMedicalConcern))
            return Result<MedicalConcern>.Failure(new List<string>() {  $"MedicalConcern with {id} not updated!" });

        return Result<MedicalConcern>.Success(updatedMedicalConcern);
    }
}
