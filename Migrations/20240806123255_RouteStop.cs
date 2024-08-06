using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class RouteStop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edges_Routes_RouteId",
                table: "Edges");

            migrationBuilder.DropForeignKey(
                name: "FK_Stops_Routes_RouteId",
                table: "Stops");

            migrationBuilder.DropIndex(
                name: "IX_Stops_RouteId",
                table: "Stops");

            migrationBuilder.DropIndex(
                name: "IX_Edges_RouteId",
                table: "Edges");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Stops");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Edges");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tickets",
                newName: "PassengerId");

            migrationBuilder.CreateTable(
                name: "RouteStop",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "INTEGER", nullable: false),
                    StopId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteStop", x => new { x.RouteId, x.StopId });
                    table.ForeignKey(
                        name: "FK_RouteStop_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteStop_Stops_StopId",
                        column: x => x.StopId,
                        principalTable: "Stops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStop_StopId",
                table: "RouteStop",
                column: "StopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_User_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_User_PassengerId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "RouteStop");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "Tickets",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Stops",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Edges",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stops_RouteId",
                table: "Stops",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Edges_RouteId",
                table: "Edges",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edges_Routes_RouteId",
                table: "Edges",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stops_Routes_RouteId",
                table: "Stops",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }
    }
}
