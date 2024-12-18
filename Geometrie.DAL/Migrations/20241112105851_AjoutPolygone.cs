using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geometrie.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AjoutPolygone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolygoneId",
                table: "Points",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Polygone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDeCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polygone", x => x.Id);
                });
                
            migrationBuilder.CreateIndex(
                name: "IX_Points_PolygoneId",
                table: "Points",
                column: "PolygoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Polygone_PolygoneId",
                table: "Points",
                column: "PolygoneId",
                principalTable: "Polygone",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Polygone_PolygoneId",
                table: "Points");

            migrationBuilder.DropTable(
                name: "Polygone");

            migrationBuilder.DropIndex(
                name: "IX_Points_PolygoneId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "PolygoneId",
                table: "Points");
        }
    }
}
