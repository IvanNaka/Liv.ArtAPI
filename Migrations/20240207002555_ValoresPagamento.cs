using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Liv.ArtAPI.Migrations
{
    /// <inheritdoc />
    public partial class ValoresPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Pagamento",
                newName: "ValorProprietario");

            migrationBuilder.AddColumn<double>(
                name: "ValorAvaliador",
                table: "Pagamento",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorFinal",
                table: "Pagamento",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorAvaliador",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "ValorFinal",
                table: "Pagamento");

            migrationBuilder.RenameColumn(
                name: "ValorProprietario",
                table: "Pagamento",
                newName: "Valor");
        }
    }
}
