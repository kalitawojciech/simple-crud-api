using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.DAL.Migrations
{
    public partial class Author : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("012b3976-af66-4330-83da-37e9061726d5"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c71a486f-e8ba-487b-8414-5f9c92cd9f21"));

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

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("a49272f0-b645-4e5c-80a7-343de5babcfd"), 67, "Andrzej" },
                    { new Guid("08edc18a-4151-425f-af2c-fcbda9463f0d"), 44, "Mareczek" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "PagesCount", "Title" },
                values: new object[,]
                {
                    { new Guid("7d5a68c2-5312-4ced-a657-46c43ae8c5a9"), 320, "Wiedźmin" },
                    { new Guid("b266db67-8a1f-4276-86c9-e78254885795"), 280, "Krzyżacy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7d5a68c2-5312-4ced-a657-46c43ae8c5a9"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b266db67-8a1f-4276-86c9-e78254885795"));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "PagesCount", "Title" },
                values: new object[] { new Guid("012b3976-af66-4330-83da-37e9061726d5"), 320, "Wiedźmin" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "PagesCount", "Title" },
                values: new object[] { new Guid("c71a486f-e8ba-487b-8414-5f9c92cd9f21"), 280, "Krzyżacy" });
        }
    }
}
