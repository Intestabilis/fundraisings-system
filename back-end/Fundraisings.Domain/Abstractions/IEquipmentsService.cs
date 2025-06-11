using Fundraisings.Domain.Models;

namespace Fundraisings.Domain.Abstractions;

public interface IEquipmentsService
{
    public Task<Guid> CreateAsync(Equipment equipment);
    
    public Task<List<Equipment>> GetAllEquipments();
}