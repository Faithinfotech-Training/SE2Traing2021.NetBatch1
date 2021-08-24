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
    public class ResourceEnquiryMap : IEntityTypeConfiguration<ResourceEnquiry>
    {
        public void Configure(EntityTypeBuilder<ResourceEnquiry> builder)
        {

            builder.ToTable("ResourceEnquiry");

            builder.HasKey(x => x.ResourceEnqId)
                .HasName("pk_resourceEnquiryId");
            builder.Property(x => x.ResourceEnqId).ValueGeneratedOnAdd()
                .HasColumnName("resourceEnquiryId")
                .HasColumnType("INT");

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");

            builder.Property(e => e.EnquiryStatus)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("enquiryStatus");

            builder.Property(e => e.PhoneNo)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("phoneNo");

            builder.Property(e => e.ResourceId).HasColumnName("resourceId");

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("userName");

            builder.HasOne(d => d.Resource)
                .WithMany(p => p.ResourceEnquiries)
                .HasForeignKey(d => d.ResourceId)
                .HasConstraintName("FK_ResourceEnquiry_Resources");
        }
    }
}
