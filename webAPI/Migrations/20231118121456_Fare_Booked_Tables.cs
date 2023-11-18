using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fare_Booked_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booked_Seats_Fares_Fare_id1",
                table: "Booked_Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Fares_Shows_Show_id1",
                table: "Fares");

            migrationBuilder.DropColumn(
                name: "Show_id",
                table: "Fares");

            migrationBuilder.DropColumn(
                name: "Fare_id",
                table: "Booked_Seats");

            migrationBuilder.RenameColumn(
                name: "Show_id1",
                table: "Fares",
                newName: "Shows");

            migrationBuilder.RenameIndex(
                name: "IX_Fares_Show_id1",
                table: "Fares",
                newName: "IX_Fares_Shows");

            migrationBuilder.RenameColumn(
                name: "Fare_id1",
                table: "Booked_Seats",
                newName: "Fares");

            migrationBuilder.RenameIndex(
                name: "IX_Booked_Seats_Fare_id1",
                table: "Booked_Seats",
                newName: "IX_Booked_Seats_Fares");

            migrationBuilder.AddForeignKey(
                name: "FK_Booked_Seats_Fares_Fares",
                table: "Booked_Seats",
                column: "Fares",
                principalTable: "Fares",
                principalColumn: "Fare_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fares_Shows_Shows",
                table: "Fares",
                column: "Shows",
                principalTable: "Shows",
                principalColumn: "Show_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booked_Seats_Fares_Fares",
                table: "Booked_Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Fares_Shows_Shows",
                table: "Fares");

            migrationBuilder.RenameColumn(
                name: "Shows",
                table: "Fares",
                newName: "Show_id1");

            migrationBuilder.RenameIndex(
                name: "IX_Fares_Shows",
                table: "Fares",
                newName: "IX_Fares_Show_id1");

            migrationBuilder.RenameColumn(
                name: "Fares",
                table: "Booked_Seats",
                newName: "Fare_id1");

            migrationBuilder.RenameIndex(
                name: "IX_Booked_Seats_Fares",
                table: "Booked_Seats",
                newName: "IX_Booked_Seats_Fare_id1");

            migrationBuilder.AddColumn<int>(
                name: "Show_id",
                table: "Fares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fare_id",
                table: "Booked_Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Booked_Seats_Fares_Fare_id1",
                table: "Booked_Seats",
                column: "Fare_id1",
                principalTable: "Fares",
                principalColumn: "Fare_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fares_Shows_Show_id1",
                table: "Fares",
                column: "Show_id1",
                principalTable: "Shows",
                principalColumn: "Show_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
