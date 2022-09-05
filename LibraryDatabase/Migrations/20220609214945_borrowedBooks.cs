using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDatabase.Migrations
{
    public partial class borrowedBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_borrowed",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "borrowed_books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    book_id = table.Column<int>(type: "int", nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    reader_id = table.Column<int>(type: "int", nullable: true),
                    borrowed_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CAST( GETDATE() AS DateTime )"),
                    return_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_renew = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    is_returned = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrowed_books", x => x.id);
                    table.ForeignKey(
                        name: "FK_borrowed_books_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_borrowed_books_Users_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_borrowed_books_Users_reader_id",
                        column: x => x.reader_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_borrowed_books_book_id",
                table: "borrowed_books",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_borrowed_books_employee_id",
                table: "borrowed_books",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_borrowed_books_reader_id",
                table: "borrowed_books",
                column: "reader_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "borrowed_books");

            migrationBuilder.DropColumn(
                name: "is_borrowed",
                table: "Books");
        }
    }
}
