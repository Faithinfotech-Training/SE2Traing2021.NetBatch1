using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.EntityMaper
{
    public class BatchMap : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {

            builder.HasKey(e => e.BatchId)
               .HasName("pk_batchId");

            builder.Property(e => e.Capacity).HasColumnName("capacity");

            builder.Property(e => e.CourseId).HasColumnName("courseId");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("createdAt");

            builder.Property(e => e.IsActive).HasColumnName("isActive");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            builder.HasOne(d => d.course)
                .WithMany(p => p.Batches)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Batches_Courses");



        }
    }
}
