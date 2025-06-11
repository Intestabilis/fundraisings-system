using Fundraisings.Domain.Models;

namespace Fundraisings.Domain.Abstractions;

public interface IFundraisingsService
{
    public Task<Guid> CreateAsync(Fundraising fundraising);

    public Task<List<Fundraising>> GetByFilter(string? search, Guid? directionId, Guid? equipmentId, int pageNumber,
        int pageSize);

    public Task<Fundraising> GetOne(Guid id);
}