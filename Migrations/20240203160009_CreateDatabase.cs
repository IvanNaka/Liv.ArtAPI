using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Liv.ArtAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curador",
                columns: table => new
                {
                    CuradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Formacao = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DocumentoPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curador", x => x.CuradorId);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    País = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    LoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.LoteId);
                });

            migrationBuilder.CreateTable(
                name: "Avaliador",
                columns: table => new
                {
                    AvaliadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CertificadoPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DocumentoPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Formacao = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CuradorId = table.Column<int>(type: "int", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliador", x => x.AvaliadorId);
                    table.ForeignKey(
                        name: "FK_Avaliador_Curador_CuradorId",
                        column: x => x.CuradorId,
                        principalTable: "Curador",
                        principalColumn: "CuradorId");
                });

            migrationBuilder.CreateTable(
                name: "Comprador",
                columns: table => new
                {
                    AvaliadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentoPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprador", x => x.AvaliadorId);
                    table.ForeignKey(
                        name: "FK_Comprador_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId");
                });

            migrationBuilder.CreateTable(
                name: "Proprietario",
                columns: table => new
                {
                    ProprietarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentoPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: true),
                    CuradorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietario", x => x.ProprietarioId);
                    table.ForeignKey(
                        name: "FK_Proprietario_Curador_CuradorId",
                        column: x => x.CuradorId,
                        principalTable: "Curador",
                        principalColumn: "CuradorId");
                    table.ForeignKey(
                        name: "FK_Proprietario_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId");
                });

            migrationBuilder.CreateTable(
                name: "Leilao",
                columns: table => new
                {
                    LeilaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LoteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leilao", x => x.LeilaoId);
                    table.ForeignKey(
                        name: "FK_Leilao_Lote_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lote",
                        principalColumn: "LoteId");
                });

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    CartaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEscrito = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Validade = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PrimeirosCinco = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CompradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.CartaoId);
                    table.ForeignKey(
                        name: "FK_Cartao_Comprador_CompradorId",
                        column: x => x.CompradorId,
                        principalTable: "Comprador",
                        principalColumn: "AvaliadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObraArte",
                columns: table => new
                {
                    ObraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artista = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Dimensao = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Tecnica = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ProprietarioId = table.Column<int>(type: "int", nullable: false),
                    AvaliadorId = table.Column<int>(type: "int", nullable: true),
                    LoteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObraArte", x => x.ObraId);
                    table.ForeignKey(
                        name: "FK_ObraArte_Avaliador_AvaliadorId",
                        column: x => x.AvaliadorId,
                        principalTable: "Avaliador",
                        principalColumn: "AvaliadorId");
                    table.ForeignKey(
                        name: "FK_ObraArte_Lote_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lote",
                        principalColumn: "LoteId");
                    table.ForeignKey(
                        name: "FK_ObraArte_Proprietario_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietario",
                        principalColumn: "ProprietarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lance",
                columns: table => new
                {
                    LanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompradorId = table.Column<int>(type: "int", nullable: true),
                    LeilaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lance", x => x.LanceId);
                    table.ForeignKey(
                        name: "FK_Lance_Comprador_CompradorId",
                        column: x => x.CompradorId,
                        principalTable: "Comprador",
                        principalColumn: "AvaliadorId");
                    table.ForeignKey(
                        name: "FK_Lance_Leilao_LeilaoId",
                        column: x => x.LeilaoId,
                        principalTable: "Leilao",
                        principalColumn: "LeilaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    PagamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    CompradorId = table.Column<int>(type: "int", nullable: false),
                    CartaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.PagamentoId);
                    table.ForeignKey(
                        name: "FK_Pagamento_Cartao_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartao",
                        principalColumn: "CartaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamento_Comprador_CompradorId",
                        column: x => x.CompradorId,
                        principalTable: "Comprador",
                        principalColumn: "AvaliadorId");
                });

            migrationBuilder.CreateTable(
                name: "Laudo",
                columns: table => new
                {
                    LaudoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Autenticidade = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ValorEstimado = table.Column<double>(type: "float", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AvaliadorId = table.Column<int>(type: "int", nullable: false),
                    ObraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laudo", x => x.LaudoId);
                    table.ForeignKey(
                        name: "FK_Laudo_Avaliador_AvaliadorId",
                        column: x => x.AvaliadorId,
                        principalTable: "Avaliador",
                        principalColumn: "AvaliadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Laudo_ObraArte_ObraId",
                        column: x => x.ObraId,
                        principalTable: "ObraArte",
                        principalColumn: "ObraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliador_CuradorId",
                table: "Avaliador",
                column: "CuradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_CompradorId",
                table: "Cartao",
                column: "CompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comprador_EnderecoId",
                table: "Comprador",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lance_CompradorId",
                table: "Lance",
                column: "CompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lance_LeilaoId",
                table: "Lance",
                column: "LeilaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Laudo_AvaliadorId",
                table: "Laudo",
                column: "AvaliadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Laudo_ObraId",
                table: "Laudo",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Leilao_LoteId",
                table: "Leilao",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ObraArte_AvaliadorId",
                table: "ObraArte",
                column: "AvaliadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ObraArte_LoteId",
                table: "ObraArte",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ObraArte_ProprietarioId",
                table: "ObraArte",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_CartaoId",
                table: "Pagamento",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_CompradorId",
                table: "Pagamento",
                column: "CompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietario_CuradorId",
                table: "Proprietario",
                column: "CuradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietario_EnderecoId",
                table: "Proprietario",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lance");

            migrationBuilder.DropTable(
                name: "Laudo");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Leilao");

            migrationBuilder.DropTable(
                name: "ObraArte");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "Avaliador");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "Proprietario");

            migrationBuilder.DropTable(
                name: "Comprador");

            migrationBuilder.DropTable(
                name: "Curador");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
