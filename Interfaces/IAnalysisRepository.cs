using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IAnalysisRepository
{
    Task<Analysis> GetAnalysis(Guid id);
    Task<IEnumerable<Analysis>> ListAnalysis();
    Task<bool> CreateAnalysis(Analysis analysis);
    Task<bool> UpdateAnalysis(Analysis analysis);
    Task<int> RemoveAnalysis(Analysis analysis);
}