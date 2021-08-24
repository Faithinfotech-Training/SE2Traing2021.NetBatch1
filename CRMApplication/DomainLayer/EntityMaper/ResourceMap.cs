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
    public class ResourceMap : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(x => x.ResourceId)
                .HasName("pk_resourceId");

            builder.Property(x => x.ResourceName)
                .HasColumnName("Resource_Name")
                .HasColumnType("Varchar(100)")
                .IsRequired();
            builder.Property(x => x.ResourceDesc)
               .HasColumnName("Resource_Desc")
               .HasColumnType("Varchar(500)")
               .IsRequired();

            builder.Property(e => e.ResourcePrice).HasColumnName("price")
                .HasColumnName("Resource_Price")
               .HasColumnType("DECIMAL")
               .IsRequired();

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("type");

            builder.Property(e => e.Visibility).HasColumnName("visibility");

        }
    }
}
