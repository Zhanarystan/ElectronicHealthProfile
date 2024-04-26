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
    public async Task<MedicalConcern> CreateMedicalConcern(MedicalConcern medicalConcern)
    {
        _context.MedicalConcerns.Add(medicalConcern);
        await _context.SaveChangesAsync();
        return medicalConcern;
    }

    public async Task<MedicalConcern> GetMedicalConcern(Guid id)
    {
        return await _context.MedicalConcerns.FindAsync(id);
    }

    public async Task<IEnumerable<MedicalConcern>> ListMedicalConcern()
    {
        return await _context.MedicalConcerns.ToListAsync();
    }

    public async Task<int> RemoveMedicalConcern(MedicalConcern medicalConcern)
    {
        _context.MedicalConcerns.Remove(medicalConcern);
        return await _context.SaveChangesAsync();
    }

    public async Task<MedicalConcern> UpdateMedicalConcern(MedicalConcern medicalConcern)
    {
        _context.MedicalConcerns.Update(medicalConcern);
        await _context.SaveChangesAsync();
        return medicalConcern;
    }

}
