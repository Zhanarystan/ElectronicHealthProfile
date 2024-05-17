using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public class AnalysisService : IAnalysisService
{
    private readonly IAnalysisRepository _analysisRepository;
    public AnalysisService(IAnalysisRepository analysisRepository)
    {
        _analysisRepository = analysisRepository;
    }

    public async Task<Result<Analysis>> CreateAnalysis(AnalysisCreateDto dto)
    {
        var analysis = new Analysis { Name = dto.Name, NormValue = dto.NormValue };

        if (!await _analysisRepository.CreateAnalysis(analysis)) 
            return Result<Analysis>.Failure(new List<string>() { "Запись не создано!" });
        
        return Result<Analysis>.Success(analysis);
    }

    public async Task<Result<Analysis>> GetAnalysis(Guid id)
    {
        return Result<Analysis>.Success(await _analysisRepository.GetAnalysis(id));
    }

    public async Task<Result<IEnumerable<Analysis>>> ListAnalysis()
    {
        return Result<IEnumerable<Analysis>>.Success(await _analysisRepository.ListAnalysis());
    }

    public async Task<Result<string>> RemoveAnalysis(Guid id)
    {
        var analysis = await _analysisRepository.GetAnalysis(id);

        if (analysis == null)
            return Result<string>.Failure(new List<string>() { $"Analysis with {id} not found!" });

        var changeFactor = await _analysisRepository.RemoveAnalysis(analysis);
        if (changeFactor <= 0)
            return Result<string>.Failure(new List<string>() { $"Analysis with {analysis.Id} not deleted!" });
        return Result<string>.Success($"Analysis with {analysis.Id} successfully deleted!");
    }

    public async Task<Result<Analysis>> UpdateAnalysis(Guid id, AnalysisCreateDto dto)
    {
        var analysis = await _analysisRepository.GetAnalysis(id);
        
        if (analysis == null)
            return Result<Analysis>.Failure(new List<string>() { $"Analysis with {id} not found!" });

        var updatedAnalysis = new Analysis
        {
            Id = id,
            Name = dto.Name,
            NormValue = dto.NormValue
        };

        if (! await _analysisRepository.UpdateAnalysis(updatedAnalysis))
            return Result<Analysis>.Failure(new List<string>() {  $"Analysis with {id} not updated!" });
        
        return Result<Analysis>.Success(updatedAnalysis);
    }
}