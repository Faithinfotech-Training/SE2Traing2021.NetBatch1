using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Intial_SR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Course_Desc = table.Column<string>(type: "Varchar(500)", nullable: false),
                    Course_Duration = table.Column<int>(type: "INT", nullable: false),
                    Course_Price = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Course_Availability = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_courseId", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resource_Name = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Resource_Desc = table.Column<string>(type: "Varchar(500)", nullable: false),
                    Resource_Price = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    visibility = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_resourceId", x => x.ResourceId);
                });

            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "date", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_batchId", x => x.BatchId);
                    table.ForeignKey(
                        name: "FK_Batches_Courses",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseEnquiry",
                columns: table => new
                {
                    courseEnquiryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phoneNo = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    qualification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    testScore = table.Column<int>(type: "int", nullable: true),
                    enquiryStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_courseEnquiryId", x => x.courseEnquiryId);
                    table.ForeignKey(
                        name: "FK_CourseEnquiry_Courses",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourceEnquiry",
                columns: table => new
                {
                    resourceEnquiryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resourceId = table.Column<int>(type: "int", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phoneNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    enquiryStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_resourceEnquiryId", x => x.resourceEnquiryId);
                    table.ForeignKey(
                        name: "FK_ResourceEnquiry_Resources",
                        column: x => x.resourceId,
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    TraineeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    batchId = table.Column<int>(type: "int", nullable: true),
                    courseEnqId = table.Column<int>(type: "INT", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_traineeId", x => x.TraineeId);
                    table.ForeignKey(
                        name: "FK_Trainees_CourseEnquiry",
                        column: x => x.courseEnqId,
                        principalTable: "CourseEnquiry",
                        principalColumn: "courseEnquiryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batch_courseId",
                table: "Batch",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnquiry_courseId",
                table: "CourseEnquiry",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceEnquiry_resourceId",
                table: "ResourceEnquiry",
                column: "resourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_courseEnqId",
                table: "Trainee",
                column: "courseEnqId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "ResourceEnquiry");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "CourseEnquiry");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
