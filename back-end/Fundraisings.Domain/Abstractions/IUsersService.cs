using Fundraisings.Domain.Models;

namespace Fundraisings.Domain.Abstractions;

public interface IUsersService
{
    public Task<Guid> CreateAsync(User user);
    public Task<List<User>> GetAllUsers();
    public Task<User?> GetByEmail(string email);
    public Task<bool> CheckEmail(string email);
    public Task UpdateStatusAsync(Guid userId, string newStatus);
    public Task UpdateProfileAsync(Guid userId, string? description, string? profilePictureUrl);
}