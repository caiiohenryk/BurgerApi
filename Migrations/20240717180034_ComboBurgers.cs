using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApi.Migrations
{
    /// <inheritdoc />
    public partial class ComboBurgers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ComboId",
                table: "Burgers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Preco = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Burgers_ComboId",
                table: "Burgers",
                column: "ComboId");

            migrationBuilder.AddForeignKey(
                name: "FK_Burgers_Combos_ComboId",
                table: "Burgers",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Burgers_Combos_ComboId",
                table: "Burgers");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropIndex(
                name: "IX_Burgers_ComboId",
                table: "Burgers");

            migrationBuilder.DropColumn(
                name: "ComboId",
                table: "Burgers");
        }
    }
}
