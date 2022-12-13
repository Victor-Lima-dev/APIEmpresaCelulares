using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEmpresaCelulares.Migrations
{
    /// <inheritdoc />
    public partial class ClienteModificado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefones",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefones",
                table: "Clientes");
        }
    }
}
