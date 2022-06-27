using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace application.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    transactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    transactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.transactionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_name",
                table: "Products",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_transactionId",
                table: "Transactions",
                column: "transactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_name",
                table: "Users",
                column: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
