using Microsoft.EntityFrameworkCore.Migrations;

namespace LavoCar.Migrations
{
    public partial class login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoLavagens",
                columns: table => new
                {
                    TipoLavID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescTipoLav = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoTipoLav = table.Column<int>(type: "int", nullable: false),
                    LavagemLavID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLavagens", x => x.TipoLavID);
                    table.ForeignKey(
                        name: "FK_TipoLavagens_Lavagens_LavagemLavID",
                        column: x => x.LavagemLavID,
                        principalTable: "Lavagens",
                        principalColumn: "LavID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoLavagens_LavagemLavID",
                table: "TipoLavagens",
                column: "LavagemLavID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoLavagens");
        }
    }
}
