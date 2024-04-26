using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Repositories;
public class InstitutionRepository : IInstitutionRepository
{

    private readonly DataContext _context;

    public InstitutionRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Institution> CreateInstitution(Institution institution)
    {
        _context.Institutions.Add(institution);
        await _context.SaveChangesAsync();
        return institution;
    }

    public async Task<Institution> GetInstitution(Guid id)
    {
        return await _context.Institutions.FindAsync(id);;
    }

    public async Task<IEnumerable<Institution>> ListInstitution()
    {
        return await _context.Institutions.ToListAsync();
    }

    public async Task<int> RemoveInstitution(Institution institution)
    {
        _context.Institutions.Remove(institution);
        return await _context.SaveChangesAsync();
    }

    public async Task<Institution> UpdateInstitution(Institution institution)
    {
        _context.Institutions.Update(institution);
        await _context.SaveChangesAsync();
        return institution;
    }
}
