using FluentValidation.Validators;
using Fundraisings.Domain.Abstractions;
using Fundraisings.Domain.Models;
using Fundraisings.Persistence.DataAccess.Repositories;

namespace Fundraisings.Application.Services;

public class UsersService : IUsersService
{
    private readonly UsersRepository _repository;
    
    public UsersService(UsersRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Guid> CreateAsync(User user)
    {
        return await _repository.Add(user);
    }
    public async Task<bool> CheckEmail(string email)
    {
        return await _repository.EmailExists(email);
    }
    public async Task<List<User>> GetAllUsers()
    {
        return await _repository.GetAll();
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _repository.GetByEmail(email);
    }
    
    public async Task UpdateStatusAsync(Guid userId, string newStatus)
    {
       // логіка оновлення статусу, логування, перевірка прав
       var user = await _repository.GetById(userId);
       if (user == null)
       {
           throw new Exception("User not found");
       }
       user.Status = newStatus;
    }
    
    public async Task UpdateProfileAsync(Guid userId, string? description, string? profilePictureUrl)
    {
        var user = await _repository.GetById(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        user.Description = description;
        user.ProfilePictureUrl = profilePictureUrl;
        // логіка оновлення профілю
    }
}
