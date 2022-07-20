﻿using ArmyTechTask.Domain;
using Microsoft.EntityFrameworkCore;

namespace ArmyTechTask.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; } = null!;
    public virtual DbSet<Cashier> Cashiers { get; set; } = null!;
    public virtual DbSet<City> Cities { get; set; } = null!;
    public virtual DbSet<Invoice> Invoices { get; set; } = null!;
    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
    public virtual DbSet<InvoiceHeader> InvoiceHeaders { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ArmyTechTask");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.BranchName)
                .HasMaxLength(200)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.CityId).HasColumnName("CityID");

            entity.HasOne(d => d.City)
                .WithMany(p => p.Branches)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Branches_Cities");
        });

        modelBuilder.Entity<Cashier>(entity =>
        {
            entity.ToTable("Cashier");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");

            entity.Property(e => e.CashierName)
                .HasMaxLength(200)
                .HasDefaultValueSql("('')");

            entity.HasOne(d => d.Branch)
                .WithMany(p => p.Cashiers)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cashier_Branches");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CityName)
                .HasMaxLength(200)
                .HasDefaultValueSql("('')");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("Invoices");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");

            entity.Property(e => e.CashierId).HasColumnName("CashierID");

            entity.Property(e => e.CustomerName).HasMaxLength(200);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Invoicedate).HasColumnType("datetime");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.InvoiceHeaderId).HasColumnName("InvoiceHeaderID");

            entity.Property(e => e.ItemName)
                .HasMaxLength(200)
                .HasDefaultValueSql("('')");

            entity.HasOne(d => d.InvoiceHeader)
                .WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceHeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetails_InvoiceHeader");
        });

        modelBuilder.Entity<InvoiceHeader>(entity =>
        {
            entity.ToTable("InvoiceHeader");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");

            entity.Property(e => e.CashierId).HasColumnName("CashierID");

            entity.Property(e => e.CustomerName)
                .HasMaxLength(200)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.Invoicedate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Branch)
                .WithMany(p => p.InvoiceHeaders)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceHeader_Branches");

            entity.HasOne(d => d.Cashier)
                .WithMany(p => p.InvoiceHeaders)
                .HasForeignKey(d => d.CashierId)
                .HasConstraintName("FK_InvoiceHeader_Cashier");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
