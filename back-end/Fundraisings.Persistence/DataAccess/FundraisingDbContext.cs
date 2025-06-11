using Fundraisings.Domain.Models;
using Fundraisings.Persistence.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Fundraisings.Persistence.DataAccess;

public class FundraisingDbContext(DbContextOptions<FundraisingDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Verification> Verifications => Set<Verification>();
    public DbSet<VerificationFile> VerificationFiles => Set<VerificationFile>();
    public DbSet<Fundraising> Fundraisings => Set<Fundraising>();
    public DbSet<Report> Reports => Set<Report>();
    public DbSet<ReportFile> ReportFiles => Set<ReportFile>();
    public DbSet<Equipment> Equipments => Set<Equipment>();
    public DbSet<Direction> Directions => Set<Direction>();
    public DbSet<Complaint> Complaints => Set<Complaint>();
    public DbSet<ComplaintFile> ComplaintFiles => Set<ComplaintFile>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new FundraisingConfiguration());
        modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
        modelBuilder.ApplyConfiguration(new DirectionConfiguration());
        modelBuilder.ApplyConfiguration(new ReportConfiguration());
        modelBuilder.ApplyConfiguration(new ReportFileConfiguration());
        modelBuilder.ApplyConfiguration(new ComplaintConfiguration());
        modelBuilder.ApplyConfiguration(new ComplaintFileConfiguration());
        modelBuilder.ApplyConfiguration(new VerificationConfiguration());
        modelBuilder.ApplyConfiguration(new VerificationFileConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}