using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;
namespace ElectronicHealthProfile.Interfaces;

public interface IMetricService
{
    Task<Result<Metric>> GetMetric(Guid id);
    Task<Result<IEnumerable<Metric>>> ListMetric();
    Task<Result<Metric>> CreateMetric(MetricCreateDto dto);
    Task<Result<Metric>> UpdateMetric(Guid id, MetricCreateDto dto);
    Task<Result<string>> RemoveMetric(Guid id);
}