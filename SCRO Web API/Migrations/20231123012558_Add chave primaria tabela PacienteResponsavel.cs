using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class AddchaveprimariatabelaPacienteResponsavel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteResponsavelId",
                table: "PacienteResponsavel",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacienteResponsavel",
                table: "PacienteResponsavel",
                column: "PacienteResponsavelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PacienteResponsavel",
                table: "PacienteResponsavel");

            migrationBuilder.DropColumn(
                name: "PacienteResponsavelId",
                table: "PacienteResponsavel");
        }
    }
}
