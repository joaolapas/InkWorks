using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkWorks.Migrations
{
    /// <inheritdoc />
    public partial class imageUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoLonga",
                table: "Imagens");

            migrationBuilder.DropColumn(
                name: "Estilo",
                table: "Imagens");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Imagens");

            migrationBuilder.AddColumn<bool>(
                name: "Portfolio",
                table: "Imagens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Portfolio",
                table: "Imagens");

            migrationBuilder.AddColumn<string>(
                name: "DescricaoLonga",
                table: "Imagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estilo",
                table: "Imagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Imagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
