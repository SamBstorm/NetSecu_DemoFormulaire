using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSecu_DemoFormulaire.Models.Domain.Migrations
{
    public partial class AddJeux : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jeux",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Nom = table.Column<string>(type: "NVARCHAR(75)", nullable: false),
                    Editeur = table.Column<string>(type: "NVARCHAR(75)", nullable: false),
                    AnneeSortie = table.Column<int>(type: "INTEGER", nullable: false),
                    DateAjout = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jeux_Utilisateur_CreateurId",
                        column: x => x.CreateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jeux_CreateurId",
                table: "Jeux",
                column: "CreateurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jeux");
        }
    }
}
