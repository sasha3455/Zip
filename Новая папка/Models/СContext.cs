using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Models;

public partial class СContext : DbContext
{
    public СContext()
    {
    }

    public СContext(DbContextOptions<СContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<ProductT> ProductTs { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<RoleU> RoleUs { get; set; }

    public virtual DbSet<StatusOrder> StatusOrders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-STHDEHE\\SQLEXPRESS;Initial Catalog=С#;Integrated Security=True;Trust Server Certificate=True");



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__6DB38D4E895391D7");

            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Category_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__F1E4639BDCE00158");

            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.OrderDate).HasColumnName("Order_Date");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.StatusOrderId).HasColumnName("Status_order_ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__Product___4E88ABD4");

            entity.HasOne(d => d.StatusOrder).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__Status_o__4F7CD00D");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__User_ID__4D94879B");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__DA6C7FE1970C0D94");

            entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.PaymentDate).HasColumnName("Payment_date");
            entity.Property(e => e.PaymentMethodId).HasColumnName("Payment_method_ID");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Payment_status");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Order___52593CB8");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Paymen__534D60F1");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__Payment___7BBF7539EAE1785C");

            entity.ToTable("Payment_Method");

            entity.HasIndex(e => e.MethodName, "UQ__Payment___2274D72F6233086B").IsUnique();

            entity.Property(e => e.PaymentMethodId).HasColumnName("Payment_method_ID");
            entity.Property(e => e.MethodName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Method_name");
        });

        modelBuilder.Entity<ProductT>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product___9834FB9A43DF10CF");

            entity.ToTable("Product_t");

            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.DescriptionP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Description_p");
            entity.Property(e => e.NameP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_p");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StockQuantity).HasColumnName("Stock_quantity");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductTs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_t__Categ__412EB0B6");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__F85DA7EB1E0AA84D");

            entity.Property(e => e.ReviewId).HasColumnName("Review_ID");
            entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.ReviewDate).HasColumnName("Review_Date");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__Product__49C3F6B7");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__User_ID__48CFD27E");
        });

        modelBuilder.Entity<RoleU>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role_u__8AFACE3A9FC9AB66");

            entity.ToTable("Role_u");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Role_name");
        });

        modelBuilder.Entity<StatusOrder>(entity =>
        {
            entity.HasKey(e => e.StatusOrderId).HasName("PK__Status_o__9A72CE6F8D3A2958");

            entity.ToTable("Status_order");

            entity.Property(e => e.StatusOrderId).HasColumnName("Status_order_ID");
            entity.Property(e => e.StatusDescriotion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Status_descriotion");
            entity.Property(e => e.StatusName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Status_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__206D91905ED20343");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534A537B870").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.AddressU)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Address_u");
            entity.Property(e => e.BankCard)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Bank_card");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameU)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_u");
            entity.Property(e => e.PasswordU)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Password_u");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleID__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
