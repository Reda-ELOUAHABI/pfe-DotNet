using Microsoft.EntityFrameworkCore.Migrations;

namespace pfe.Migrations
{
    public partial class snef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nom",
                table: "AspNetUsers",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUsers",
                newName: "nom");
        }
    }
}
