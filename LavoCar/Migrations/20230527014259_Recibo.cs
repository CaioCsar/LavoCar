using Microsoft.EntityFrameworkCore.Migrations;

namespace LavoCar.Migrations
{
    public partial class Recibo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    ReciboID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<long>(type: "bigint", nullable: true),
                    CarroID = table.Column<long>(type: "bigint", nullable: true),
                    LavagemID = table.Column<long>(type: "bigint", nullable: true),
                    TipoLavagemID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.ReciboID);
                    table.ForeignKey(
                        name: "FK_Recibos_Carros_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carros",
                        principalColumn: "CarroID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recibos_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recibos_Lavagens_LavagemID",
                        column: x => x.LavagemID,
                        principalTable: "Lavagens",
                        principalColumn: "LavID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recibos_TipoLavagens_TipoLavagemID",
                        column: x => x.TipoLavagemID,
                        principalTable: "TipoLavagens",
                        principalColumn: "TipoLavID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_CarroID",
                table: "Recibos",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_ClienteID",
                table: "Recibos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_LavagemID",
                table: "Recibos",
                column: "LavagemID");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_TipoLavagemID",
                table: "Recibos",
                column: "TipoLavagemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recibos");
        }
    }
}
