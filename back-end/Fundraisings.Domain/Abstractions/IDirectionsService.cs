using Fundraisings.Domain.Models;

namespace Fundraisings.Domain.Abstractions;

public interface IDirectionsService
{
    public Task<Guid> CreateAsync(Direction direction);
    public Task<List<Direction>> GetAllDirections();
}