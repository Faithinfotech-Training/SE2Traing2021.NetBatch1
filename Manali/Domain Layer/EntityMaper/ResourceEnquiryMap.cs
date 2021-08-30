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
    public class ResourceEnquiryMap : IEntityTypeConfiguration<resourceEnquiry>
    {
        public void Configure(EntityTypeBuilder<resourceEnquiry> builder)
        {


         
            builder.ToTable("ResourceEnquiry");


            builder.HasKey(e => e.Id)
                    .HasName("Resenq_Id");


            builder.Property(e => e.ResourceEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Resource_Email");


            builder.Property(e => e.ResourceErecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Resource_ERecord_Date")
                    .HasDefaultValueSql("(getdate())");

            

            builder.Property(e => e.ResourceFullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Resource_FullName");

            builder.Property(e => e.ResourcePhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Resource_Phone");

            builder.Property(e => e.ResourceStatus)
                .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                .HasColumnName("Resource_Status");

            builder.Property(e => e.resourceId)
                .HasColumnName("resourceId");

            builder.HasOne(d => d.resource)
                   .WithMany(p => p.resourceEnquiries)
                   .HasForeignKey(p=> p.resourceId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK__ResourseE__Resou__300424B4");


        }
    }
}
