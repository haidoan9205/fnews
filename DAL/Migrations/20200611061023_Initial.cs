using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<Guid>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    ApplicantId = table.Column<Guid>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    IdentifyCardNumer = table.Column<string>(nullable: false),
                    SeflDescribe = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.ApplicantId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    TaxIdentificationNumber = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "JobType",
                columns: table => new
                {
                    JobTypeId = table.Column<Guid>(nullable: false),
                    JobTypeName = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobType", x => x.JobTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PayType",
                columns: table => new
                {
                    PayTypeId = table.Column<Guid>(nullable: false),
                    PayTypeName = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayType", x => x.PayTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillId = table.Column<Guid>(nullable: false),
                    SkillName = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobId = table.Column<Guid>(nullable: false),
                    JobName = table.Column<string>(nullable: false),
                    Salary = table.Column<float>(nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    JobDescription = table.Column<string>(nullable: true),
                    CloseDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true),
                    JobTypeId = table.Column<Guid>(nullable: true),
                    PayTypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Job_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_JobType_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobType",
                        principalColumn: "JobTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_PayType_PayTypeId",
                        column: x => x.PayTypeId,
                        principalTable: "PayType",
                        principalColumn: "PayTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantSkill",
                columns: table => new
                {
                    ApplcantId = table.Column<Guid>(nullable: false),
                    SkillId = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantSkill", x => new { x.ApplcantId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_ApplicantSkill_Applicant_ApplcantId",
                        column: x => x.ApplcantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobRequest",
                columns: table => new
                {
                    JobId = table.Column<Guid>(nullable: false),
                    ApplicantId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    IsAccept = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequest", x => new { x.ApplicantId, x.JobId });
                    table.ForeignKey(
                        name: "FK_JobRequest_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobRequest_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_Email",
                table: "Applicant",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantSkill_SkillId",
                table: "ApplicantSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CompanyId",
                table: "Job",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobTypeId",
                table: "Job",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_PayTypeId",
                table: "Job",
                column: "PayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequest_JobId",
                table: "JobRequest",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ApplicantSkill");

            migrationBuilder.DropTable(
                name: "JobRequest");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "JobType");

            migrationBuilder.DropTable(
                name: "PayType");
        }
    }
}
