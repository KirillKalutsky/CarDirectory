using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDirectory.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automobile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RegisterSign = table.Column<string>(type: "text", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    YearOfIssue = table.Column<int>(type: "integer", nullable: false),
                    Create = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobile_RegisterSign",
                table: "Automobile",
                column: "RegisterSign",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobile");
        }
    }
}
