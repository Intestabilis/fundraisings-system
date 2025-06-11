using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Fundraisings.Persistence.DataAccess.Repositories;

public class EquipmentsRepository
{
    private readonly FundraisingDbContext _dbContext;

    public EquipmentsRepository(FundraisingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Add(Equipment equipment)
    {
        await _dbContext.Equipments.AddAsync(equipment);
        await _dbContext.SaveChangesAsync();
        return equipment.Id;
    }


    public async Task<List<Equipment>> GetAll()
    {
        return await _dbContext.Equipments
            .AsNoTracking()
            .ToListAsync();
    }
}