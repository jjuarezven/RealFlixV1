using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealFlix.Migrations
{
    public partial class NewStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Show");

            migrationBuilder.AddColumn<decimal>(
                name: "ExternalsImdb",
                table: "Show",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExternalsThetvdb",
                table: "Show",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExternalsTvrage",
                table: "Show",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ImageMedium",
                table: "Show",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageOriginal",
                table: "Show",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinksNextEpisodeHref",
                table: "Show",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinksPreviousEpisodeHref",
                table: "Show",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinksSelfHref",
                table: "Show",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetworkCountryCode",
                table: "Show",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetworkCountryName",
                table: "Show",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NetworkId",
                table: "Show",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NetworkName",
                table: "Show",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Premiered",
                table: "Show",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "RatingAverage",
                table: "Show",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Runtime",
                table: "Show",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Show",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Show",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalsImdb",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "ExternalsThetvdb",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "ExternalsTvrage",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "ImageMedium",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "ImageOriginal",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "LinksNextEpisodeHref",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "LinksPreviousEpisodeHref",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "LinksSelfHref",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "NetworkCountryCode",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "NetworkCountryName",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "NetworkId",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "NetworkName",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "Premiered",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "RatingAverage",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "Runtime",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Show");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Show",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
