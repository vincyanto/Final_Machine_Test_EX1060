using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesApp.Models
{
    public partial class salesAppContext : DbContext
    {
        public salesAppContext()
        {
        }

        public salesAppContext(DbContextOptions<salesAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeRegistration> EmployeeRegistration { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<VisitTbale> VisitTbale { get; set; }

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=VINCYANTO\\SQLEXPRESS; Initial Catalog=salesApp; Integrated security=True");
            }
        } */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRegistration>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__1299A861DE991991");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeRegistration)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__EmployeeR__UserI__4E88ABD4");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__TblRole__8AFACE1A88FCE031");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__TblUser__1788CC4C74A221FB");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUser)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_LOGIN");
            });

            modelBuilder.Entity<VisitTbale>(entity =>
            {
                entity.HasKey(e => e.VisitId)
                    .HasName("PK__VisitTba__DB49A4280B53405E");

                entity.Property(e => e.VisitId).HasColumnName("Visit_id");

                entity.Property(e => e.ContactNo)
                    .HasColumnName("Contact_No")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("Contact_Person")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasColumnName("Cust_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.InterestProduct)
                    .HasColumnName("Interest_Product")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnName("Is_Deleted");

                entity.Property(e => e.IsDisabled).HasColumnName("Is_Disabled");

                entity.Property(e => e.VisitDatetime)
                    .HasColumnName("Visit_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisitSubject)
                    .HasColumnName("Visit_Subject")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.VisitTbale)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__VisitTbal__emp_i__5165187F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
