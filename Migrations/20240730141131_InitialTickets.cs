using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    StartId = table.Column<int>(type: "INTEGER", nullable: true),
                    DestinationId = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Stops_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Stops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Stops_StartId",
                        column: x => x.StartId,
                        principalTable: "Stops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DestinationId",
                table: "Tickets",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StartId",
                table: "Tickets",
                column: "StartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
