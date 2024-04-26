using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Repositories;

public class MedicamentRepository : IMedicamentRepository
{
    private readonly DataContext _context;

    public MedicamentRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Medicament> CreateMedicament(Medicament medicament)
    {
        _context.Medicaments.Add(medicament);
        await _context.SaveChangesAsync();
        return medicament;
    }

    public async Task<Medicament> GetMedicament(Guid id)
    {
        return await _context.Medicaments.FindAsync(id);
    }

    public async Task<IEnumerable<Medicament>> ListMedicament()
    {
        return await _context.Medicaments.ToListAsync();
    }

    public async Task<int> RemoveMedicament(Medicament medicament)
    {
        _context.Medicaments.Remove(medicament);
        return await _context.SaveChangesAsync();
    }

    public async Task<Medicament> UpdateMedicament(Medicament medicament)
    {
        _context.Medicaments.Update(medicament);
        await _context.SaveChangesAsync();
        return medicament;
    }

}
