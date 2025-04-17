using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaProject.Migrations
{
    public partial class FixFilmColumnsTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Очистка таблиці Films
            migrationBuilder.Sql("DELETE FROM Films");

            // Перейменування колонок Id -> ID (не обов’язково, якщо це вже було)
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sessions",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sales",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            // Відновлення назв колонок (якщо потрібно)
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Sessions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Sales",
                newName: "Id");
        }
    }
}