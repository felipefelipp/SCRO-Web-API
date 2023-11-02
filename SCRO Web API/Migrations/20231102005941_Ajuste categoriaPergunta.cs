using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRO_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class AjustecategoriaPergunta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"ALTER TABLE CategoriaPergunta
                        DROP COLUMN PerguntaId;";

            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"ALTER TABLE CategoriaPergunta
                        ADD PerguntaId INT";

            migrationBuilder.Sql(sql);
        }
    }
}
