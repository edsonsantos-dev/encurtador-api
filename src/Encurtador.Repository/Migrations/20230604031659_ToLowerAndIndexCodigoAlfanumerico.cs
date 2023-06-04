using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encurtador.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ToLowerAndIndexCodigoAlfanumerico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlOriginal",
                table: "urlencurtadas",
                newName: "urloriginal");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "urlencurtadas",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "DataExpiracao",
                table: "urlencurtadas",
                newName: "dataexpiracao");

            migrationBuilder.RenameColumn(
                name: "CodigoAlfanumerico",
                table: "urlencurtadas",
                newName: "codigoalfanumerico");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "urlencurtadas",
                newName: "id");

            migrationBuilder.CreateIndex(
                name: "IX_urlencurtadas_codigoalfanumerico",
                table: "urlencurtadas",
                column: "codigoalfanumerico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_urlencurtadas_codigoalfanumerico",
                table: "urlencurtadas");

            migrationBuilder.RenameColumn(
                name: "urloriginal",
                table: "urlencurtadas",
                newName: "UrlOriginal");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "urlencurtadas",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "dataexpiracao",
                table: "urlencurtadas",
                newName: "DataExpiracao");

            migrationBuilder.RenameColumn(
                name: "codigoalfanumerico",
                table: "urlencurtadas",
                newName: "CodigoAlfanumerico");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "urlencurtadas",
                newName: "Id");
        }
    }
}
