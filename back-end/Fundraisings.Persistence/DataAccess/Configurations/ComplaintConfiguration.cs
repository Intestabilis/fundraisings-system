using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fundraisings.Persistence.DataAccess.Configurations;

public class ComplaintConfiguration : IEntityTypeConfiguration<Complaint>
{
    public void Configure(EntityTypeBuilder<Complaint> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Status)
            .IsRequired();
        builder.Property(c => c.Description)
            .IsRequired();
        builder
            .HasOne(c => c.User)
            .WithMany(u => u.Complaints)
            .HasForeignKey(c => c.UserId);
        builder
            .HasOne(c => c.Fundraising)
            .WithMany(f => f.Complaints)
            .HasForeignKey(c => c.FundraisingId);
        builder
            .HasMany(c => c.Files)
            .WithOne(f => f.Complaint)
            .HasForeignKey(f => f.ComplaintId);
    }
}