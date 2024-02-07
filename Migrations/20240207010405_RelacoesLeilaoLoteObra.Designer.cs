﻿// <auto-generated />
using System;
using LivArt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Liv.ArtAPI.Migrations
{
    [DbContext(typeof(LivArtContext))]
    [Migration("20240207010405_RelacoesLeilaoLoteObra")]
    partial class RelacoesLeilaoLoteObra
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Avaliador", b =>
                {
                    b.Property<int>("AvaliadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvaliadorId"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CertificadoPath")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("CuradorId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("DocumentoPath")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Formacao")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("AvaliadorId");

                    b.HasIndex("CuradorId");

                    b.HasIndex("StatusId");

                    b.ToTable("Avaliador");
                });

            modelBuilder.Entity("Cartao", b =>
                {
                    b.Property<int>("CartaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartaoId"));

                    b.Property<int>("CompradorId")
                        .HasColumnType("int");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("NomeEscrito")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("PrimeirosCinco")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Validade")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("CartaoId");

                    b.HasIndex("CompradorId");

                    b.ToTable("Cartao");
                });

            modelBuilder.Entity("Comprador", b =>
                {
                    b.Property<int>("CompradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompradorId"));

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("DocumentoPath")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("CompradorId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Comprador");
                });

            modelBuilder.Entity("Curador", b =>
                {
                    b.Property<int>("CuradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuradorId"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentoPath")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Formacao")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("CuradorId");

                    b.ToTable("Curador");
                });

            modelBuilder.Entity("Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnderecoId"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("País")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("EnderecoId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Lance", b =>
                {
                    b.Property<int>("LanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanceId"));

                    b.Property<int?>("CompradorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeilaoId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("LanceId");

                    b.HasIndex("CompradorId");

                    b.HasIndex("LeilaoId");

                    b.ToTable("Lance");
                });

            modelBuilder.Entity("Laudo", b =>
                {
                    b.Property<int>("LaudoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LaudoId"));

                    b.Property<string>("Autenticidade")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("AvaliadorId")
                        .HasColumnType("int");

                    b.Property<int>("ObraId")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<double>("ValorEstimado")
                        .HasColumnType("float");

                    b.HasKey("LaudoId");

                    b.HasIndex("AvaliadorId");

                    b.HasIndex("ObraId");

                    b.ToTable("Laudo");
                });

            modelBuilder.Entity("Leilao", b =>
                {
                    b.Property<int>("LeilaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeilaoId"));

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("LeilaoId");

                    b.ToTable("Leilao");
                });

            modelBuilder.Entity("Lote", b =>
                {
                    b.Property<int>("LoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoteId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("LeilaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("LoteId");

                    b.HasIndex("LeilaoId");

                    b.ToTable("Lote");
                });

            modelBuilder.Entity("ObraArte", b =>
                {
                    b.Property<int>("ObraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObraId"));

                    b.Property<string>("Artista")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("AvaliadorId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("DataCriacao")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Dimensao")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("LoteId")
                        .HasColumnType("int");

                    b.Property<int>("ProprietarioId")
                        .HasColumnType("int");

                    b.Property<string>("Tecnica")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ObraId");

                    b.HasIndex("AvaliadorId");

                    b.HasIndex("LoteId");

                    b.HasIndex("ProprietarioId");

                    b.ToTable("ObraArte");
                });

            modelBuilder.Entity("Pagamento", b =>
                {
                    b.Property<int>("PagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagamentoId"));

                    b.Property<int>("CartaoId")
                        .HasColumnType("int");

                    b.Property<int>("CompradorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<double>("ValorAvaliador")
                        .HasColumnType("float");

                    b.Property<double>("ValorFinal")
                        .HasColumnType("float");

                    b.Property<double>("ValorProprietario")
                        .HasColumnType("float");

                    b.HasKey("PagamentoId");

                    b.HasIndex("CartaoId");

                    b.HasIndex("CompradorId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("Proprietario", b =>
                {
                    b.Property<int>("ProprietarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProprietarioId"));

                    b.Property<int?>("CuradorId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("DocumentoPath")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("ProprietarioId");

                    b.HasIndex("CuradorId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("StatusId");

                    b.ToTable("Proprietario");
                });

            modelBuilder.Entity("Status", b =>
                {
                    b.Property<string>("NomeStatus")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NomeDescritivo")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("NomeStatus");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Avaliador", b =>
                {
                    b.HasOne("Curador", "Curador")
                        .WithMany()
                        .HasForeignKey("CuradorId");

                    b.HasOne("Status", "Status")
                        .WithMany("Avaliador")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Curador");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Cartao", b =>
                {
                    b.HasOne("Comprador", "Comprador")
                        .WithMany()
                        .HasForeignKey("CompradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comprador");
                });

            modelBuilder.Entity("Comprador", b =>
                {
                    b.HasOne("Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Lance", b =>
                {
                    b.HasOne("Comprador", "Comprador")
                        .WithMany()
                        .HasForeignKey("CompradorId");

                    b.HasOne("Leilao", "Leilao")
                        .WithMany()
                        .HasForeignKey("LeilaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comprador");

                    b.Navigation("Leilao");
                });

            modelBuilder.Entity("Laudo", b =>
                {
                    b.HasOne("Avaliador", "Avaliador")
                        .WithMany()
                        .HasForeignKey("AvaliadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObraArte", "Obra")
                        .WithMany()
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avaliador");

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("Lote", b =>
                {
                    b.HasOne("Leilao", "Leilao")
                        .WithMany("Lote")
                        .HasForeignKey("LeilaoId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Leilao");
                });

            modelBuilder.Entity("ObraArte", b =>
                {
                    b.HasOne("Avaliador", "Avaliador")
                        .WithMany()
                        .HasForeignKey("AvaliadorId");

                    b.HasOne("Lote", "Lote")
                        .WithMany("ObraArte")
                        .HasForeignKey("LoteId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Proprietario", "Proprietario")
                        .WithMany()
                        .HasForeignKey("ProprietarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avaliador");

                    b.Navigation("Lote");

                    b.Navigation("Proprietario");
                });

            modelBuilder.Entity("Pagamento", b =>
                {
                    b.HasOne("Cartao", "Cartao")
                        .WithMany()
                        .HasForeignKey("CartaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Comprador", "Comprador")
                        .WithMany("Pagamento")
                        .HasForeignKey("CompradorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cartao");

                    b.Navigation("Comprador");
                });

            modelBuilder.Entity("Proprietario", b =>
                {
                    b.HasOne("Curador", "Curador")
                        .WithMany()
                        .HasForeignKey("CuradorId");

                    b.HasOne("Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("Status", "Status")
                        .WithMany("Proprietario")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Curador");

                    b.Navigation("Endereco");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Comprador", b =>
                {
                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("Leilao", b =>
                {
                    b.Navigation("Lote");
                });

            modelBuilder.Entity("Lote", b =>
                {
                    b.Navigation("ObraArte");
                });

            modelBuilder.Entity("Status", b =>
                {
                    b.Navigation("Avaliador");

                    b.Navigation("Proprietario");
                });
#pragma warning restore 612, 618
        }
    }
}
