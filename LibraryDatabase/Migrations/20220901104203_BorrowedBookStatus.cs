using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDatabase.Migrations
{
    public partial class BorrowedBookStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "borrowed_books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "borrowed_books");
        }
    }
}
