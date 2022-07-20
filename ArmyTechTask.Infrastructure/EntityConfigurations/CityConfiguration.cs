using ArmyTechTask.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArmyTechTask.Infrastructure.EntityConfigurations;

internal class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.CityName)
            .HasMaxLength(200)
            .HasDefaultValueSql("('')");
    }
}
