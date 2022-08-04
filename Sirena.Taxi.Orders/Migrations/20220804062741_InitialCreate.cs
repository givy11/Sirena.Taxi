using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sirena.Taxi.Orders.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order_requests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    departure_address = table.Column<string>(type: "text", nullable: false),
                    departure_longitude = table.Column<double>(type: "double precision", nullable: false),
                    departure_latitude = table.Column<double>(type: "double precision", nullable: false),
                    destination_address = table.Column<string>(type: "text", nullable: false),
                    destination_longitude = table.Column<double>(type: "double precision", nullable: false),
                    destination_latitude = table.Column<double>(type: "double precision", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: true),
                    state_code = table.Column<int>(type: "integer", nullable: false),
                    status_code = table.Column<int>(type: "integer", nullable: false),
                    response_received = table.Column<bool>(type: "boolean", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_requests", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_requests");
        }
    }
}
