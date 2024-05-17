using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;
namespace ElectronicHealthProfile.Interfaces;

public class MetricService : IMetricService
{
    private readonly IMetricRepository _metricRepository;
    
    public MetricService(IMetricRepository MetricRepository)
    {
        _metricRepository = MetricRepository;
    }
    public async Task<Result<Metric>> CreateMetric(MetricCreateDto dto)
    {
        var metric = new Metric 
        {
            Name = dto.Name,
            Marker = dto.Marker,
            Description = dto.Description
        };

        if (!await _metricRepository.CreateMetric(metric)) 
            return Result<Metric>.Failure(new List<string>() { "Запись не создано!" });
        
        return Result<Metric>.Success(metric);
    }

    public async Task<Result<Metric>> GetMetric(Guid id)
    {
        return Result<Metric>.Success(await _metricRepository.GetMetric(id));
    }

    public async Task<Result<IEnumerable<Metric>>> ListMetric()
    {
        return Result<IEnumerable<Metric>>.Success(await _metricRepository.ListMetric());
    }

    public async Task<Result<string>> RemoveMetric(Guid id)
    {
        var metric = await _metricRepository.GetMetric(id);

        if (metric == null)
            return Result<string>.Failure(new List<string>() { $"Metric with {id} not found!" });

        if (! await _metricRepository.RemoveMetric(metric))
            return Result<string>.Failure(new List<string>() { $"Metric with {id} not deleted!" });
            
        return Result<string>.Success($"Metric with {id} successfully deleted!");
    }

    public async Task<Result<Metric>> UpdateMetric(Guid id, MetricCreateDto dto)
    {
        var metric = await _metricRepository.GetMetric(id);

        if (metric == null)
            return Result<Metric>.Failure(new List<string>() { $"Metric with {id} not found!" });

        var updatedMetric = new Metric
        {
            Id = id,
            Name = dto.Name,
            Marker = dto.Marker,
            Description = dto.Description
        };

        if (! await _metricRepository.UpdateMetric(updatedMetric))
            return Result<Metric>.Failure(new List<string>() {  $"Metric with {id} not updated!" });

        return Result<Metric>.Success(updatedMetric);
    }
}