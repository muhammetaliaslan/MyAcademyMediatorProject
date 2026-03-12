using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademyMediatorProject.Migrations
{
    /// <inheritdoc />
    public partial class updateCampaign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Campaigns",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Campaigns",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumAmount",
                table: "Campaigns",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "MinimumAmount",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Campaigns",
                newName: "Title");
        }
    }
}
