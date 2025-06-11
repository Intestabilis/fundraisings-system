using Fundraisings.Domain.Models;

namespace Fundraisings.Persistence.DataAccess.Repositories;

public class ComplaintsRepository
{
    private readonly FundraisingDbContext _dbContext;

    public ComplaintsRepository(FundraisingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Add(Complaint complaint)
    {
        await _dbContext.Complaints.AddAsync(complaint);
        await _dbContext.SaveChangesAsync();
        return complaint.Id;
    }
}