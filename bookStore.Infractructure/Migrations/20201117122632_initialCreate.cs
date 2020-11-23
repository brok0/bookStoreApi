using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bookStore.Infractructure.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Printings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    Edition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Illustrations = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PrintingId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Printings_PrintingId",
                        column: x => x.PrintingId,
                        principalTable: "Printings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PrintingId",
                table: "Books",
                column: "PrintingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Printings");
        }
    }
}
