using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class CarsReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReview_Cars_CarId",
                table: "CarReview");

            migrationBuilder.DropForeignKey(
                name: "FK_CarReview_Reviews_ReviewId",
                table: "CarReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarReview",
                table: "CarReview");

            migrationBuilder.RenameTable(
                name: "CarReview",
                newName: "CarsReviews");

            migrationBuilder.RenameIndex(
                name: "IX_CarReview_CarId",
                table: "CarsReviews",
                newName: "IX_CarsReviews_CarId");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarsReviews",
                table: "CarsReviews",
                columns: new[] { "ReviewId", "CarId" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LocationId",
                table: "Reservations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ReservationId",
                table: "Locations",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarsReviews_Cars_CarId",
                table: "CarsReviews",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsReviews_Reviews_ReviewId",
                table: "CarsReviews",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Reservations_ReservationId",
                table: "Locations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_LocationId",
                table: "Reservations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsReviews_Cars_CarId",
                table: "CarsReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsReviews_Reviews_ReviewId",
                table: "CarsReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Reservations_ReservationId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_LocationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_LocationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ReservationId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarsReviews",
                table: "CarsReviews");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "CarsReviews",
                newName: "CarReview");

            migrationBuilder.RenameIndex(
                name: "IX_CarsReviews_CarId",
                table: "CarReview",
                newName: "IX_CarReview_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarReview",
                table: "CarReview",
                columns: new[] { "ReviewId", "CarId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarReview_Cars_CarId",
                table: "CarReview",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarReview_Reviews_ReviewId",
                table: "CarReview",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
