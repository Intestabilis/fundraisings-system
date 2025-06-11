using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Fundraisings.Persistence.DataAccess.Repositories;

public class FundraisingsRepository
{
    private readonly FundraisingDbContext _dbContext;

    public FundraisingsRepository(FundraisingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Add(Fundraising fundraising)
    {
        
        await _dbContext.AddAsync(fundraising);
        await _dbContext.SaveChangesAsync();
        return fundraising.Id;
    }
    
    public async Task<Fundraising?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Fundraisings
            .Include(f => f.Direction)
            .Include(f => f.Equipment)
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id);
    }
    
    public async Task UpdateAsync(Fundraising fundraising)
    {
        _dbContext.Fundraisings.Update(fundraising);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<List<Fundraising>> GetFilteredAsync(string searchRequest, Guid? directionId, Guid? equipmentId, int page, int pageSize)
    {
        var query = _dbContext.Fundraisings
            .Include(f => f.Direction)
            .Include(f => f.Equipment)
            .AsQueryable();

        if (!String.IsNullOrEmpty(searchRequest))
            query = query.Where(f => f.Title.Contains(searchRequest));
        
        if (directionId.HasValue)
            query = query.Where(f => f.DirectionId == directionId.Value);

        if (equipmentId.HasValue)
            query = query.Where(f => f.EquipmentId == equipmentId.Value);
        

        return await query
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    
    public async Task<List<Fundraising>> GetAllActiveFundraisingsAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Fundraisings
            .Where(f => f.Status == "Open") //може додати  && f.Deadline > DateTime.UtcNow для перевірки дедлайну
            .ToListAsync(cancellationToken);
    }
    
    public async Task UpdateCurrentAmountAsync(Guid fundraisingId, decimal newAmount, CancellationToken cancellationToken)
    {
        var fundraising = await _dbContext.Fundraisings.FindAsync(new object[] { fundraisingId }, cancellationToken);
        if (fundraising != null)
        {
            fundraising.CurrentAmount = newAmount;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
    
    public async Task<List<Fundraising>> GetByPage(int page, int pageSize)
    {
        return await _dbContext.Fundraisings
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Fundraising>> GetByUser(Guid userId)
    {
        return await _dbContext.Fundraisings
            .AsNoTracking()
            .Where(u => u.VolunteerId == userId)
            .ToListAsync();
    }
}