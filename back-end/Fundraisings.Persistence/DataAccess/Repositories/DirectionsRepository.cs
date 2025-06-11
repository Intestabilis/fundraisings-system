using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace Fundraisings.Persistence.DataAccess.Repositories;

public class DirectionsRepository
{
    private readonly FundraisingDbContext _dbContext;

    public DirectionsRepository(FundraisingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Add(Direction direction)
    {
        await _dbContext.Directions.AddAsync(direction);
        await _dbContext.SaveChangesAsync();
        return direction.Id;
    }

    public async Task<List<Direction>> GetAll()
    {
        return await _dbContext.Directions
            .AsNoTracking()
            .ToListAsync();
    }
}