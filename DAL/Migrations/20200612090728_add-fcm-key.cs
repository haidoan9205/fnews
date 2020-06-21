using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addfcmkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FcmKey",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FcmKey",
                table: "Applicant",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FcmKey",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "FcmKey",
                table: "Applicant");
        }
    }
}
