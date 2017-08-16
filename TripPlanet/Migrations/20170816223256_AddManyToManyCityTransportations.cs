using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripPlanet.Migrations
{
    public partial class AddManyToManyCityTransportations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArrivalCityId",
                table: "Transportations",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartureCityId",
                table: "Transportations",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CityTransportations",
                columns: table => new
                {
                    TransportationId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTransportations", x => new { x.TransportationId, x.CityId });
                    table.ForeignKey(
                        name: "FK_CityTransportations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityTransportations_Transportations_TransportationId",
                        column: x => x.TransportationId,
                        principalTable: "Transportations",
                        principalColumn: "TransportationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityTransportations_CityId",
                table: "CityTransportations",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityTransportations");

            migrationBuilder.DropColumn(
                name: "ArrivalCityId",
                table: "Transportations");

            migrationBuilder.DropColumn(
                name: "DepartureCityId",
                table: "Transportations");
        }
    }
}
