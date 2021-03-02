using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFullCRUD.Migrations
{
    public partial class InitialCreateforSqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProduceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProduceID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProduceID", "Description", "Price" },
                values: new object[] { 1, "Oranges", 4 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProduceID", "Description", "Price" },
                values: new object[] { 2, "Apples", 3 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProduceID", "Description", "Price" },
                values: new object[] { 3, "Pears", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
