using ArmyTechTask.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArmyTechTask.Infrastructure.EntityConfigurations;

internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasNoKey();

        builder.ToView("Invoices");

        builder.Property(e => e.BranchId).HasColumnName("BranchID");

        builder.Property(e => e.CashierId).HasColumnName("CashierID");

        builder.Property(e => e.CustomerName).HasMaxLength(200);

        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.Invoicedate).HasColumnType("datetime");
    }
}
