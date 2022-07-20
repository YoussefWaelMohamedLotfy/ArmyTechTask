using ArmyTechTask.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArmyTechTask.Infrastructure.EntityConfigurations;

internal class CashierConfiguration : IEntityTypeConfiguration<Cashier>
{
    public void Configure(EntityTypeBuilder<Cashier> builder)
    {
        builder.ToTable("Cashier");

        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.BranchId).HasColumnName("BranchID");

        builder.Property(e => e.CashierName)
            .HasMaxLength(200)
            .HasDefaultValueSql("('')");

        builder.HasOne(d => d.Branch)
            .WithMany(p => p.Cashiers)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Cashier_Branches");
    }
}
