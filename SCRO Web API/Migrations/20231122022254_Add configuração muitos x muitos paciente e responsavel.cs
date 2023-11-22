using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class Addconfiguraçãomuitosxmuitospacienteeresponsavel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsavel_Paciente_PacienteId",
                table: "Responsavel");

            migrationBuilder.DropIndex(
                name: "IX_Responsavel_PacienteId",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Responsavel");

            migrationBuilder.CreateTable(
                name: "PacienteResponsavel",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ResponsavelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteResponsavel", x => new { x.PacienteId, x.ResponsavelId });
                    table.ForeignKey(
                        name: "FK_PacienteResponsavel_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacienteResponsavel_Responsavel_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Responsavel",
                        principalColumn: "ResponsavelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacienteResponsavel_ResponsavelId",
                table: "PacienteResponsavel",
                column: "ResponsavelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacienteResponsavel");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Responsavel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_PacienteId",
                table: "Responsavel",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsavel_Paciente_PacienteId",
                table: "Responsavel",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "PacienteId");
        }
    }
}
