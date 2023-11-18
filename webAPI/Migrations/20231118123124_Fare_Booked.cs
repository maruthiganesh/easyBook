using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fare_Booked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booked_Seats_Fares_Fares",
                table: "Booked_Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Booked_Seats_Screens_Screen_id1",
                table: "Booked_Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Fares_Shows_Shows",
                table: "Fares");

            migrationBuilder.DropIndex(
                name: "IX_Booked_Seats_Fares",
                table: "Booked_Seats");

            migrationBuilder.DropColumn(
                name: "Fares",
                table: "Booked_Seats");

            migrationBuilder.RenameColumn(
                name: "Shows",
                table: "Fares",
                newName: "Show_id");

            migrationBuilder.RenameIndex(
                name: "IX_Fares_Shows",
                table: "Fares",
                newName: "IX_Fares_Show_id");

            migrationBuilder.RenameColumn(
                name: "Screen_id1",
                table: "Booked_Seats",
                newName: "Fare_id");

            migrationBuilder.RenameIndex(
                name: "IX_Booked_Seats_Screen_id1",
                table: "Booked_Seats",
                newName: "IX_Booked_Seats_Fare_id");

            migrationBuilder.AddColumn<int>(
                name: "FaresFare_id",
                table: "Booked_Seats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booked_Seats_FaresFare_id",
                table: "Booked_Seats",
                column: "FaresFare_id");

            migrationBuilder.CreateIndex(
                name: "IX_Booked_Seats_Screen_id",
                table: "Booked_Seats",
                column: "Screen_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booked_Seats_Fares_Fare_id",
                table: "Booked_Seats",
                column: "Fare_id",
                principalTable: "Fares",
                principalColumn: "Fare_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booked_Seats_Fares_FaresFare_id",
                table: "Booked_Seats",
                column: "FaresFare_id",
                principalTable: "Fares",
                principalColumn: "Fare_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booked_Seats_Screens_Screen_id",
                table: "Booked_Seats",
                column: "Screen_id",
                principalTable: "Screens",
                principalColumn: "Screen_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fares_Shows_Show_id",
                table: "Fares",
                column: "Show_id",
                principalTable: "Shows",
                principalColumn: "Show_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booked_Seats_Fares_Fare_id",
                table: "Booked_Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Booked_Seats_Fares_FaresFare_id",
                table: "Booked_Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Booked_Seats_Screens_Screen_id",
                table: "Booked_Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Fares_Shows_Show_id",
                table: "Fares");

            migrationBuilder.DropIndex(
                name: "IX_Booked_Seats_FaresFare_id",
                table: "Booked_Seats");

            migrationBuilder.DropIndex(
                name: "IX_Booked_Seats_Screen_id",
                table: "Booked_Seats");

            migrationBuilder.DropColumn(
                name: "FaresFare_id",
                table: "Booked_Seats");

            migrationBuilder.RenameColumn(
                name: "Show_id",
                table: "Fares",
                newName: "Shows");

            migrationBuilder.RenameIndex(
                name: "IX_Fares_Show_id",
                table: "Fares",
                newName: "IX_Fares_Shows");

            migrationBuilder.RenameColumn(
                name: "Fare_id",
                table: "Booked_Seats",
                newName: "Screen_id1");

            migrationBuilder.RenameIndex(
                name: "IX_Booked_Seats_Fare_id",
                table: "Booked_Seats",
                newName: "IX_Booked_Seats_Screen_id1");

            migrationBuilder.AddColumn<int>(
                name: "Fares",
                table: "Booked_Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booked_Seats_Fares",
                table: "Booked_Seats",
                column: "Fares");

            migrationBuilder.AddForeignKey(
                name: "FK_Booked_Seats_Fares_Fares",
                table: "Booked_Seats",
                column: "Fares",
                principalTable: "Fares",
                principalColumn: "Fare_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booked_Seats_Screens_Screen_id1",
                table: "Booked_Seats",
                column: "Screen_id1",
                principalTable: "Screens",
                principalColumn: "Screen_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fares_Shows_Shows",
                table: "Fares",
                column: "Shows",
                principalTable: "Shows",
                principalColumn: "Show_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
