using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class TornaracolunaCategoriaPerguntaIdanulável : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Pergunta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Pergunta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
