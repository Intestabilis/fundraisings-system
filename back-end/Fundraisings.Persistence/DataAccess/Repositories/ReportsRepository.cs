using Fundraisings.Domain.Models;

namespace Fundraisings.Persistence.DataAccess.Repositories;

public class ReportsRepository
{
    private readonly FundraisingDbContext _dbContext;

    public ReportsRepository(FundraisingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid> Add(Report report)
    {
        await _dbContext.Reports.AddAsync(report);
        await _dbContext.SaveChangesAsync();
        return report.Id;
    }
}