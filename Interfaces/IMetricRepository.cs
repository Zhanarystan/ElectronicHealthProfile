using ElectronicHealthProfile.Entities;
namespace ElectronicHealthProfile.Interfaces;

public interface IMetricRepository
{
    Task<Metric> GetMetric(Guid id);
    Task<IEnumerable<Metric>> ListMetric();
    Task<Metric> CreateMetric(Metric metric);
    Task<Metric> UpdateMetric(Metric metric);
    Task<int> RemoveMetric(Metric metric);
}