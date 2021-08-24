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
    public class TraineeMap : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {

            builder.HasKey(e => e.TraineeId)
               .HasName("pk_traineeId");
           

            builder.Property(e => e.BatchId).HasColumnName("batchId");

            builder.Property(e => e.CourseEnqId).HasColumnName("courseEnqId");

            builder.HasOne(d => d.CourseEnq)
                .WithMany(p => p.Trainees)
                .HasForeignKey(d => d.CourseEnqId)
                .HasConstraintName("FK_Trainees_CourseEnquiry");
        }
    }
}
