using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface ICityService
{
    Task<Result<City>> GetCity(Guid id);
    Task<Result<IEnumerable<City>>> ListCity();
    Task<Result<City>> CreateCity(CityCreateDto dto);
    Task<Result<City>> UpdateCity(Guid id, CityCreateDto dto);
    Task<Result<string>> RemoveCity(Guid id);
}
