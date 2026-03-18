using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace MyAcademyMediatorProject.Migrations
{
    public partial class UpdateSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eğer kolonlar yoksa ekliyoruz
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "Sliders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForegroundImageUrl",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundImageUrl",
                table: "Sliders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sliders",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Geri almak istersek kolonları kaldırıyoruz
            migrationBuilder.DropColumn(name: "Title", table: "Sliders");
            migrationBuilder.DropColumn(name: "Subtitle", table: "Sliders");
            migrationBuilder.DropColumn(name: "ForegroundImageUrl", table: "Sliders");
            migrationBuilder.DropColumn(name: "BackgroundImageUrl", table: "Sliders");
            migrationBuilder.DropColumn(name: "IsActive", table: "Sliders");
        }
    }
}