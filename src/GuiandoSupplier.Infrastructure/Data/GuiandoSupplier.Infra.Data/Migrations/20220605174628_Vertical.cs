using Microsoft.EntityFrameworkCore.Migrations;

namespace GuiandoSupplier.Infra.Data.Migrations
{
    public partial class Vertical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Supplier");

            migrationBuilder.AddColumn<int>(
                name: "Verticals",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verticals",
                table: "Supplier");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Supplier",
                type: "varchar(18)",
                nullable: false,
                defaultValue: "");
        }
    }
}
