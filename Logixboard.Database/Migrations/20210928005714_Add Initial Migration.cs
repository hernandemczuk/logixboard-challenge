using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logixboard.Database.Migrations
{
    public partial class AddInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    ReferenceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstimatedTimeArrival = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.ReferenceId);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    NodeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    ShipmentReferenceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.NodeId);
                    table.ForeignKey(
                        name: "FK_Nodes_Shipments_ShipmentReferenceId",
                        column: x => x.ShipmentReferenceId,
                        principalTable: "Shipments",
                        principalColumn: "ReferenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationShipment",
                columns: table => new
                {
                    OrganizationsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShipmentsReferenceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationShipment", x => new { x.OrganizationsId, x.ShipmentsReferenceId });
                    table.ForeignKey(
                        name: "FK_OrganizationShipment_Organizations_OrganizationsId",
                        column: x => x.OrganizationsId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationShipment_Shipments_ShipmentsReferenceId",
                        column: x => x.ShipmentsReferenceId,
                        principalTable: "Shipments",
                        principalColumn: "ReferenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ShipmentReferenceId",
                table: "Nodes",
                column: "ShipmentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationShipment_ShipmentsReferenceId",
                table: "OrganizationShipment",
                column: "ShipmentsReferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "OrganizationShipment");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
