using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Liv.ArtAPI.Migrations
{
    /// <inheritdoc />
    public partial class EntregaCompradorAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrega",
                columns: table => new
                {
                    EntregaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagamentoId = table.Column<int>(type: "int", nullable: false),
                    ProprietarioId = table.Column<int>(type: "int", nullable: false),
                    CompradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrega", x => x.EntregaId);
                    table.ForeignKey(
                        name: "FK_Entrega_Comprador_CompradorId",
                        column: x => x.CompradorId,
                        principalTable: "Comprador",
                        principalColumn: "CompradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrega_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "PagamentoId");
                    table.ForeignKey(
                        name: "FK_Entrega_Proprietario_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietario",
                        principalColumn: "ProprietarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_CompradorId",
                table: "Entrega",
                column: "CompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_PagamentoId",
                table: "Entrega",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_ProprietarioId",
                table: "Entrega",
                column: "ProprietarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrega");
        }
    }
}
