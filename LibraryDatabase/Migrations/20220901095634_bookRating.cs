using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDatabase.Migrations
{
    public partial class bookRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "book_rating",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    book_id = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_rating", x => x.id);
                    table.ForeignKey(
                        name: "FK_book_rating_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_rating_book_id",
                table: "book_rating",
                column: "book_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_rating");
        }
    }
}
