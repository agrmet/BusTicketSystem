using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bussbiljettbokningssystem.Migrations
{
    /// <inheritdoc />
    public partial class Edges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edge_Routes_RouteId",
                table: "Edge");

            migrationBuilder.DropForeignKey(
                name: "FK_Edge_Stops_NextStopId",
                table: "Edge");

            migrationBuilder.DropForeignKey(
                name: "FK_Edge_Stops_PreviousStopId",
                table: "Edge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Edge",
                table: "Edge");

            migrationBuilder.RenameTable(
                name: "Edge",
                newName: "Edges");

            migrationBuilder.RenameIndex(
                name: "IX_Edge_RouteId",
                table: "Edges",
                newName: "IX_Edges_RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Edge_PreviousStopId",
                table: "Edges",
                newName: "IX_Edges_PreviousStopId");

            migrationBuilder.RenameIndex(
                name: "IX_Edge_NextStopId",
                table: "Edges",
                newName: "IX_Edges_NextStopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Edges",
                table: "Edges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Edges_Routes_RouteId",
                table: "Edges",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edges_Routes_RouteId",
                table: "Edges");

            migrationBuilder.DropForeignKey(
                name: "FK_Edges_Stops_NextStopId",
                table: "Edges");

            migrationBuilder.DropForeignKey(
                name: "FK_Edges_Stops_PreviousStopId",
                table: "Edges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Edges",
                table: "Edges");

            migrationBuilder.RenameTable(
                name: "Edges",
                newName: "Edge");

            migrationBuilder.RenameIndex(
                name: "IX_Edges_RouteId",
                table: "Edge",
                newName: "IX_Edge_RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Edges_PreviousStopId",
                table: "Edge",
                newName: "IX_Edge_PreviousStopId");

            migrationBuilder.RenameIndex(
                name: "IX_Edges_NextStopId",
                table: "Edge",
                newName: "IX_Edge_NextStopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Edge",
                table: "Edge",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Edge_Routes_RouteId",
                table: "Edge",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Edge_Stops_NextStopId",
                table: "Edge",
                column: "NextStopId",
                principalTable: "Stops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Edge_Stops_PreviousStopId",
                table: "Edge",
                column: "PreviousStopId",
                principalTable: "Stops",
                principalColumn: "Id");
        }
    }
}
