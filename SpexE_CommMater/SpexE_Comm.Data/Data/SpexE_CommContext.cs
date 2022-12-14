using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SpexE_Comm.Data.Data
{
    public partial class SpexE_CommContext : DbContext
    {
        public SpexE_CommContext()
        {
        }

        public SpexE_CommContext(DbContextOptions<SpexE_CommContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Membership> Membership { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SpexCommKeys> SpexCommKeys { get; set; }
        public virtual DbSet<SpexECommKeys> SpexECommKeys { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserDeviceInformation> UserDeviceInformation { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-EEDDE592\\SQLEXPRESS;Initial Catalog=SpexE_Comm;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membership>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.RegistrationDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserSalt).HasMaxLength(150);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ProductImage1).IsRequired();

                entity.Property(e => e.ProductName).IsRequired();

                entity.Property(e => e.ProductType).IsRequired();

                entity.Property(e => e.Warranty).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<SpexCommKeys>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ApiName).HasMaxLength(150);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsEncrypted)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SpexECommKeys>(entity =>
            {
                entity.ToTable("SpexE_CommKeys");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ApiName).HasMaxLength(150);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsEncrypted)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.UserNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_MembershipUser");
            });

            modelBuilder.Entity<UserDeviceInformation>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeviceId).HasMaxLength(250);

                entity.Property(e => e.DeviceIp)
                    .HasColumnName("DeviceIP")
                    .HasMaxLength(250);

                entity.Property(e => e.LastLogIn).HasMaxLength(250);

                entity.Property(e => e.LastLogInDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RegistrationDate).HasMaxLength(250);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDeviceInformation)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserDeviceInformation_User");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserRole)
                    .HasForeignKey<UserRole>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
