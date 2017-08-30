using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripPlanet.Migrations
{
    public partial class RefactorCityTransportationTblRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityTransportations");

            migrationBuilder.RenameColumn(
                name: "DepartureCityId",
                table: "Transportations",
                newName: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportations_CityId",
                table: "Transportations",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transportations_Cities_CityId",
                table: "Transportations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transportations_Cities_CityId",
                table: "Transportations");

            migrationBuilder.DropIndex(
                name: "IX_Transportations_CityId",
                table: "Transportations");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Transportations",
                newName: "DepartureCityId");

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
    }
}
