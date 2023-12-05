using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarCategories_CategoryCarCategoryId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Reviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryCarCategoryId",
                table: "Cars",
                newName: "CarCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CategoryCarCategoryId",
                table: "Cars",
                newName: "IX_Cars_CarCategoryId");

            migrationBuilder.RenameColumn(
                name: "CarCategoryId",
                table: "CarCategories",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarCategories_CarCategoryId",
                table: "Cars",
                column: "CarCategoryId",
                principalTable: "CarCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarCategories_CarCategoryId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reviews",
                newName: "ReviewId");

            migrationBuilder.RenameColumn(
                name: "CarCategoryId",
                table: "Cars",
                newName: "CategoryCarCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CarCategoryId",
                table: "Cars",
                newName: "IX_Cars_CategoryCarCategoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarCategories",
                newName: "CarCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarCategories_CategoryCarCategoryId",
                table: "Cars",
                column: "CategoryCarCategoryId",
                principalTable: "CarCategories",
                principalColumn: "CarCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
