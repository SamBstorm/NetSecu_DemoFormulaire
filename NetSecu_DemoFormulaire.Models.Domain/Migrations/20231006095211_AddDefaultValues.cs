using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSecu_DemoFormulaire.Models.Domain.Migrations
{
    public partial class AddDefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Utilisateur",
                columns: new[] { "Id", "Email", "Nom", "Passwd", "Prenom" },
                values: new object[] { new Guid("9b7d5077-7ffc-46ea-9165-769fccda98f6"), "admin@tftic.be", "Admin", new byte[] { 151, 182, 117, 90, 55, 44, 163, 172, 117, 79, 4, 131, 65, 174, 132, 14, 218, 225, 31, 177, 170, 205, 65, 145, 193, 45, 196, 240, 240, 224, 71, 113, 163, 173, 49, 14, 250, 197, 33, 112, 38, 87, 146, 30, 225, 254, 188, 249, 178, 194, 130, 181, 205, 144, 131, 48, 131, 74, 171, 253, 85, 168, 89, 55 }, "Admin" });

            migrationBuilder.InsertData(
                table: "Jeux",
                columns: new[] { "Id", "AnneeSortie", "CreateurId", "DateAjout", "Editeur", "Nom" },
                values: new object[] { new Guid("cb751f6c-9d7c-45d7-9716-82824ef5d5cc"), 1985, new Guid("9b7d5077-7ffc-46ea-9165-769fccda98f6"), new DateTime(2023, 10, 6, 11, 52, 11, 363, DateTimeKind.Local).AddTicks(2203), "Nintendo", "Super Mario Bros." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jeux",
                keyColumn: "Id",
                keyValue: new Guid("cb751f6c-9d7c-45d7-9716-82824ef5d5cc"));

            migrationBuilder.DeleteData(
                table: "Utilisateur",
                keyColumn: "Id",
                keyValue: new Guid("9b7d5077-7ffc-46ea-9165-769fccda98f6"));
        }
    }
}
