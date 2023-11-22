using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class AddAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE SEQUENCE AtendimentoSequence START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<int>(
                name: "AtendimentoPacienteId",
                table: "ClassificacaoPaciente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    AtendimentoPacienteId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR AtendimentoSequence"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    SenhaClassificacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAtendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.AtendimentoPacienteId);
                    table.ForeignKey(
                        name: "FK_Atendimento_ClassificacaoPaciente_AtendimentoPacienteId",
                        column: x => x.AtendimentoPacienteId,
                        principalTable: "ClassificacaoPaciente",
                        principalColumn: "ClassificacaoPacienteId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP SEQUENCE AtendimentoSequence");

            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropColumn(
                name: "AtendimentoPacienteId",
                table: "ClassificacaoPaciente");
        }
    }
}
