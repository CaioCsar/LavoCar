using Microsoft.EntityFrameworkCore.Migrations;

namespace LavoCar.Migrations
{
    public partial class RelacionamentoCarroeLavaegem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CarroID",
                table: "Lavagens",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lavagens_CarroID",
                table: "Lavagens",
                column: "CarroID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lavagens_Carros_CarroID",
                table: "Lavagens",
                column: "CarroID",
                principalTable: "Carros",
                principalColumn: "CarroID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lavagens_Carros_CarroID",
                table: "Lavagens");

            migrationBuilder.DropIndex(
                name: "IX_Lavagens_CarroID",
                table: "Lavagens");

            migrationBuilder.DropColumn(
                name: "CarroID",
                table: "Lavagens");
        }
    }
}
