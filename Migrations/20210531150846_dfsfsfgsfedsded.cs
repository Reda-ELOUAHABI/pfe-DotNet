using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pfe.Migrations
{
    public partial class dfsfsfgsfedsded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "AspNetUsers",
                newName: "nom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nom",
                table: "AspNetUsers",
                newName: "number");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
