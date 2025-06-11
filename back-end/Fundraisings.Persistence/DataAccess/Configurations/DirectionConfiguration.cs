using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fundraisings.Persistence.DataAccess.Configurations;

public class DirectionConfiguration : IEntityTypeConfiguration<Direction>
{
    public void Configure(EntityTypeBuilder<Direction> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.DirectionName).IsRequired();
        builder.Property(d => d.Geometry).HasColumnType("geography (polygon)");
        builder.Property(d => d.Weight).HasColumnType("decimal(18,2)");
    }
}