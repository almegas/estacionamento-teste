using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TesteFe.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(nullable: true),
                    CEP = table.Column<int>(nullable: false),
                    Cidade = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Lougradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoID);
                });

            migrationBuilder.CreateTable(
                name: "Estacionamento",
                columns: table => new
                {
                    EstacionamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamento", x => x.EstacionamentoID);
                });

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    CartaoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EnderecoID = table.Column<int>(nullable: true),
                    EstacionamentoID = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<int>(nullable: false),
                    CPF = table.Column<int>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    RG = table.Column<int>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    CNPJ = table.Column<int>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.CartaoID);
                    table.ForeignKey(
                        name: "FK_Cartao_Endereco_EnderecoID",
                        column: x => x.EnderecoID,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cartao_Estacionamento_EstacionamentoID",
                        column: x => x.EstacionamentoID,
                        principalTable: "Estacionamento",
                        principalColumn: "EstacionamentoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_EnderecoID",
                table: "Cartao",
                column: "EnderecoID");

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_EstacionamentoID",
                table: "Cartao",
                column: "EstacionamentoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Estacionamento");
        }
    }
}
