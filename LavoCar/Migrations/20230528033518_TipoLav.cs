using Microsoft.EntityFrameworkCore.Migrations;

namespace LavoCar.Migrations
{
    public partial class TipoLav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PrecoTipoLav",
                table: "TipoLavagens",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<long>(
                name: "LavID",
                table: "TipoLavagens",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoLavagens_LavID",
                table: "TipoLavagens",
                column: "LavID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TipoLavagens_LavID",
                table: "TipoLavagens");

            migrationBuilder.DropColumn(
                name: "LavID",
                table: "TipoLavagens");

            migrationBuilder.AlterColumn<double>(
                name: "PrecoTipoLav",
                table: "TipoLavagens",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
