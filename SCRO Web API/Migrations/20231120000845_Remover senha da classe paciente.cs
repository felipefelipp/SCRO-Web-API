using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class Removersenhadaclassepaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenhaClassificacao",
                table: "Paciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenhaClassificacao",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
