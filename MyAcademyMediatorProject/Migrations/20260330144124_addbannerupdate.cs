using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademyMediatorProject.Migrations
{
    /// <inheritdoc />
    public partial class addbannerupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNo",
                table: "Banners",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "Banners");
        }
    }
}
