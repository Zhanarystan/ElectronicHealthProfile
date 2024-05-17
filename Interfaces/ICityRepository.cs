using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface ICityRepository
{
    Task<City> GetCity(Guid id);
    Task<IEnumerable<City>> ListCity();
    Task<bool> CreateCity(City city);
    Task<bool> UpdateCity(City city);
    Task<bool> RemoveCity(City city);
}
