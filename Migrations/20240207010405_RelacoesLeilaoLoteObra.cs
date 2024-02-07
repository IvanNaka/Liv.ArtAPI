using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Liv.ArtAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelacoesLeilaoLoteObra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leilao_Lote_LoteId",
                table: "Leilao");

            migrationBuilder.DropIndex(
                name: "IX_Leilao_LoteId",
                table: "Leilao");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "Leilao");

            migrationBuilder.AddColumn<int>(
                name: "LeilaoId",
                table: "Lote",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lote_LeilaoId",
                table: "Lote",
                column: "LeilaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lote_Leilao_LeilaoId",
                table: "Lote",
                column: "LeilaoId",
                principalTable: "Leilao",
                principalColumn: "LeilaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lote_Leilao_LeilaoId",
                table: "Lote");

            migrationBuilder.DropIndex(
                name: "IX_Lote_LeilaoId",
                table: "Lote");

            migrationBuilder.DropColumn(
                name: "LeilaoId",
                table: "Lote");

            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "Leilao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leilao_LoteId",
                table: "Leilao",
                column: "LoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leilao_Lote_LoteId",
                table: "Leilao",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "LoteId");
        }
    }
}
