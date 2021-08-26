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
    public class ResourseEnquiryMap : IEntityTypeConfiguration<ResourseEnquiry>
    {
        public void Configure(EntityTypeBuilder<ResourseEnquiry> builder)
        {


         
            builder.ToTable("ResourseEnquiry");


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

            builder.Property(e => e.ResourceEupdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Resource_EUpdate_Date")
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

            builder.Property(e => e.ResourceStatus).HasColumnName("Resource_Status");

            builder.HasOne(d => d.ResourceEn)
                    .WithMany(p => p.ResourseEnquiries)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ResourseE__Resou__300424B4");
          

        }
    }
}
