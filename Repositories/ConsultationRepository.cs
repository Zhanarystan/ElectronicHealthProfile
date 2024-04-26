using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Repositories;

public class ConsultationRepository : IConsultationRepository
{

    private readonly DataContext _context;

    public ConsultationRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Consultation> CreateConsultation(Consultation consultation)
    {
        _context.Consultations.Add(consultation);
        await _context.SaveChangesAsync();
        return consultation;
    }

    public async Task<Consultation> GetConsultation(Guid id)
    {
        return await _context.Consultations.FindAsync(id);
    }

    public async Task<IEnumerable<Consultation>> ListConsultation()
    {
        return await _context.Consultations.ToListAsync();
    }

    public async Task<int> RemoveConsultation(Consultation consultation)
    {
        _context.Consultations.Remove(consultation);
        return await _context.SaveChangesAsync();
    }

    public async Task<Consultation> UpdateConsultation(Consultation consultation)
    {
        _context.Consultations.Update(consultation);
        await _context.SaveChangesAsync();
        return consultation;
    }
}