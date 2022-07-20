using ArmyTechTask.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArmyTechTask.Infrastructure.EntityConfigurations;

internal class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.BranchName)
            .HasMaxLength(200)
            .HasDefaultValueSql("('')");

        builder.Property(e => e.CityId).HasColumnName("CityID");

        builder.HasOne(d => d.City)
            .WithMany(p => p.Branches)
            .HasForeignKey(d => d.CityId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Branches_Cities");
    }
}
