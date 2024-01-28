using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagementClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class IndexedTheTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_Id_IsDeleted",
                table: "User",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_Id_IsDeleted",
                table: "Publisher",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Loan_Id_IsDeleted",
                table: "Loan",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Id_IsDeleted",
                table: "Genre",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Id_IsDeleted",
                table: "Book",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Author_Id_IsDeleted",
                table: "Author",
                columns: new[] { "Id", "IsDeleted" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Id_IsDeleted",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Publisher_Id_IsDeleted",
                table: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Loan_Id_IsDeleted",
                table: "Loan");

            migrationBuilder.DropIndex(
                name: "IX_Genre_Id_IsDeleted",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Book_Id_IsDeleted",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Author_Id_IsDeleted",
                table: "Author");
        }
    }
}
