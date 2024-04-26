using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using Microsoft.EntityFrameworkCore;
namespace ElectronicHealthProfile.Repositories;
public class MetricRepository : IMetricRepository
{
    private readonly DataContext _context;

    public MetricRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Metric> CreateMetric(Metric metric)
    {
        _context.Metrics.Add(metric);
        await _context.SaveChangesAsync();
        return metric;
    }

    public async Task<Metric> GetMetric(Guid id)
    {
        return await _context.Metrics.FindAsync(id);
    }

    public async Task<IEnumerable<Metric>> ListMetric()
    {
        return await _context.Metrics.ToListAsync();
    }

    public async Task<int> RemoveMetric(Metric metric)
    {
        _context.Metrics.Remove(metric);
        return await _context.SaveChangesAsync();
    }

    public async Task<Metric> UpdateMetric(Metric metric)
    {
        _context.Metrics.Update(metric);
        await _context.SaveChangesAsync();
        return metric;
    }
}