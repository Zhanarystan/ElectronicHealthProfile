using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Repositories;

public class MedicalStaffRepository : IMedicalStaffRepository
{
    private readonly DataContext _context;

    public MedicalStaffRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<MedicalStaff> CreateMedicalStaff(MedicalStaff medicalStaff)
    {
        _context.MedicalStaffs.Add(medicalStaff);
        await _context.SaveChangesAsync();
        return medicalStaff;
    }

    public async Task<MedicalStaff> GetMedicalStaff(Guid id)
    {
        return await _context.MedicalStaffs.FindAsync(id);
    }

    public async Task<IEnumerable<MedicalStaff>> ListMedicalStaff()
    {
        return await _context.MedicalStaffs.ToListAsync();
    }

    public async Task<int> RemoveMedicalStaff(MedicalStaff medicalStaff)
    {
        _context.MedicalStaffs.Remove(medicalStaff);
        return await _context.SaveChangesAsync();
    }

    public async Task<MedicalStaff> UpdateMedicalStaff(MedicalStaff medicalStaff)
    {
        _context.MedicalStaffs.Update(medicalStaff);
        await _context.SaveChangesAsync();
        return medicalStaff;
    }

}
