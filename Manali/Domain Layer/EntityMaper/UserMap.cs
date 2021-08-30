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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("User");


            builder.HasKey(e => e.Id)
                    .HasName("Userman_Id");



            builder.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("User_Email");

            builder.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("User_Name");

            builder.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("User_Password");

            builder.Property(e => e.UserPhoneN)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("User_PhoneN");

            builder.Property(e => e.UserRecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("User_Record_Date")
                    .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.UserUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("User_Update_Date")
                    .HasDefaultValueSql("(getdate())");

                builder.HasOne(d => d.UserClaim)
                    .WithMany(p => p.Users)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__User_Claim__30F848ED");
           

        }
    }
}
