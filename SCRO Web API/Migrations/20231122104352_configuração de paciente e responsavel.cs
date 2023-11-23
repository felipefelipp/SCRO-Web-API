using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class configuraçãodepacienteeresponsavel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacienteResponsavel_Paciente_PacienteId",
                table: "PacienteResponsavel");

            migrationBuilder.DropForeignKey(
                name: "FK_PacienteResponsavel_Responsavel_ResponsavelId",
                table: "PacienteResponsavel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PacienteResponsavel",
                table: "PacienteResponsavel");

            migrationBuilder.DropIndex(
                name: "IX_PacienteResponsavel_ResponsavelId",
                table: "PacienteResponsavel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_PacienteResponsavel",
                table: "PacienteResponsavel",
                columns: new[] { "PacienteId", "ResponsavelId" });

            migrationBuilder.CreateIndex(
                name: "IX_PacienteResponsavel_ResponsavelId",
                table: "PacienteResponsavel",
                column: "ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteResponsavel_Paciente_PacienteId",
                table: "PacienteResponsavel",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteResponsavel_Responsavel_ResponsavelId",
                table: "PacienteResponsavel",
                column: "ResponsavelId",
                principalTable: "Responsavel",
                principalColumn: "ResponsavelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
