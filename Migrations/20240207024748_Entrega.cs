using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Liv.ArtAPI.Migrations
{
    /// <inheritdoc />
    public partial class Entrega : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "Pagamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_LoteId",
                table: "Pagamento",
                column: "LoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_Lote_LoteId",
                table: "Pagamento",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "LoteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_Lote_LoteId",
                table: "Pagamento");

            migrationBuilder.DropIndex(
                name: "IX_Pagamento_LoteId",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "Pagamento");
        }
    }
}
