using Microsoft.EntityFrameworkCore.Migrations;

namespace pfe.Migrations
{
    public partial class AddCin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cin",
                table: "Enseignant",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cin",
                table: "Enseignant");
        }
    }
}
