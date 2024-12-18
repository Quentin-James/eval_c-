using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geometrie.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ajustementDeLaLongeurDeLIP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IP",
                table: "Logs",
                type: "nvarchar(39)",
                maxLength: 39,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IP",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(39)",
                oldMaxLength: 39);
        }
    }
}
