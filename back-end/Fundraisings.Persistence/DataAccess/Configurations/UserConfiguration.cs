using Fundraisings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fundraisings.Persistence.DataAccess.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Email)
            .IsRequired();
        builder.Property(u => u.PasswordHash)
            .IsRequired();
        builder.Property(u => u.Status)
            .IsRequired();
        builder.Property(u => u.Name)
            .IsRequired();
        builder.Property(u => u.Surname)
            .IsRequired();
        builder.HasMany(u => u.Fundraisings)
            .WithOne(f => f.Volunteer);
        builder.HasMany(u => u.Complaints)
            .WithOne(c => c.User);
    }
}