using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    PagesCount = table.Column<int>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { new Guid("450271d8-0091-4bf4-beb0-b899e026560e"), 67, "Andrzej" });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { new Guid("db67e008-1c68-463e-a7b2-e75ad5a82a7f"), 44, "Henryk" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "PagesCount", "Title" },
                values: new object[] { new Guid("91992789-5e7f-4c04-86b8-12df2933fdc8"), new Guid("450271d8-0091-4bf4-beb0-b899e026560e"), 320, "Wiedźmin" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "PagesCount", "Title" },
                values: new object[] { new Guid("bc6728be-a2d5-40ec-a7db-c1e94557a2f8"), new Guid("db67e008-1c68-463e-a7b2-e75ad5a82a7f"), 280, "Krzyżacy" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
