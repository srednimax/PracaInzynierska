using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDatabase.Migrations
{
    public partial class bookRatingUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "book_ratings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_ratings_user_id",
                table: "book_ratings",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_book_ratings_users_user_id",
                table: "book_ratings",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_ratings_users_user_id",
                table: "book_ratings");

            migrationBuilder.DropIndex(
                name: "IX_book_ratings_user_id",
                table: "book_ratings");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "book_ratings");
        }
    }
}
