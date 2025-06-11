using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fundraisings.Persistence.DataAccess.Configurations;

public class ComplaintFileConfiguration : IEntityTypeConfiguration<ComplaintFile>
{
    public void Configure(EntityTypeBuilder<ComplaintFile> builder)
    {
        builder.HasKey(cf => cf.Id);
        builder.Property(cf => cf.FileUrl).IsRequired();
        builder.HasOne(cf => cf.Complaint)
            .WithMany(c => c.Files)
            .HasForeignKey(cf => cf.ComplaintId);
    }
}
