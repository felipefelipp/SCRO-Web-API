using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class Resultado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE SEQUENCE ResultadoSequence START WITH 1 INCREMENT BY 1");

            migrationBuilder.CreateTable(
                name: "Resultado",
                columns: table => new
                {
                    ResultadoId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR ResultadoSequence"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ClassificacaoPacienteId = table.Column<int>(type: "int", nullable: false),
                    ValorResultadoClassificacao = table.Column<int>(type: "int", nullable: false),
                    ResultadoCor = table.Column<int>(type: "int", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultado", x => x.ResultadoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP SEQUENCE ResultadoSequence ");

            migrationBuilder.DropTable(
                name: "Resultado");
        }
    }
}
