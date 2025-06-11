using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fundraisings.Persistence.DataAccess.Configurations;

public class VerificationConfiguration : IEntityTypeConfiguration<Verification>
{
    public void Configure(EntityTypeBuilder<Verification> builder)
    {
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Description).IsRequired();
        builder.Property(v => v.Status).IsRequired();
        builder.HasOne(v => v.User)
            .WithOne()
            .HasForeignKey<Verification>(v => v.UserId);
    }
}