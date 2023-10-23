using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class sequence_paciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var SequencePaciente = @"CREATE SEQUENCE PacienteSequence START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1";
            migrationBuilder.Sql(SequencePaciente);

            var SequenceResponsavel = @"CREATE SEQUENCE ResponsavelSequence START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1";
            migrationBuilder.Sql(SequenceResponsavel);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            var sequencePaciente = "DROP SEQUENCE PacienteSequence";
            migrationBuilder.Sql(sequencePaciente);

            var sequenceResponsavel = "DROP SEQUENCE ResponsavelSequence";
            migrationBuilder.Sql(sequenceResponsavel);
        }
    }
}
