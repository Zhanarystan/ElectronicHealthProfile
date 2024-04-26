using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IUserRepository
{
    Task<AppUser> GetUser(Guid id);
    Task<IEnumerable<AppUser>> ListUser();
    Task<AppUser> CreateUser(AppUser user);
    Task<AppUser> UpdateUser(AppUser user);
    Task<int> RemoveUser(AppUser user);
}
