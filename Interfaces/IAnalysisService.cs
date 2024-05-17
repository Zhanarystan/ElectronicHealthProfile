using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IAnalysisService
{
    Task<Result<Analysis>> GetAnalysis(Guid id);
    Task<Result<IEnumerable<Analysis>>> ListAnalysis();
    Task<Result<Analysis>> CreateAnalysis(AnalysisCreateDto dto);
    Task<Result<Analysis>> UpdateAnalysis(Guid id, AnalysisCreateDto dto);
    Task<Result<string>> RemoveAnalysis(Guid id);
}