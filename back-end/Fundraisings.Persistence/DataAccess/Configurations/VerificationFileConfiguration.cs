using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fundraisings.Persistence.DataAccess.Configurations;

public class VerificationFileConfiguration : IEntityTypeConfiguration<VerificationFile>
{
    public void Configure(EntityTypeBuilder<VerificationFile> builder)
    {
        builder.HasKey(vf => vf.Id);
        builder.Property(vf => vf.FileUrl).IsRequired();
        builder.HasOne(vf => vf.Verification)
            .WithMany(v => v.Files)
            .HasForeignKey(vf => vf.VerificationId);
    }
}