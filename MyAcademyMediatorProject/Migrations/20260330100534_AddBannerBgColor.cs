using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademyMediatorProject.Migrations
{
    /// <inheritdoc />
    public partial class AddBannerBgColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BgColor",
                table: "Banners",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BgColor",
                table: "Banners");
        }
    }
}
