using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public class LabResultService : ILabResultService
{
    private readonly ILabResultRepository _LabResultRepository;
    
    public LabResultService(ILabResultRepository LabResultRepository)
    {
        _LabResultRepository = LabResultRepository;
    }
    public async Task<Result<LabResult>> CreateLabResult(LabResultCreateDto dto)
    {
        var labResult = new LabResult 
        {
            Value = dto.Value,
            CreatedAt = DateTime.Now,
            AnalysisId = dto.AnalysisId
        };

        if (!await _LabResultRepository.CreateLabResult(labResult)) 
            return Result<LabResult>.Failure(new List<string>() { "Запись не создано!" });
        
        return Result<LabResult>.Success(labResult);
    }

    public async Task<Result<LabResult>> GetLabResult(Guid id)
    {
        return Result<LabResult>.Success(await _LabResultRepository.GetLabResult(id));
    }

    public async Task<Result<IEnumerable<LabResult>>> ListLabResult()
    {
        return Result<IEnumerable<LabResult>>.Success(await _LabResultRepository.ListLabResult());
    }

    public async Task<Result<string>> RemoveLabResult(Guid id)
    {
        var labResult = await _LabResultRepository.GetLabResult(id);

        if (labResult == null)
            return Result<string>.Failure(new List<string>() { $"LabResult with {id} not found!" });

        if (! await _LabResultRepository.RemoveLabResult(labResult))
            return Result<string>.Failure(new List<string>() { $"LabResult with {id} not deleted!" });
            
        return Result<string>.Success($"LabResult with {id} successfully deleted!");
    }

    public async Task<Result<LabResult>> UpdateLabResult(Guid id, LabResultCreateDto dto)
    {
        var labResult = await _LabResultRepository.GetLabResult(id);

        if (labResult == null)
            return Result<LabResult>.Failure(new List<string>() { $"LabResult with {id} not found!" });

        var updatedLabResult = new LabResult
        {
            Id = id,
            Value = dto.Value,
            CreatedAt = labResult.CreatedAt,
            AnalysisId = labResult.AnalysisId
        };

        if (! await _LabResultRepository.UpdateLabResult(updatedLabResult))
            return Result<LabResult>.Failure(new List<string>() {  $"LabResult with {id} not updated!" });

        return Result<LabResult>.Success(updatedLabResult);
    }
}
