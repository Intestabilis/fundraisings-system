using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Fundraisings.Persistence.DataAccess.Configurations;

public class FundraisingConfiguration : IEntityTypeConfiguration<Fundraising>
{
    public void Configure(EntityTypeBuilder<Fundraising> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Title).IsRequired();
        builder.Property(f => f.Description).IsRequired();
        builder.Property(f => f.CurrentAmount).HasColumnType("decimal(18,2)");
        builder.Property(f => f.GoalAmount).HasColumnType("decimal(18,2)");
        builder.Property(f => f.Value).HasColumnType("decimal(18,2)");
        builder.HasOne(f => f.Volunteer)
            .WithMany(u => u.Fundraisings)
            .HasForeignKey(f => f.VolunteerId);
        builder.HasOne(f => f.Equipment)
            .WithMany()
            .HasForeignKey(f => f.EquipmentId)
            .IsRequired();
        builder.HasOne(f => f.Direction)
            .WithMany()
            .HasForeignKey(f => f.DirectionId)
            .IsRequired();
    }
}
