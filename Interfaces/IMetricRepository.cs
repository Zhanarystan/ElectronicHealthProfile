using ElectronicHealthProfile.Entities;
namespace ElectronicHealthProfile.Interfaces;

public interface IMetricRepository
{
    Task<Metric> GetMetric(Guid id);
    Task<IEnumerable<Metric>> ListMetric();
    Task<bool> CreateMetric(Metric metric);
    Task<bool> UpdateMetric(Metric metric);
    Task<bool> RemoveMetric(Metric metric);
}