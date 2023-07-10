using Microsoft.EntityFrameworkCore;

namespace PayzeeCaseStudy.Entity.Models;

public partial class PayzeeContext : DbContext
{
    public PayzeeContext()
    {
    }

    public PayzeeContext(DbContextOptions<PayzeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-J0GBJSC;Database=PayzeeDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.IdentityNo).HasMaxLength(11);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("Transaction");

            entity.Property(e => e.TransactionId).ValueGeneratedOnAdd();
            entity.Property(e => e.Amount)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CardPan).HasMaxLength(16);
            entity.Property(e => e.OrderId).HasMaxLength(50);
            entity.Property(e => e.ResponseCode)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Transaction_Customer");
        });


        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.ApiKey).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Lang).HasMaxLength(3);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
