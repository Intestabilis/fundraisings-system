using Fundraisings.Domain.Models;

namespace Fundraisings.Domain.Abstractions;

public interface IComplaintsService
{
    public Task<Guid> CreateAsync(Complaint complaint);
}