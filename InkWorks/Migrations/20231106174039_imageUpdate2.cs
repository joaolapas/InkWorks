using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkWorks.Migrations
{
    /// <inheritdoc />
    public partial class imageUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Trabalhos_TrabalhoId",
                table: "Imagens");

            migrationBuilder.AlterColumn<int>(
                name: "TrabalhoId",
                table: "Imagens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Trabalhos_TrabalhoId",
                table: "Imagens",
                column: "TrabalhoId",
                principalTable: "Trabalhos",
                principalColumn: "TrabalhoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Trabalhos_TrabalhoId",
                table: "Imagens");

            migrationBuilder.AlterColumn<int>(
                name: "TrabalhoId",
                table: "Imagens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Trabalhos_TrabalhoId",
                table: "Imagens",
                column: "TrabalhoId",
                principalTable: "Trabalhos",
                principalColumn: "TrabalhoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
