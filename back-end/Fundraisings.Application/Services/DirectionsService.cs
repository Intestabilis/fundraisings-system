using Fundraisings.Domain.Abstractions;
using Fundraisings.Domain.Models;
using Fundraisings.Persistence.DataAccess.Repositories;

namespace Fundraisings.Application.Services;

public class DirectionsService : IDirectionsService
{
    private readonly DirectionsRepository _repository;
    
    public DirectionsService(DirectionsRepository repository)
    {
        _repository = repository;
    }
    public async Task<Guid> CreateAsync(Direction direction)
    {
        return await _repository.Add(direction);
    }

    public async Task<List<Direction>> GetAllDirections()
    {
        return await _repository.GetAll();
    }
}