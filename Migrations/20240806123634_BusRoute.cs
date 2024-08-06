using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class BusRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Buses_BusId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_BusId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "BusId",
                table: "Routes");

            migrationBuilder.CreateTable(
                name: "BusRoute",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "INTEGER", nullable: false),
                    RouteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusRoute", x => new { x.BusId, x.RouteId });
                    table.ForeignKey(
                        name: "FK_BusRoute_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusRoute_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusRoute_RouteId",
                table: "BusRoute",
                column: "RouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusRoute");

            migrationBuilder.AddColumn<int>(
                name: "BusId",
                table: "Routes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_BusId",
                table: "Routes",
                column: "BusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Buses_BusId",
                table: "Routes",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id");
        }
    }
}
