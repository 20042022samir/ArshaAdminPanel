using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArshaAdminPanelll.Migrations
{
    public partial class addedmanytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "socialMedias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "jobsposition",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "socialMedias");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "jobsposition");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "employees");
        }
    }
}
