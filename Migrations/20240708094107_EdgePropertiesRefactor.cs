using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class EdgePropertiesRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edges_Stops_NextStopId",
                table: "Edges");

            migrationBuilder.DropForeignKey(
                name: "FK_Edges_Stops_PreviousStopId",
                table: "Edges");

            migrationBuilder.RenameColumn(
                name: "PreviousStopId",
                table: "Edges",
                newName: "StartId");

            migrationBuilder.RenameColumn(
                name: "NextStopId",
                table: "Edges",
                newName: "EndId");

            migrationBuilder.RenameIndex(
                name: "IX_Edges_PreviousStopId",
                table: "Edges",
                newName: "IX_Edges_StartId");

            migrationBuilder.RenameIndex(
                name: "IX_Edges_NextStopId",
                table: "Edges",
                newName: "IX_Edges_EndId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edges_Stops_EndId",
                table: "Edges",
                column: "EndId",
                principalTable: "Stops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Edges_Stops_StartId",
                table: "Edges",
                column: "StartId",
                principalTable: "Stops",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edges_Stops_EndId",
                table: "Edges");

            migrationBuilder.DropForeignKey(
                name: "FK_Edges_Stops_StartId",
                table: "Edges");

            migrationBuilder.RenameColumn(
                name: "StartId",
                table: "Edges",
                newName: "PreviousStopId");

            migrationBuilder.RenameColumn(
                name: "EndId",
                table: "Edges",
                newName: "NextStopId");

            migrationBuilder.RenameIndex(
                name: "IX_Edges_StartId",
                table: "Edges",
                newName: "IX_Edges_PreviousStopId");

            migrationBuilder.RenameIndex(
                name: "IX_Edges_EndId",
                table: "Edges",
                newName: "IX_Edges_NextStopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edges_Stops_NextStopId",
                table: "Edges",
                column: "NextStopId",
                principalTable: "Stops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Edges_Stops_PreviousStopId",
                table: "Edges",
                column: "PreviousStopId",
                principalTable: "Stops",
                principalColumn: "Id");
        }
    }
}
