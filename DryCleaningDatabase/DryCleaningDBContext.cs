using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DryCleaningDatabase
{
    public partial class DryCleaningDBContext : DbContext
    {
        public DryCleaningDBContext()
        {
        }

        public DryCleaningDBContext(DbContextOptions<DryCleaningDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessRule> AccessRules { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderState> OrderStates { get; set; }
        public virtual DbSet<Progress> Progresses { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Thing> Things { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NINAN;Initial Catalog=DryCleaningDatabase;Integrated Security=True;ConnectRetryCount = 0", options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AccessRule>(entity =>
            {
                entity.HasKey(e => e.Role);

                entity.ToTable("AccessRule");

                entity.Property(e => e.Role).ValueGeneratedNever();

                entity.Property(e => e.AccessRules)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientId)
                    .ValueGeneratedNever()
                    .HasColumnName("ClientID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.House).HasMaxLength(10);

                entity.Property(e => e.Inn)
                    .HasMaxLength(20)
                    .HasColumnName("INN");

                entity.Property(e => e.OfficeOrFlatNumber).HasMaxLength(10);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Street).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmployeeFio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("EmployeeFIO");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_AccessRule");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Contract).HasMaxLength(50);

                entity.Property(e => e.IssueDate).HasColumnType("date");

                entity.Property(e => e.OrderDate).HasColumnType("smalldatetime");

                entity.Property(e => e.OrderNote).HasMaxLength(50);

                entity.Property(e => e.OrderStateId).HasColumnName("OrderStateID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ThingId).HasColumnName("ThingID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Client");

                entity.HasOne(d => d.OrderState)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_OrderState");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Service");

                entity.HasOne(d => d.Thing)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ThingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Thing");
            });

            modelBuilder.Entity<OrderState>(entity =>
            {
                entity.ToTable("OrderState");

                entity.Property(e => e.OrderStateId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderStateID");

                entity.Property(e => e.ProgressId).HasColumnName("ProgressID");

                entity.HasOne(d => d.Progress)
                    .WithMany(p => p.OrderStates)
                    .HasForeignKey(d => d.ProgressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderState_Progress");
            });

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.ToTable("Progress");

                entity.Property(e => e.ProgressId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProgressID");

                entity.Property(e => e.ProgressName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId)
                    .ValueGeneratedNever()
                    .HasColumnName("ServiceID");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Thing>(entity =>
            {
                entity.ToTable("Thing");

                entity.Property(e => e.ThingId)
                    .ValueGeneratedNever()
                    .HasColumnName("ThingID");

                entity.Property(e => e.ThingDescription).HasMaxLength(50);

                entity.Property(e => e.ThingName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
