using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LavoCar.Migrations
{
    public partial class atualiçãodoIDdoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lavagens",
                columns: table => new
                {
                    LavID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLav = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorLav = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lavagens", x => x.LavID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lavagens");
        }
    }
}
