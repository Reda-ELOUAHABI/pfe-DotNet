using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pfe.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    EnseignantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.EnseignantId);
                });

            migrationBuilder.CreateTable(
                name: "Filiere",
                columns: table => new
                {
                    idFiliere = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomFiliere = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiere", x => x.idFiliere);
                });

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    stageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    encadrantExterne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    organismeAceuil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paysStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sujet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    villeStage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.stageId);
                });

            migrationBuilder.CreateTable(
                name: "EnseignantStage",
                columns: table => new
                {
                    enseignantsEnseignantId = table.Column<int>(type: "int", nullable: false),
                    stagesstageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnseignantStage", x => new { x.enseignantsEnseignantId, x.stagesstageId });
                    table.ForeignKey(
                        name: "FK_EnseignantStage_Enseignant_enseignantsEnseignantId",
                        column: x => x.enseignantsEnseignantId,
                        principalTable: "Enseignant",
                        principalColumn: "EnseignantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnseignantStage_Stage_stagesstageId",
                        column: x => x.stagesstageId,
                        principalTable: "Stage",
                        principalColumn: "stageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    matricule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    filiereidFiliere = table.Column<int>(type: "int", nullable: true),
                    promotion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Filiere_filiereidFiliere",
                        column: x => x.filiereidFiliere,
                        principalTable: "Filiere",
                        principalColumn: "idFiliere",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Stage_stageId",
                        column: x => x.stageId,
                        principalTable: "Stage",
                        principalColumn: "stageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnseignantStage_stagesstageId",
                table: "EnseignantStage",
                column: "stagesstageId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_filiereidFiliere",
                table: "Student",
                column: "filiereidFiliere");

            migrationBuilder.CreateIndex(
                name: "IX_Student_stageId",
                table: "Student",
                column: "stageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnseignantStage");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "Filiere");

            migrationBuilder.DropTable(
                name: "Stage");
        }
    }
}
