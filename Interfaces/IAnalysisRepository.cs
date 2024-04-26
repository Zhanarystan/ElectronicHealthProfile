using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IAnalysisRepository
{
    Task<Analysis> GetAnalysis(Guid id);
    Task<IEnumerable<Analysis>> ListAnalysis();
    Task<Analysis> CreateAnalysis(Analysis analysis);
    Task<Analysis> UpdateAnalysis(Analysis analysis);
    Task<int> RemoveAnalysis(Analysis analysis);
}