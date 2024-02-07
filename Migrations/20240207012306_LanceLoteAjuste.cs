using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Liv.ArtAPI.Migrations
{
    /// <inheritdoc />
    public partial class LanceLoteAjuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lance_Comprador_CompradorId",
                table: "Lance");

            migrationBuilder.DropForeignKey(
                name: "FK_Lance_Leilao_LeilaoId",
                table: "Lance");

            migrationBuilder.RenameColumn(
                name: "LeilaoId",
                table: "Lance",
                newName: "LoteId");

            migrationBuilder.RenameIndex(
                name: "IX_Lance_LeilaoId",
                table: "Lance",
                newName: "IX_Lance_LoteId");

            migrationBuilder.AlterColumn<int>(
                name: "CompradorId",
                table: "Lance",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lance_Comprador_CompradorId",
                table: "Lance",
                column: "CompradorId",
                principalTable: "Comprador",
                principalColumn: "CompradorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lance_Lote_LoteId",
                table: "Lance",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "LoteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lance_Comprador_CompradorId",
                table: "Lance");

            migrationBuilder.DropForeignKey(
                name: "FK_Lance_Lote_LoteId",
                table: "Lance");

            migrationBuilder.RenameColumn(
                name: "LoteId",
                table: "Lance",
                newName: "LeilaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Lance_LoteId",
                table: "Lance",
                newName: "IX_Lance_LeilaoId");

            migrationBuilder.AlterColumn<int>(
                name: "CompradorId",
                table: "Lance",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lance_Comprador_CompradorId",
                table: "Lance",
                column: "CompradorId",
                principalTable: "Comprador",
                principalColumn: "CompradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lance_Leilao_LeilaoId",
                table: "Lance",
                column: "LeilaoId",
                principalTable: "Leilao",
                principalColumn: "LeilaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
