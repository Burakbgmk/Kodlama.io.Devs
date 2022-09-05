using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgrammingParadigm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentVersion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "CurrentVersion", "DebutTime", "Description", "Name", "ProgrammingParadigm" },
                values: new object[] { 1, "9.0", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A very powerful language for backend developers", "C#", "Object Oriented" });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "CurrentVersion", "DebutTime", "Description", "Name", "ProgrammingParadigm" },
                values: new object[] { 2, "3.9.4", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super user friendly and general purpose", "Pyhton", "Object Oriented" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");
        }
    }
}
