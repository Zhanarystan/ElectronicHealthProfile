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

    public async Task<bool> CreateLabResult(LabResult labResult)
    {
        _context.LabResults.Add(labResult);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<LabResult> GetLabResult(Guid id)
    {
        return await _context.LabResults.FindAsync(id);
    }

    public async Task<IEnumerable<LabResult>> ListLabResult()
    {
        return await _context.LabResults.ToListAsync();
    }

    public async Task<bool> RemoveLabResult(LabResult labResult)
    {
        _context.LabResults.Remove(labResult);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateLabResult(LabResult labResult)
    {
        _context.LabResults.Update(labResult);
        return await _context.SaveChangesAsync() > 0;
    }

}
