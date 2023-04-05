using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleStudentsDb.Migrations
{
    public partial class _01init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "P4" });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "P3" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "ClassroomId", "Firstname", "Lastname" },
                values: new object[] { 1, new DateTime(2004, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cyril", "Cvrček" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "ClassroomId", "Firstname", "Lastname" },
                values: new object[] { 2, new DateTime(2005, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Jana", "Jánská" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "ClassroomId", "Firstname", "Lastname" },
                values: new object[] { 3, new DateTime(2003, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Adam", "Alois" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassroomId",
                table: "Students",
                column: "ClassroomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classrooms");
        }
    }
}
