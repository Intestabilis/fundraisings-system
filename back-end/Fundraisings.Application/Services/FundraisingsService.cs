using Fundraisings.Domain.Abstractions;
using Fundraisings.Domain.Models;
using Fundraisings.Persistence.DataAccess.Repositories;

namespace Fundraisings.Application.Services;

public class FundraisingsService : IFundraisingsService
{
    private readonly FundraisingsRepository _repository;

    public FundraisingsService(FundraisingsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CreateAsync(Fundraising fundraising)
    {
        return await _repository.Add(fundraising);
    }
    public async Task<Fundraising> GetOne(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
    public async Task<List<Fundraising>> GetByFilter(string? search, Guid? directionId, Guid? equipmentId, int pageNumber,
        int pageSize)
    {
        return await _repository.GetFilteredAsync(search, directionId, equipmentId, pageNumber, pageSize);
    }

    // public async Task<FundraisingResponse?> UpdateAsync(FundraisingUpdateRequest request)
    // {
    //     var entity = await _repository.GetByIdAsync(request.Id);
    //     if (entity == null) return null;
    //
    //     if (request.Title is not null) entity.Title = request.Title;
    //     if (request.Description is not null) entity.Description = request.Description;
    //     if (request.GoalAmount.HasValue) entity.GoalAmount = request.GoalAmount.Value;
    //     if (request.DirectionId.HasValue) entity.DirectionId = request.DirectionId.Value;
    //     if (request.EquipmentId.HasValue) entity.EquipmentId = request.EquipmentId.Value;
    //     if (request.DonationUrl is not null) entity.DonationUrl = request.DonationUrl;
    //     if (request.ImageUrl is not null) entity.ImageUrl = request.ImageUrl;
    //     if (request.Value.HasValue) entity.Value = request.Value.Value;
    //     if (request.Deadline.HasValue) entity.Deadline = request.Deadline.Value;
    //
    //     await _repository.UpdateAsync(entity);
    //
    //     return MapToResponse(entity);
    // }
    //
    // public async Task<bool> ChangeStatusAsync(Guid id, string newStatus)
    // {
    //     var entity = await _repository.GetByIdAsync(id);
    //     if (entity == null) return false;
    //
    //     // Логіка перевірки, що можна змінити зі статусу "Open" на "Closed"
    //     if (entity.Status == "Open" && newStatus == "Closed")
    //     {
    //         entity.Status = newStatus;
    //         await _repository.UpdateAsync(entity);
    //         return true;
    //     }
    //
    //     return false;
    // }
    //
    // public async Task<FundraisingResponse?> GetByIdAsync(Guid id)
    // {
    //     var entity = await _repository.GetByIdAsync(id);
    //     if (entity == null) return null;
    //
    //     return MapToResponse(entity);
    // }
    //
    // public async Task<IEnumerable<FundraisingResponse>> GetFilteredAsync(FundraisingFilterRequest filter)
    // {
    //     var entities = await _repository.GetFilteredAsync(filter.DirectionId, filter.EquipmentId, filter.VolunteerId,
    //         filter.PageNumber, filter.PageSize);
    //     return entities.Select(MapToResponse);
    // }
    //
    // public async Task UpdateCurrentAmountAsync(Guid id, decimal newAmount)
    // {
    //     var entity = await _repository.GetByIdAsync(id);
    //     if (entity == null)
    //         throw new ArgumentException("Fundraising not found", nameof(id));
    //
    //     entity.CurrentAmount = newAmount;
    //     await _repository.UpdateAsync(entity);
    // }

    private static Fundraising MapToResponse(Fundraising fundraising)
    {
        return fundraising;
    }
}