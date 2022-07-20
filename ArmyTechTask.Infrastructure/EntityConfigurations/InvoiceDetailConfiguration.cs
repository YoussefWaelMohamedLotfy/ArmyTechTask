using ArmyTechTask.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArmyTechTask.Infrastructure.EntityConfigurations;

internal class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
{
    public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.InvoiceHeaderId).HasColumnName("InvoiceHeaderID");

        builder.Property(e => e.ItemName)
            .HasMaxLength(200)
            .HasDefaultValueSql("('')");

        builder.HasOne(d => d.InvoiceHeader)
            .WithMany(p => p.InvoiceDetails)
            .HasForeignKey(d => d.InvoiceHeaderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_InvoiceDetails_InvoiceHeader");
    }
}
