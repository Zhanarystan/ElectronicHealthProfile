using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Repositories;

public class AnalysisRepository : IAnalysisRepository
{
    private readonly DataContext _context;

    public AnalysisRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Analysis> CreateAnalysis(Analysis analysis)
    {
        _context.Analysis.Add(analysis);
        await _context.SaveChangesAsync();
        return analysis;
    }

    public async Task<Analysis> GetAnalysis(Guid id)
    {
        return await _context.Analysis.FindAsync(id);
    }

    public async Task<IEnumerable<Analysis>> ListAnalysis()
    {
        return await _context.Analysis.ToListAsync();
    }

    public async Task<int> RemoveAnalysis(Analysis analysis)
    {
        _context.Analysis.Remove(analysis);
        return await _context.SaveChangesAsync();
    }

    public async Task<Analysis> UpdateAnalysis(Analysis analysis)
    {
        _context.Analysis.Update(analysis);
        await _context.SaveChangesAsync();
        return analysis;
    }
}