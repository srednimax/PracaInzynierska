using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDatabase.Migrations
{
    public partial class onDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_ratings_books_book_id",
                table: "book_ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_books_BookId",
                table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_genres_GenreId",
                table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_borrowed_books_books_book_id",
                table: "borrowed_books");

            migrationBuilder.DropForeignKey(
                name: "FK_borrowed_books_users_employee_id",
                table: "borrowed_books");

            migrationBuilder.AddForeignKey(
                name: "FK_book_ratings_books_book_id",
                table: "book_ratings",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_books_BookId",
                table: "BookGenre",
                column: "BookId",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_genres_GenreId",
                table: "BookGenre",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_borrowed_books_books_book_id",
                table: "borrowed_books",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_borrowed_books_users_employee_id",
                table: "borrowed_books",
                column: "employee_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_ratings_books_book_id",
                table: "book_ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_books_BookId",
                table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_genres_GenreId",
                table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_borrowed_books_books_book_id",
                table: "borrowed_books");

            migrationBuilder.DropForeignKey(
                name: "FK_borrowed_books_users_employee_id",
                table: "borrowed_books");

            migrationBuilder.AddForeignKey(
                name: "FK_book_ratings_books_book_id",
                table: "book_ratings",
                column: "book_id",
                principalTable: "books",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_books_BookId",
                table: "BookGenre",
                column: "BookId",
                principalTable: "books",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_genres_GenreId",
                table: "BookGenre",
                column: "GenreId",
                principalTable: "genres",
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
        }
    }
}
