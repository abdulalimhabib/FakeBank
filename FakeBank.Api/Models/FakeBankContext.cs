using Microsoft.EntityFrameworkCore;

namespace FakeBank.Api.Models
{
    public partial class FakeBankContext : DbContext
    {
        public FakeBankContext()
        {
        }

        public FakeBankContext(DbContextOptions<FakeBankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountTransactions> AccountTransactions { get; set; }
        public virtual DbSet<AccountTransfers> AccountTransfers { get; set; }
        public virtual DbSet<AccountTypes> AccountTypes { get; set; }
        public virtual DbSet<UserAccounts> UserAccounts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LPTP\\SQLEXPRESS;Initial Catalog=FakeBank;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTransactions>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountTransactions)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountTransactions_UserAccounts");
            });

            modelBuilder.Entity<AccountTransfers>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.SourceAccount)
                    .WithMany(p => p.AccountTransfersSourceAccount)
                    .HasForeignKey(d => d.SourceAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountTranfers_UserAccounts");

                entity.HasOne(d => d.TargetAccount)
                    .WithMany(p => p.AccountTransfersTargetAccount)
                    .HasForeignKey(d => d.TargetAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountTranfers_UserAccounts1");
            });

            modelBuilder.Entity<AccountTypes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAccounts>(entity =>
            {
                entity.Property(e => e.Balance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Nickname).IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccounts_AccountTypes");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccounts_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.StreetAddress).IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
