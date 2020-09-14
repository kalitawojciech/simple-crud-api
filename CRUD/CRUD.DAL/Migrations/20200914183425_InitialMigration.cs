using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    PagesCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "PagesCount", "Title" },
                values: new object[] { new Guid("012b3976-af66-4330-83da-37e9061726d5"), 320, "Wiedźmin" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "PagesCount", "Title" },
                values: new object[] { new Guid("c71a486f-e8ba-487b-8414-5f9c92cd9f21"), 280, "Krzyżacy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
