using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassificacaoPaciente",
                columns: table => new
                {
                    ClassificacaoPacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ValorResultadoClassificacao = table.Column<int>(type: "int", nullable: false),
                    ValorResultadoCor = table.Column<int>(type: "int", nullable: false),
                    ResultadoClassificacaoCor = table.Column<int>(type: "int", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificacaoPaciente", x => x.ClassificacaoPacienteId);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telefone = table.Column<string>(type: "varchar(11)", nullable: false),
                    rua = table.Column<string>(type: "varchar(100)", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    municipio = table.Column<string>(type: "varchar(100)", nullable: false),
                    uf = table.Column<string>(type: "varchar(2)", nullable: false),
                    cep = table.Column<int>(type: "int", nullable: false),
                    sexo = table.Column<string>(type: "char(1)", nullable: false),
                    profissao = table.Column<string>(type: "varchar(50)", nullable: false),
                    SenhaClassificacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    rg = table.Column<string>(type: "varchar(8)", nullable: false),
                    celular = table.Column<string>(type: "varchar(11)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                });

            migrationBuilder.CreateTable(
                name: "Pergunta",
                columns: table => new
                {
                    PerguntaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoPergunta = table.Column<string>(type: "varchar(250)", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pergunta", x => x.PerguntaId);
                });

            migrationBuilder.CreateTable(
                name: "PerguntaSelecionadaPaciente",
                columns: table => new
                {
                    PerguntaSelecionadaPacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerguntaId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ClassificacaoPacienteId = table.Column<int>(type: "int", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerguntaSelecionadaPaciente", x => x.PerguntaSelecionadaPacienteId);
                });

            migrationBuilder.CreateTable(
                name: "Resposta",
                columns: table => new
                {
                    RespostaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespostaTexto = table.Column<bool>(type: "bit", nullable: false),
                    RespostaTextoArea = table.Column<bool>(type: "bit", nullable: false),
                    RespostaCheckBox = table.Column<string>(type: "varchar(100)", nullable: false),
                    RespostaComboBox = table.Column<string>(type: "varchar(100)", nullable: false),
                    RespostaRadioButtom = table.Column<string>(type: "varchar(100)", nullable: false),
                    RespostaData = table.Column<DateTime>(type: "Datetime", nullable: true),
                    ValorTipoResposta = table.Column<int>(type: "int", nullable: false),
                    ValorResposta = table.Column<int>(type: "int", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.RespostaId);
                });

            migrationBuilder.CreateTable(
                name: "RespostaSelecionadaPaciente",
                columns: table => new
                {
                    RespostaSelecionadaPacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespostaId = table.Column<int>(type: "int", nullable: false),
                    ValorRespostaTexto = table.Column<string>(type: "varchar(100)", nullable: true),
                    ValorRespostaTextoArea = table.Column<string>(type: "varchar(max)", nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ClassificacaoPacienteId = table.Column<int>(type: "int", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostaSelecionadaPaciente", x => x.RespostaSelecionadaPacienteId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coren = table.Column<string>(type: "varchar(8)", nullable: false),
                    crm = table.Column<string>(type: "varchar(8)", nullable: false),
                    senha = table.Column<string>(type: "varchar(8)", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    rg = table.Column<string>(type: "varchar(8)", nullable: false),
                    celular = table.Column<string>(type: "varchar(11)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Responsavel",
                columns: table => new
                {
                    ResponsavelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    rg = table.Column<string>(type: "varchar(8)", nullable: false),
                    celular = table.Column<string>(type: "varchar(11)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsavel", x => x.ResponsavelId);
                    table.ForeignKey(
                        name: "FK_Responsavel_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "PacienteId");
                });

            migrationBuilder.CreateTable(
                name: "CategoriaPergunta",
                columns: table => new
                {
                    CategoriaPerguntaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerguntaId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaPergunta", x => x.CategoriaPerguntaId);
                    table.ForeignKey(
                        name: "FK_CategoriaPergunta_Pergunta_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Pergunta",
                        principalColumn: "PerguntaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaPergunta_PerguntaId",
                table: "CategoriaPergunta",
                column: "PerguntaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_celular",
                table: "Paciente",
                column: "celular",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_cpf",
                table: "Paciente",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_celular",
                table: "Responsavel",
                column: "celular",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_cpf",
                table: "Responsavel",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_PacienteId",
                table: "Responsavel",
                column: "PacienteId",
                unique: true,
                filter: "[PacienteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_celular",
                table: "Usuario",
                column: "celular",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_cpf",
                table: "Usuario",
                column: "cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaPergunta");

            migrationBuilder.DropTable(
                name: "ClassificacaoPaciente");

            migrationBuilder.DropTable(
                name: "PerguntaSelecionadaPaciente");

            migrationBuilder.DropTable(
                name: "Responsavel");

            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "RespostaSelecionadaPaciente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Pergunta");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
