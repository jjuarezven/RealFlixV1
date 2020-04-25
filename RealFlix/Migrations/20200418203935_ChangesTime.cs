using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealFlix.Migrations
{
    public partial class ChangesTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ScheduledTime",
                table: "Show",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduledTime",
                table: "Show",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
