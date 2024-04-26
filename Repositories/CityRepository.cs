

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
    
    public async Task<City> CreateCity(City city)
    {
        _context.Cities.Add(city);
        await _context.SaveChangesAsync();
        return city;
    }

    public async Task<City> GetCity(Guid id)
    {
        return await _context.Cities.FindAsync(id);
    }

    public async Task<IEnumerable<City>> ListCity()
    {
        return await _context.Cities.ToListAsync();
    }

    public async Task<int> RemoveCity(City city)
    {
        _context.Cities.Remove(city);
        return await _context.SaveChangesAsync();
    }

    public async Task<City> UpdateCity(City city)
    {
        _context.Cities.Update(city);
        await _context.SaveChangesAsync();
        return city;
    }
}