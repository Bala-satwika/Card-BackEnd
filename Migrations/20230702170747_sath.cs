using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiAndAsp.Migrations
{
    /// <inheritdoc />
    public partial class sath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cardHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expiryMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expiryYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cvc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cards", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cards");
        }
    }
}
