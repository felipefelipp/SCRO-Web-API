using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class uniquePacienteIdResppnsavelId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE PacienteResponsavel ADD CONSTRAINT unique_combination_paciente_responsavel UNIQUE (PacienteId, ResponsavelId)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE PacienteResponsavel DROP CONSTRAINT unique_combination_paciente_responsavel");
        }
    }
}
