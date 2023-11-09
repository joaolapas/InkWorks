using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkWorks.Migrations
{
    /// <inheritdoc />
    public partial class modMsg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEnvio",
                table: "Mensagens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEnvio",
                table: "Mensagens");
        }
    }
}
