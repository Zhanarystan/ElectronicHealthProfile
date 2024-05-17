using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Repositories;

public class VitalSignRepository : IVitalSignRepository
{
    private readonly DataContext _context;

    public VitalSignRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<bool> CreateVitalSign(VitalSign vitalSign)
    {
        _context.VitalSigns.Add(vitalSign);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<VitalSign> GetVitalSign(Guid id)
    {
        return await _context.VitalSigns.FindAsync(id);
    }

    public async Task<IEnumerable<VitalSign>> ListVitalSign()
    {
        return await _context.VitalSigns.ToListAsync();
    }

    public async Task<bool> RemoveVitalSign(VitalSign vitalSign)
    {
        _context.VitalSigns.Remove(vitalSign);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateVitalSign(VitalSign vitalSign)
    {
        _context.VitalSigns.Update(vitalSign);
        return await _context.SaveChangesAsync() > 0;
    }
}