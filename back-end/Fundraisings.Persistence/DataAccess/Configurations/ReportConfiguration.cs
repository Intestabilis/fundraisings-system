using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fundraisings.Persistence.DataAccess.Configurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Description).IsRequired();
        builder.HasOne(r => r.Fundraising)
            .WithMany(f => f.Reports)
            .HasForeignKey(r => r.FundraisingId);
    }
}