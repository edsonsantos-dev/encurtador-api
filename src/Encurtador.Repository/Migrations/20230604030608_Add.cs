using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encurtador.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "urlencurtadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UrlOriginal = table.Column<string>(type: "text", nullable: false),
                    CodigoAlfanumerico = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urlencurtadas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "urlencurtadas");
        }
    }
}
