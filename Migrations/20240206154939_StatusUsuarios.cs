using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Liv.ArtAPI.Migrations
{
    /// <inheritdoc />
    public partial class StatusUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliador_Status_StatusId",
                table: "Avaliador");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataNascimento",
                table: "Proprietario",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "Proprietario",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataNascimento",
                table: "Comprador",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataNascimento",
                table: "Avaliador",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietario_StatusId",
                table: "Proprietario",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliador_Status_StatusId",
                table: "Avaliador",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "NomeStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Proprietario_Status_StatusId",
                table: "Proprietario",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "NomeStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliador_Status_StatusId",
                table: "Avaliador");

            migrationBuilder.DropForeignKey(
                name: "FK_Proprietario_Status_StatusId",
                table: "Proprietario");

            migrationBuilder.DropIndex(
                name: "IX_Proprietario_StatusId",
                table: "Proprietario");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Proprietario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Proprietario",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Comprador",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Avaliador",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliador_Status_StatusId",
                table: "Avaliador",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "NomeStatus",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
