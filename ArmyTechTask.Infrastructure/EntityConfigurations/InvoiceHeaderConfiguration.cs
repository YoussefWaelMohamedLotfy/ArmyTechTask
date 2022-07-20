using ArmyTechTask.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArmyTechTask.Infrastructure.EntityConfigurations;

internal class InvoiceHeaderConfiguration : IEntityTypeConfiguration<InvoiceHeader>
{
    public void Configure(EntityTypeBuilder<InvoiceHeader> builder)
    {
        builder.ToTable("InvoiceHeader");

        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.BranchId).HasColumnName("BranchID");

        builder.Property(e => e.CashierId).HasColumnName("CashierID");

        builder.Property(e => e.CustomerName)
            .HasMaxLength(200)
            .HasDefaultValueSql("('')");

        builder.Property(e => e.Invoicedate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

        builder.HasOne(d => d.Branch)
            .WithMany(p => p.InvoiceHeaders)
            .HasForeignKey(d => d.BranchId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_InvoiceHeader_Branches");

        builder.HasOne(d => d.Cashier)
            .WithMany(p => p.InvoiceHeaders)
            .HasForeignKey(d => d.CashierId)
            .HasConstraintName("FK_InvoiceHeader_Cashier");
    }
}
