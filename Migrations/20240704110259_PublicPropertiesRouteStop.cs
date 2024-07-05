using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bussbiljettbokningssystem.Migrations
{
    /// <inheritdoc />
    public partial class PublicPropertiesRouteStop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Stops",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Stops",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Stops",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Edge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PreviousStopId = table.Column<int>(type: "INTEGER", nullable: true),
                    NextStopId = table.Column<int>(type: "INTEGER", nullable: true),
                    RouteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edge_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Edge_Stops_NextStopId",
                        column: x => x.NextStopId,
                        principalTable: "Stops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Edge_Stops_PreviousStopId",
                        column: x => x.PreviousStopId,
                        principalTable: "Stops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stops_RouteId",
                table: "Stops",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Edge_NextStopId",
                table: "Edge",
                column: "NextStopId");

            migrationBuilder.CreateIndex(
                name: "IX_Edge_PreviousStopId",
                table: "Edge",
                column: "PreviousStopId");

            migrationBuilder.CreateIndex(
                name: "IX_Edge_RouteId",
                table: "Edge",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stops_Routes_RouteId",
                table: "Stops",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stops_Routes_RouteId",
                table: "Stops");

            migrationBuilder.DropTable(
                name: "Edge");

            migrationBuilder.DropIndex(
                name: "IX_Stops_RouteId",
                table: "Stops");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Stops");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Stops");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Stops");
        }
    }
}
