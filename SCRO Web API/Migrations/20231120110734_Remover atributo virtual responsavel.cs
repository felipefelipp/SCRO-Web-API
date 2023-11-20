using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class Removeratributovirtualresponsavel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Responsavel_PacienteId",
                table: "Responsavel");

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_PacienteId",
                table: "Responsavel",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Responsavel_PacienteId",
                table: "Responsavel");

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_PacienteId",
                table: "Responsavel",
                column: "PacienteId",
                unique: true,
                filter: "[PacienteId] IS NOT NULL");
        }
    }
}
