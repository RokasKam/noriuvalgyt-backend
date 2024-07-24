using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoriuValgyti.Domain.Entities;

namespace NoriuValgyti.Infrastructure.Data.Configurations;

public class UserConfiguration :  IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.CreationDate).HasDefaultValueSql("DATE('now')");
        builder.Property(x => x.ModificationDate).HasDefaultValueSql("DATE('now')");
    }
}