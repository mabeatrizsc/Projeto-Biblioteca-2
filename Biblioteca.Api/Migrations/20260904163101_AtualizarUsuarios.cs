using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Api.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Usuarios",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ISBN",
                table: "Usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "AnoPublicacao",
                table: "Usuarios",
                newName: "Tefone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tefone",
                table: "Usuarios",
                newName: "AnoPublicacao");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Usuarios",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "ISBN");

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "Usuarios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
