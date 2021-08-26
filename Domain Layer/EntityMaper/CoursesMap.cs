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
    public class CoursesMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

            builder.HasKey(e => e.Id)
                    .HasName("Course_Id");

            builder.Property(e => e.CourseAvaiStatus).HasColumnName("Course_AvaiStatus");

            builder.Property(e => e.CourseDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Course_Description");

            builder.Property(e => e.CourseDuration).HasColumnName("Course_Duration");

            builder.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Course_Name");

            builder.Property(e => e.CoursePrice).HasColumnName("Course_Price");

            builder.Property(e => e.CourseRecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Course_Record_Date")
                    .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.CourseUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Course_Update_Date")
                    .HasDefaultValueSql("(getdate())");
           

        }
    }
}
