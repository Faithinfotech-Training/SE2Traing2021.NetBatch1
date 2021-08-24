using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMaper
{
    public class CourseEnquiryMap : IEntityTypeConfiguration<CourseEnquiry>
    {
        public void Configure(EntityTypeBuilder<CourseEnquiry> builder)
        {

            builder.ToTable("CourseEnquiry");

            builder.HasKey(x => x.CourseEnquiryId)
                .HasName("pk_courseEnquiryId");
            builder.Property(x => x.CourseEnquiryId).ValueGeneratedOnAdd()
                .HasColumnName("courseEnquiryId")
                .HasColumnType("INT");
           
            builder.Property(e => e.CourseId).HasColumnName("courseId");

            builder.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");

            builder.Property(e => e.EnquiryStatus)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("enquiryStatus");

            builder.Property(e => e.PhoneNo)
                .HasMaxLength(10)
                .HasColumnName("phoneNo")
                .IsFixedLength(true);

            builder.Property(e => e.Qualification)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("qualification");

            builder.Property(e => e.TestScore).HasColumnName("testScore");

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("userName");

            builder.HasOne(d => d.Course)
                .WithMany(p => p.CourseEnquiries)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_CourseEnquiry_Courses");
        }
    }
}
