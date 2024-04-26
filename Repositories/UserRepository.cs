using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<AppUser> CreateUser(AppUser user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<AppUser> GetUser(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<AppUser>> ListUser()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<int> RemoveUser(AppUser user)
    {
        _context.Users.Remove(user);
        return await _context.SaveChangesAsync();
    }

    public async Task<AppUser> UpdateUser(AppUser user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
