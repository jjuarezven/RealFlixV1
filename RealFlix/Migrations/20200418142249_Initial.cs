using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealFlix.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: false),
                    Genres = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Runtime = table.Column<int>(nullable: false),
                    Premiered = table.Column<DateTime>(nullable: false),
                    OfficialSite = table.Column<string>(nullable: true),
                    WebChannel = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    ScheduledTime = table.Column<DateTime>(nullable: false),
                    ScheduledDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Show");
        }
    }
}
