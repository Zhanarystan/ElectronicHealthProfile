

using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Repositories;

public class CityRepository : ICityRepository
{
    private readonly DataContext _context;

    public CityRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<bool> CreateCity(City city)
    {
        _context.Cities.Add(city);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<City> GetCity(Guid id)
    {
        return await _context.Cities.FindAsync(id);
    }

    public async Task<IEnumerable<City>> ListCity()
    {
        return await _context.Cities.ToListAsync();
    }

    public async Task<bool> RemoveCity(City city)
    {
        _context.Cities.Remove(city);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateCity(City city)
    {
        _context.Cities.Update(city);
        return await _context.SaveChangesAsync() > 0;
    }
}