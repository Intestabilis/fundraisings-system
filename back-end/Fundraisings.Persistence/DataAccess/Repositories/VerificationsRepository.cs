using Fundraisings.Domain.Models;

namespace Fundraisings.Persistence.DataAccess.Repositories;

public class VerificationsRepository
{
    private readonly FundraisingDbContext _dbContext;

    public VerificationsRepository(FundraisingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddFilesToVerificationAsync(Guid verificationId, IEnumerable<VerificationFile> files)
    {
        foreach (var file in files)
        {
            file.VerificationId = verificationId;
            await _dbContext.VerificationFiles.AddAsync(file);
        }
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<Guid> AddVerificationAsync(Verification verification)
    {
        await _dbContext.Verifications.AddAsync(verification);
        await _dbContext.SaveChangesAsync();
        return verification.Id;
    }
}