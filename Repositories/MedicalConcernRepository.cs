using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Repositories;
public class MedicalConcernRepository : IMedicalConcernRepository
{
    private readonly DataContext _context;

    public MedicalConcernRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateMedicalConcern(MedicalConcern medicalConcern)
    {
        _context.MedicalConcerns.Add(medicalConcern);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<MedicalConcern> GetMedicalConcern(Guid id)
    {
        return await _context.MedicalConcerns.FindAsync(id);
    }

    public async Task<IEnumerable<MedicalConcern>> ListMedicalConcern()
    {
        return await _context.MedicalConcerns.ToListAsync();
    }

    public async Task<bool> RemoveMedicalConcern(MedicalConcern medicalConcern)
    {
        _context.MedicalConcerns.Remove(medicalConcern);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateMedicalConcern(MedicalConcern medicalConcern)
    {
        _context.MedicalConcerns.Update(medicalConcern);
        return await _context.SaveChangesAsync() > 0;
    }

}
