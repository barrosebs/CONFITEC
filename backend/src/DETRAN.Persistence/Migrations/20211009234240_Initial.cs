using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DETRAN.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condutores",
                columns: table => new
                {
                    CondutorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    NumeroCnh = table.Column<string>(nullable: true),
                    DataNacimento = table.Column<DateTime>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    VeiculoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condutores", x => x.CondutorId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioNome = table.Column<string>(nullable: true),
                    UsuarioEmail = table.Column<string>(nullable: true),
                    UsuarioSenha = table.Column<string>(nullable: true),
                    UsuarioDataCadastro = table.Column<DateTime>(nullable: false),
                    UsuarioAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Placa = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(nullable: true),
                    AnoDeFabricacao = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    CondutorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.VeiculoId);
                });

            migrationBuilder.CreateTable(
                name: "CondutoresVeiculos",
                columns: table => new
                {
                    CondutorId = table.Column<int>(nullable: false),
                    VeiculoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondutoresVeiculos", x => new { x.CondutorId, x.VeiculoId });
                    table.ForeignKey(
                        name: "FK_CondutoresVeiculos_Condutores_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "Condutores",
                        principalColumn: "CondutorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondutoresVeiculos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "VeiculoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CondutoresVeiculos_VeiculoId",
                table: "CondutoresVeiculos",
                column: "VeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CondutoresVeiculos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Condutores");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
