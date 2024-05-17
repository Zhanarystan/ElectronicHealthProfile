using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public class MedicamentService : IMedicamentService
{
    private readonly IMedicamentRepository _medicamentRepository;
    
    public MedicamentService(IMedicamentRepository medicamentRepository)
    {
        _medicamentRepository = medicamentRepository;
    }
    public async Task<Result<Medicament>> CreateMedicament(MedicamentCreateDto dto)
    {
        var medicament = new Medicament 
        {
            Name = dto.Name,
            ApplicationMethod = dto.ApplicationMethod
        };

        if (!await _medicamentRepository.CreateMedicament(medicament)) 
            return Result<Medicament>.Failure(new List<string>() { "Запись не создано!" });
        
        return Result<Medicament>.Success(medicament);
    }

    public async Task<Result<Medicament>> GetMedicament(Guid id)
    {
        return Result<Medicament>.Success(await _medicamentRepository.GetMedicament(id));
    }

    public async Task<Result<IEnumerable<Medicament>>> ListMedicament()
    {
        return Result<IEnumerable<Medicament>>.Success(await _medicamentRepository.ListMedicament());
    }

    public async Task<Result<string>> RemoveMedicament(Guid id)
    {
        var medicament = await _medicamentRepository.GetMedicament(id);

        if (medicament == null)
            return Result<string>.Failure(new List<string>() { $"Medicament with {id} not found!" });

        if (! await _medicamentRepository.RemoveMedicament(medicament))
            return Result<string>.Failure(new List<string>() { $"Medicament with {id} not deleted!" });
            
        return Result<string>.Success($"Medicament with {id} successfully deleted!");
    }

    public async Task<Result<Medicament>> UpdateMedicament(Guid id, MedicamentCreateDto dto)
    {
        var medicament = await _medicamentRepository.GetMedicament(id);

        if (medicament == null)
            return Result<Medicament>.Failure(new List<string>() { $"Medicament with {id} not found!" });

        var updatedMedicament = new Medicament
        {
            Id = id,
            Name = dto.Name,
            ApplicationMethod = dto.ApplicationMethod
        };

        if (! await _medicamentRepository.UpdateMedicament(updatedMedicament))
            return Result<Medicament>.Failure(new List<string>() {  $"Medicament with {id} not updated!" });

        return Result<Medicament>.Success(updatedMedicament);
    }
}
