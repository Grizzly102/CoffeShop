using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Coffe.Model;

public partial class CoffeshopContext : DbContext
{
    public CoffeshopContext()
    {
    }

    public CoffeshopContext(DbContextOptions<CoffeshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;port=3306;user=root;password=qwerty;database=coffeshop", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.IdCategory)
                .ValueGeneratedNever()
                .HasColumnName("Id_category");
            entity.Property(e => e.CategoryProduct)
                .HasMaxLength(45)
                .HasColumnName("Category_product");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderNumber).HasName("PRIMARY");

            entity.ToTable("order");

            entity.HasIndex(e => e.IdBarista, "barista_idx");

            entity.Property(e => e.OrderNumber)
                .ValueGeneratedNever()
                .HasColumnName("Order_number");
            entity.Property(e => e.Address).HasMaxLength(45);
            entity.Property(e => e.IdBarista).HasColumnName("Id_barista");
            entity.Property(e => e.OrderDate).HasColumnName("Order_date");
            entity.Property(e => e.OrderList)
                .HasMaxLength(45)
                .HasColumnName("Order_list");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(45)
                .HasColumnName("Order_status");
            entity.Property(e => e.UserName)
                .HasMaxLength(45)
                .HasColumnName("User_name");

            entity.HasOne(d => d.IdBaristaNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdBarista)
                .HasConstraintName("barista");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Article).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.IdCategory, "category_idx");

            entity.Property(e => e.Article).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.IdCategory).HasColumnName("Id_category");
            entity.Property(e => e.Photo).HasMaxLength(20);
            entity.Property(e => e.ProductName)
                .HasMaxLength(20)
                .HasColumnName("Product_name");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("category");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.IdRole)
                .ValueGeneratedNever()
                .HasColumnName("Id_role");
            entity.Property(e => e.Role1)
                .HasMaxLength(45)
                .HasColumnName("Role");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.IdSize).HasName("PRIMARY");

            entity.ToTable("size");

            entity.Property(e => e.IdSize)
                .ValueGeneratedNever()
                .HasColumnName("Id_size");
            entity.Property(e => e.NameSize)
                .HasMaxLength(45)
                .HasColumnName("Name_size");
            entity.Property(e => e.SizeDrink)
                .HasMaxLength(5)
                .HasColumnName("Size_drink");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.IdRole, "role_idx");

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("Id_user");
            entity.Property(e => e.FullName)
                .HasMaxLength(45)
                .HasColumnName("Full_name");
            entity.Property(e => e.IdRole).HasColumnName("Id_role");
            entity.Property(e => e.Login).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.Phone).HasMaxLength(45);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
