using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain_Layer.EntityMaper
{
    public class CourseEnquiryMap : IEntityTypeConfiguration<CourseEnquiry>
    {
        public void Configure(EntityTypeBuilder<CourseEnquiry> builder)
        {

            builder.ToTable("CourseEnquiry");


            builder.HasKey(e => e.Id)
                    .HasName("courseenq_id");


            builder.Property(e => e.CourseEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Course_Email");


            builder.Property(e => e.CourseErecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Course_ERecord_Date")
                    .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.CourseEupdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Course_EUpdate_Date")
                    .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.CourseFullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Course_FullName");

            builder.Property(e => e.CoursePhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Course_Phone");

            builder.Property(e => e.CourseStageStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Course_StageStatus");

            builder.Property(e => e.CourseTestScore).HasColumnName("Course_TestScore");

            builder.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

            builder.Property(e => e.Qualification)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.HasOne(d => d.CourseEn)
                    .WithMany(p => p.CourseEnquiries)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseEnq__Cours__2D27B809");
        }

    }
}
