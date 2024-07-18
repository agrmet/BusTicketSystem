using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class RoutesInBus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
