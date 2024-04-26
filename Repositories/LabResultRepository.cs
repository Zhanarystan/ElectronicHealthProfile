using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Repositories;

public class LabResultRepository : ILabResultRepository
{

    private readonly DataContext _context;

    public LabResultRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<LabResult> CreateLabResult(LabResult labResult)
    {
        _context.LabResults.Add(labResult);
        await _context.SaveChangesAsync();
        return labResult;
    }

    public async Task<LabResult> GetLabResult(Guid id)
    {
        return await _context.LabResults.FindAsync(id);
    }

    public async Task<IEnumerable<LabResult>> ListLabResult()
    {
        return await _context.LabResults.ToListAsync();
    }

    public async Task<int> RemoveLabResult(LabResult labResult)
    {
        _context.LabResults.Remove(labResult);
        return await _context.SaveChangesAsync();
    }

    public async Task<LabResult> UpdateLabResult(LabResult labResult)
    {
        _context.LabResults.Update(labResult);
        await _context.SaveChangesAsync();
        return labResult;
    }

}
