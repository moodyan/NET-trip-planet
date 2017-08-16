using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripPlanet.Migrations
{
    public partial class OneCityToManyActivitiesLodgings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Lodgings",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Activities",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lodgings_CityId",
                table: "Lodgings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CityId",
                table: "Activities",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Cities_CityId",
                table: "Activities",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lodgings_Cities_CityId",
                table: "Lodgings",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Cities_CityId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Lodgings_Cities_CityId",
                table: "Lodgings");

            migrationBuilder.DropIndex(
                name: "IX_Lodgings_CityId",
                table: "Lodgings");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CityId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Lodgings");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Activities");
        }
    }
}
