using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripPlanet.Migrations
{
    public partial class OnePlannerToManyTrips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlannerId",
                table: "Trips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_PlannerId",
                table: "Trips",
                column: "PlannerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Planners_PlannerId",
                table: "Trips",
                column: "PlannerId",
                principalTable: "Planners",
                principalColumn: "PlannerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Planners_PlannerId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_PlannerId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "PlannerId",
                table: "Trips");
        }
    }
}
