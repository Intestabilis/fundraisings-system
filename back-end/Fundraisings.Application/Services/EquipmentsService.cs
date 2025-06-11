using Fundraisings.Domain.Abstractions;
using Fundraisings.Domain.Models;
using Fundraisings.Persistence.DataAccess.Repositories;

namespace Fundraisings.Application.Services;

public class EquipmentsService : IEquipmentsService
{
    private readonly EquipmentsRepository _repository;
    
    public EquipmentsService(EquipmentsRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Guid> CreateAsync(Equipment equipment)
    {
        return await _repository.Add(equipment);
    }

    public async Task<List<Equipment>> GetAllEquipments()
    {
        return await _repository.GetAll();
    }
}