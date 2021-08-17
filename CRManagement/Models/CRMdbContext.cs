using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CRManagement.Models
{
    public partial class CRMdbContext : DbContext
    {
        public CRMdbContext()
        {
        }

        public CRMdbContext(DbContextOptions<CRMdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseEnquiry> CourseEnquiries { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<ResourseEnquiry> ResourseEnquiries { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database= CRMdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.Property(e => e.ClaimId)
                    .ValueGeneratedNever()
                    .HasColumnName("Claim_Id");

                entity.Property(e => e.ClaimType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Claim_Type");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("Course_Id");

                entity.Property(e => e.CourseAvaiStatus).HasColumnName("Course_AvaiStatus");

                entity.Property(e => e.CourseDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Course_Description");

                entity.Property(e => e.CourseDuration).HasColumnName("Course_Duration");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Course_Name");

                entity.Property(e => e.CoursePrice).HasColumnName("Course_Price");
            });

            modelBuilder.Entity<CourseEnquiry>(entity =>
            {
                entity.ToTable("CourseEnquiry");

                entity.Property(e => e.CourseEnquiryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Course_EnquiryId");

                entity.Property(e => e.CourseEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Course_Email");

                entity.Property(e => e.CourseEnId).HasColumnName("Course_EnId");

                entity.Property(e => e.CourseFullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Course_FullName");

                entity.Property(e => e.CoursePhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Course_Phone");

                entity.Property(e => e.CourseStageStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Course_StageStatus");

                entity.Property(e => e.CourseTestScore).HasColumnName("Course_TestScore");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CourseEn)
                    .WithMany(p => p.CourseEnquiries)
                    .HasForeignKey(d => d.CourseEnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseEnq__Cours__2D27B809");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.ResourceId)
                    .ValueGeneratedNever()
                    .HasColumnName("Resource_Id");

                entity.Property(e => e.ResourceAvaiStatus).HasColumnName("Resource_AvaiStatus");

                entity.Property(e => e.ResourceDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Resource_Description");

                entity.Property(e => e.ResourceName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Resource_Name");

                entity.Property(e => e.ResourcePrice).HasColumnName("Resource_Price");
            });

            modelBuilder.Entity<ResourseEnquiry>(entity =>
            {
                entity.HasKey(e => e.ResourceEnquiryId)
                    .HasName("PK__Resourse__68B02DE0082DA5AC");

                entity.ToTable("ResourseEnquiry");

                entity.Property(e => e.ResourceEnquiryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Resource_EnquiryId");

                entity.Property(e => e.ResourceEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Resource_Email");

                entity.Property(e => e.ResourceEnId).HasColumnName("Resource_EnId");

                entity.Property(e => e.ResourceFullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Resource_FullName");

                entity.Property(e => e.ResourcePhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Resource_Phone");

                entity.Property(e => e.ResourceStatus).HasColumnName("Resource_Status");

                entity.HasOne(d => d.ResourceEn)
                    .WithMany(p => p.ResourseEnquiries)
                    .HasForeignKey(d => d.ResourceEnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ResourseE__Resou__300424B4");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("User_Id");

                entity.Property(e => e.UserClaimId).HasColumnName("User_ClaimId");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("User_Email");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("User_Name");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("User_Password");

                entity.Property(e => e.UserPhoneN)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("User_PhoneN");

                entity.HasOne(d => d.UserClaim)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserClaimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__User_Claim__30F848ED");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
