using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NyamaSeed.Data
{
    public partial class NyamaAppDbContext : DbContext
    {
        public NyamaAppDbContext()
        {
        }

        public NyamaAppDbContext(DbContextOptions<NyamaAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Expense> Expenses { get; set; } = null!;
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Shop> Shops { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NyamaAppDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District");

                entity.HasIndex(e => e.CityId, "IX_District_CityId");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.ToTable("Expense");

                entity.HasIndex(e => e.ExpenseTypeId, "IX_Expense_ExpenseTypeId");

                entity.HasIndex(e => e.UnitId, "IX_Expense_UnitId");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ExpenseType)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.ExpenseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ExpenseType>(entity =>
            {
                entity.ToTable("ExpenseType");

                entity.HasIndex(e => e.CategoryId, "IX_ExpenseType_CategoryId");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ExpenseTypes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.ShopId, "IX_Order_ShopId");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("Shop");

                entity.HasIndex(e => e.DistrictId, "IX_Shop_DistrictId");

                entity.HasIndex(e => e.ImageId, "IX_Shop_ImageId");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.ImageId);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
