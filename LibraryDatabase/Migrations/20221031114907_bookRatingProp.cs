using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDatabase.Migrations
{
    public partial class bookRatingProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "rating",
                table: "books",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rating",
                table: "books");
        }
    }
}
