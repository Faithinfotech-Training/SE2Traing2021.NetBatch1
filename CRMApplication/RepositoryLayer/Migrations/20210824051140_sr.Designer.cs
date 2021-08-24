﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210824051140_sr")]
    partial class sr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainLayer.Models.Batch", b =>
                {
                    b.Property<int>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("capacity");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("courseId");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("createdAt");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("BatchId")
                        .HasName("pk_batchId");

                    b.HasIndex("CourseId");

                    b.ToTable("Batch");
                });

            modelBuilder.Entity("DomainLayer.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CourseAvailability")
                        .HasColumnType("bit")
                        .HasColumnName("Course_Availability");

                    b.Property<string>("CourseDesc")
                        .IsRequired()
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Course_Desc");

                    b.Property<int>("CourseDuration")
                        .HasColumnType("INT")
                        .HasColumnName("Course_Duration");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Course_Name");

                    b.Property<decimal>("CoursePrice")
                        .HasColumnType("DECIMAL")
                        .HasColumnName("Course_Price");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("CourseId")
                        .HasName("pk_courseId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("DomainLayer.Models.CourseEnquiry", b =>
                {
                    b.Property<int>("CourseEnquiryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("courseEnquiryId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("courseId");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("DOB");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("EnquiryStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("enquiryStatus");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNo")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("phoneNo")
                        .IsFixedLength(true);

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("qualification");

                    b.Property<int?>("TestScore")
                        .HasColumnType("int")
                        .HasColumnName("testScore");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("userName");

                    b.HasKey("CourseEnquiryId")
                        .HasName("pk_courseEnquiryId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseEnquiry");
                });

            modelBuilder.Entity("DomainLayer.Models.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ResourceDesc")
                        .IsRequired()
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Resource_Desc");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Resource_Name");

                    b.Property<decimal>("ResourcePrice")
                        .HasColumnType("DECIMAL")
                        .HasColumnName("Resource_Price");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("type");

                    b.Property<bool>("Visibility")
                        .HasColumnType("bit")
                        .HasColumnName("visibility");

                    b.HasKey("ResourceId")
                        .HasName("pk_resourceId");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("DomainLayer.Models.ResourceEnquiry", b =>
                {
                    b.Property<int>("ResourceEnqId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("resourceEnquiryId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("EnquiryStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("enquiryStatus");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("phoneNo");

                    b.Property<int?>("ResourceId")
                        .HasColumnType("int")
                        .HasColumnName("resourceId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("userName");

                    b.HasKey("ResourceEnqId")
                        .HasName("pk_resourceEnquiryId");

                    b.HasIndex("ResourceId");

                    b.ToTable("ResourceEnquiry");
                });

            modelBuilder.Entity("DomainLayer.Models.Trainee", b =>
                {
                    b.Property<int>("TraineeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BatchId")
                        .HasColumnType("int")
                        .HasColumnName("batchId");

                    b.Property<int?>("CourseEnqId")
                        .HasColumnType("INT")
                        .HasColumnName("courseEnqId");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("TraineeId")
                        .HasName("pk_traineeId");

                    b.HasIndex("CourseEnqId");

                    b.ToTable("Trainee");
                });

            modelBuilder.Entity("DomainLayer.Models.Batch", b =>
                {
                    b.HasOne("DomainLayer.Models.Course", "Course")
                        .WithMany("Batches")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_Batches_Courses");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("DomainLayer.Models.CourseEnquiry", b =>
                {
                    b.HasOne("DomainLayer.Models.Course", "Course")
                        .WithMany("CourseEnquiries")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_CourseEnquiry_Courses");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("DomainLayer.Models.ResourceEnquiry", b =>
                {
                    b.HasOne("DomainLayer.Models.Resource", "Resource")
                        .WithMany("ResourceEnquiries")
                        .HasForeignKey("ResourceId")
                        .HasConstraintName("FK_ResourceEnquiry_Resources");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("DomainLayer.Models.Trainee", b =>
                {
                    b.HasOne("DomainLayer.Models.CourseEnquiry", "CourseEnq")
                        .WithMany("Trainees")
                        .HasForeignKey("CourseEnqId")
                        .HasConstraintName("FK_Trainees_CourseEnquiry");

                    b.Navigation("CourseEnq");
                });

            modelBuilder.Entity("DomainLayer.Models.Course", b =>
                {
                    b.Navigation("Batches");

                    b.Navigation("CourseEnquiries");
                });

            modelBuilder.Entity("DomainLayer.Models.CourseEnquiry", b =>
                {
                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("DomainLayer.Models.Resource", b =>
                {
                    b.Navigation("ResourceEnquiries");
                });
#pragma warning restore 612, 618
        }
    }
}
