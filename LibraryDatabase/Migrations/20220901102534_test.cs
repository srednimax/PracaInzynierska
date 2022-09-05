using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDatabase.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_rating_Books_book_id",
                table: "book_rating");

            migrationBuilder.DropForeignKey(
                name: "FK_borrowed_books_Books_book_id",
                table: "borrowed_books");

            migrationBuilder.DropForeignKey(
                name: "FK_borrowed_books_Users_employee_id",
                table: "borrowed_books");

            migrationBuilder.DropForeignKey(
                name: "FK_borrowed_books_Users_reader_id",
                table: "borrowed_books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book_rating",
                table: "book_rating");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "books");

            migrationBuilder.RenameTable(
                name: "book_rating",
                newName: "book_ratings");

            migrationBuilder.RenameIndex(
                name: "IX_Users_email",
                table: "users",
                newName: "IX_users_email");

            migrationBuilder.RenameIndex(
                name: "IX_book_rating_book_id",
                table: "book_ratings",
                newName: "IX_book_ratings_book_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book_ratings",
                table: "book_ratings",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_book_ratings_books_book_id",
                table: "book_ratings",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_borrowed_books_books_book_id",
                table: "borrowed_books",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_borrowed_books_users_employee_id",
                table: "borrowed_books",
                column: "employee_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_borrowed_books_users_reader_id",
                table: "borrowed_books",
                column: "reader_id",
                principalTable: "users",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_ratings_books_book_id",
                table: "book_ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_borrowed_books_books_book_id",
                table: "borrowed_books");

            migrationBuilder.DropForeignKey(
                name: "FK_borrowed_books_users_employee_id",
                table: "borrowed_books");

            migrationBuilder.DropForeignKey(
                name: "FK_borrowed_books_users_reader_id",
                table: "borrowed_books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book_ratings",
                table: "book_ratings");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "books",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "book_ratings",
                newName: "book_rating");

            migrationBuilder.RenameIndex(
                name: "IX_users_email",
                table: "Users",
                newName: "IX_Users_email");

            migrationBuilder.RenameIndex(
                name: "IX_book_ratings_book_id",
                table: "book_rating",
                newName: "IX_book_rating_book_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book_rating",
                table: "book_rating",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_book_rating_Books_book_id",
                table: "book_rating",
                column: "book_id",
                principalTable: "Books",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_borrowed_books_Books_book_id",
                table: "borrowed_books",
                column: "book_id",
                principalTable: "Books",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_borrowed_books_Users_employee_id",
                table: "borrowed_books",
                column: "employee_id",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_borrowed_books_Users_reader_id",
                table: "borrowed_books",
                column: "reader_id",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
