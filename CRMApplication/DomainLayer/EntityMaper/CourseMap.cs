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
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.CourseId)
                .HasName("pk_courseId");
          

            builder.Property(x => x.CourseName)
                .HasColumnName("Course_Name")
                .HasColumnType("Varchar(100)")
                .IsRequired();
            builder.Property(x => x.CourseDesc)
               .HasColumnName("Course_Desc")
               .HasColumnType("Varchar(500)")
               .IsRequired();
            
            builder.Property(x => x.CourseDuration)
                .HasColumnName("Course_Duration")
                .HasColumnType("INT")
                .IsRequired(); 
            builder.Property(x => x.CoursePrice)
                .HasColumnName("Course_Price")
                .HasColumnType("DECIMAL")
                .IsRequired();
            builder.Property(x => x.CourseAvailability)
              .HasColumnName("Course_Availability")
              .HasColumnType("bit")
              .IsRequired();
        }
    }
}
