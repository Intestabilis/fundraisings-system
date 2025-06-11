using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Fundraisings.Persistence.DataAccess.Repositories;

public class UsersRepository
{
    private readonly FundraisingDbContext _dbContext;

    public UsersRepository(FundraisingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAll()
    {
        return await _dbContext.Users
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<User?> GetById(Guid id)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }
    public async Task<User?> GetByEmail(string email)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> EmailExists(string email)
    {
        return await _dbContext.Users.AsNoTracking().AnyAsync(u => u.Email == email);
    }
    
    public async Task<Guid> Add(User user)
    {
        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user.Id;
    }

    public async Task<List<User>> GetWithFundraisings()
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Include(u => u.Fundraisings)
            .ToListAsync();
    }
}