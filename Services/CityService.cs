using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;
    
    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }
    public async Task<Result<City>> CreateCity(CityCreateDto dto)
    {
        var city = new City 
        {
            Name = dto.Name
        };

        if (!await _cityRepository.CreateCity(city)) 
            return Result<City>.Failure(new List<string>() { "Запись не создано!" });
        
        return Result<City>.Success(city);
    }

    public async Task<Result<City>> GetCity(Guid id)
    {
        return Result<City>.Success(await _cityRepository.GetCity(id));
    }

    public async Task<Result<IEnumerable<City>>> ListCity()
    {
        return Result<IEnumerable<City>>.Success(await _cityRepository.ListCity());
    }

    public async Task<Result<string>> RemoveCity(Guid id)
    {
        var city = await _cityRepository.GetCity(id);

        if (city == null)
            return Result<string>.Failure(new List<string>() { $"City with {id} not found!" });

        if (! await _cityRepository.RemoveCity(city))
            return Result<string>.Failure(new List<string>() { $"City with {id} not deleted!" });
            
        return Result<string>.Success($"City with {id} successfully deleted!");
    }

    public async Task<Result<City>> UpdateCity(Guid id, CityCreateDto dto)
    {
        var city = await _cityRepository.GetCity(id);

        if (city == null)
            return Result<City>.Failure(new List<string>() { $"City with {id} not found!" });

        var updatedCity = new City
        {
            Id = id,
            Name = dto.Name
        };

        if (! await _cityRepository.UpdateCity(updatedCity))
            return Result<City>.Failure(new List<string>() {  $"City with {id} not updated!" });

        return Result<City>.Success(updatedCity);
    }

}

