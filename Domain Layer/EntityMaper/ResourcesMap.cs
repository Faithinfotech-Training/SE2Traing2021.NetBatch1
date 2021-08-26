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
    public class ResourcesMap : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {



            builder.HasKey(e => e.Id)
                    .HasName("Resource_Id");


            builder.Property(e => e.ResourceAvaiStatus).HasColumnName("Resource_AvaiStatus");

            builder.Property(e => e.ResourceDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Resource_Description");

            builder.Property(e => e.ResourceName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Resource_Name");

            builder.Property(e => e.ResourceType)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false)
                   .HasColumnName("Resource_Type");

            builder.Property(e => e.ResourcePrice).HasColumnName("Resource_Price");

            builder.Property(e => e.ResourceRecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Resource_Record_Date")
                    .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.ResourceUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Resource_Update_Date")
                    .HasDefaultValueSql("(getdate())");
            

        }
    }

}
