using Fundraisings.Domain.Abstractions;
using Fundraisings.Domain.Models;
using Fundraisings.Persistence.DataAccess.Repositories;

namespace Fundraisings.Application.Services;

public class ComplaintsService : IComplaintsService
{
    private readonly ComplaintsRepository _repository;
    
    public async Task<Guid> CreateAsync(Complaint complaint)
    {
        return await _repository.Add(complaint);
    }
}