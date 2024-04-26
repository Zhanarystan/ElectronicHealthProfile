using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface ICityRepository
{
    Task<City> GetCity(Guid id);
    Task<IEnumerable<City>> ListCity();
    Task<City> CreateCity(City city);
    Task<City> UpdateCity(City city);
    Task<int> RemoveCity(City city);
}
