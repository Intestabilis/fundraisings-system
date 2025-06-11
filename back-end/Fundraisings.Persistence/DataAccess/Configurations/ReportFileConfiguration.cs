using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fundraisings.Persistence.DataAccess.Configurations;

public class ReportFileConfiguration : IEntityTypeConfiguration<ReportFile>
{
    public void Configure(EntityTypeBuilder<ReportFile> builder)
    {
        builder.HasKey(rf => rf.Id);
        builder.Property(rf => rf.FileUrl).IsRequired();
        builder.HasOne(rf => rf.Report)
            .WithMany(r => r.Files)
            .HasForeignKey(rf => rf.ReportId);
    }
}