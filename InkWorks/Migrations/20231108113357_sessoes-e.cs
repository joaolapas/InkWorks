using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkWorks.Migrations
{
    /// <inheritdoc />
    public partial class sessoese : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Clientes_ClienteId",
                table: "Sessoes");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Sessoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Clientes_ClienteId",
                table: "Sessoes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Clientes_ClienteId",
                table: "Sessoes");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Clientes_ClienteId",
                table: "Sessoes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
