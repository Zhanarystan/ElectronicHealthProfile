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
    
    public async Task<VitalSign> CreateVitalSign(VitalSign vitalSign)
    {
        _context.VitalSigns.Add(vitalSign);
        await _context.SaveChangesAsync();
        return vitalSign;
    }

    public async Task<VitalSign> GetVitalSign(Guid id)
    {
        return await _context.VitalSigns.FindAsync(id);
    }

    public async Task<IEnumerable<VitalSign>> ListVitalSign()
    {
        return await _context.VitalSigns.ToListAsync();
    }

    public async Task<int> RemoveVitalSign(VitalSign vitalSign)
    {
        _context.VitalSigns.Remove(vitalSign);
        return await _context.SaveChangesAsync();
    }

    public async Task<VitalSign> UpdateVitalSign(VitalSign vitalSign)
    {
        _context.VitalSigns.Update(vitalSign);
        await _context.SaveChangesAsync();
        return vitalSign;
    }
}