using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.DAL.Migrations
{
    public partial class AddedTableCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("91992789-5e7f-4c04-86b8-12df2933fdc8"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("bc6728be-a2d5-40ec-a7db-c1e94557a2f8"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Books",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("db67e008-1c68-463e-a7b2-e75ad5a82a7a"), "Książki o tematyce fantasy", true, "Fantasy" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "PagesCount", "Title" },
                values: new object[] { new Guid("b11e85fc-2d5a-48fa-ba59-3d5c396bc68e"), new Guid("450271d8-0091-4bf4-beb0-b899e026560e"), new Guid("db67e008-1c68-463e-a7b2-e75ad5a82a7a"), 320, "Wiedźmin" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "PagesCount", "Title" },
                values: new object[] { new Guid("981a1ff3-5390-497f-8db5-f6a30c441b89"), new Guid("db67e008-1c68-463e-a7b2-e75ad5a82a7f"), new Guid("db67e008-1c68-463e-a7b2-e75ad5a82a7a"), 280, "Krzyżacy" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("981a1ff3-5390-497f-8db5-f6a30c441b89"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b11e85fc-2d5a-48fa-ba59-3d5c396bc68e"));

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "PagesCount", "Title" },
                values: new object[] { new Guid("91992789-5e7f-4c04-86b8-12df2933fdc8"), new Guid("450271d8-0091-4bf4-beb0-b899e026560e"), 320, "Wiedźmin" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "PagesCount", "Title" },
                values: new object[] { new Guid("bc6728be-a2d5-40ec-a7db-c1e94557a2f8"), new Guid("db67e008-1c68-463e-a7b2-e75ad5a82a7f"), 280, "Krzyżacy" });
        }
    }
}
