using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class AddperguntaidemRespostaSelecionadaPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerguntaId",
                table: "RespostaSelecionadaPaciente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerguntaId",
                table: "RespostaSelecionadaPaciente");
        }
    }
}
