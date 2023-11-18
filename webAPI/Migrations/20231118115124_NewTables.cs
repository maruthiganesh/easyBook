using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Movies",
                table: "Theaters");

            migrationBuilder.DropColumn(
                name: "Screen_ids",
                table: "Theaters");

            migrationBuilder.RenameColumn(
                name: "user_phoneNumber",
                table: "Users",
                newName: "User_phoneNumber");

            migrationBuilder.RenameColumn(
                name: "user_password",
                table: "Users",
                newName: "User_password");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "Users",
                newName: "User_name");

            migrationBuilder.RenameColumn(
                name: "user_mailId",
                table: "Users",
                newName: "User_mailId");

            migrationBuilder.RenameColumn(
                name: "user_location",
                table: "Users",
                newName: "User_location");

            migrationBuilder.RenameColumn(
                name: "user_language",
                table: "Users",
                newName: "User_language");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Users",
                newName: "User_id");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Movie_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Run_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Release_date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Movie_id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Reservation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    SS_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Reservation_id);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    Screen_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Screen_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Theater_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screens", x => x.Screen_id);
                    table.ForeignKey(
                        name: "FK_Screens_Theaters_Theater_id",
                        column: x => x.Theater_id,
                        principalTable: "Theaters",
                        principalColumn: "Theater_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Show_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Show_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Movie_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Show_id);
                    table.ForeignKey(
                        name: "FK_Shows_Movies_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "Movies",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fares",
                columns: table => new
                {
                    Fare_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Show_id = table.Column<int>(type: "int", nullable: false),
                    Show_id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fares", x => x.Fare_id);
                    table.ForeignKey(
                        name: "FK_Fares_Shows_Show_id1",
                        column: x => x.Show_id1,
                        principalTable: "Shows",
                        principalColumn: "Show_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screen_Show_Mappers",
                columns: table => new
                {
                    SS_id = table.Column<int>(type: "int", nullable: false),
                    Screen_id = table.Column<int>(type: "int", nullable: false),
                    Show_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screen_Show_Mappers", x => x.SS_id);
                    table.ForeignKey(
                        name: "FK_Screen_Show_Mappers_Reservations_SS_id",
                        column: x => x.SS_id,
                        principalTable: "Reservations",
                        principalColumn: "Reservation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Screen_Show_Mappers_Screens_Screen_id",
                        column: x => x.Screen_id,
                        principalTable: "Screens",
                        principalColumn: "Screen_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Screen_Show_Mappers_Shows_Show_id",
                        column: x => x.Show_id,
                        principalTable: "Shows",
                        principalColumn: "Show_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booked_Seats",
                columns: table => new
                {
                    Seat_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seat_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Screen_id = table.Column<int>(type: "int", nullable: false),
                    Screen_id1 = table.Column<int>(type: "int", nullable: false),
                    Fare_id = table.Column<int>(type: "int", nullable: false),
                    Fare_id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booked_Seats", x => x.Seat_id);
                    table.ForeignKey(
                        name: "FK_Booked_Seats_Fares_Fare_id1",
                        column: x => x.Fare_id1,
                        principalTable: "Fares",
                        principalColumn: "Fare_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booked_Seats_Screens_Screen_id1",
                        column: x => x.Screen_id1,
                        principalTable: "Screens",
                        principalColumn: "Screen_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation_Bookedseats_Mappers",
                columns: table => new
                {
                    RB_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reservation_id = table.Column<int>(type: "int", nullable: false),
                    Seat_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation_Bookedseats_Mappers", x => x.RB_id);
                    table.ForeignKey(
                        name: "FK_Reservation_Bookedseats_Mappers_Booked_Seats_Seat_id",
                        column: x => x.Seat_id,
                        principalTable: "Booked_Seats",
                        principalColumn: "Seat_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Bookedseats_Mappers_Reservations_Reservation_id",
                        column: x => x.Reservation_id,
                        principalTable: "Reservations",
                        principalColumn: "Reservation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booked_Seats_Fare_id1",
                table: "Booked_Seats",
                column: "Fare_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Booked_Seats_Screen_id1",
                table: "Booked_Seats",
                column: "Screen_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Fares_Show_id1",
                table: "Fares",
                column: "Show_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Bookedseats_Mappers_Reservation_id",
                table: "Reservation_Bookedseats_Mappers",
                column: "Reservation_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Bookedseats_Mappers_Seat_id",
                table: "Reservation_Bookedseats_Mappers",
                column: "Seat_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_User_id",
                table: "Reservations",
                column: "User_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Screen_Show_Mappers_Screen_id",
                table: "Screen_Show_Mappers",
                column: "Screen_id");

            migrationBuilder.CreateIndex(
                name: "IX_Screen_Show_Mappers_Show_id",
                table: "Screen_Show_Mappers",
                column: "Show_id");

            migrationBuilder.CreateIndex(
                name: "IX_Screens_Theater_id",
                table: "Screens",
                column: "Theater_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_Movie_id",
                table: "Shows",
                column: "Movie_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation_Bookedseats_Mappers");

            migrationBuilder.DropTable(
                name: "Screen_Show_Mappers");

            migrationBuilder.DropTable(
                name: "Booked_Seats");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Fares");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.RenameColumn(
                name: "User_phoneNumber",
                table: "Users",
                newName: "user_phoneNumber");

            migrationBuilder.RenameColumn(
                name: "User_password",
                table: "Users",
                newName: "user_password");

            migrationBuilder.RenameColumn(
                name: "User_name",
                table: "Users",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "User_mailId",
                table: "Users",
                newName: "user_mailId");

            migrationBuilder.RenameColumn(
                name: "User_location",
                table: "Users",
                newName: "user_location");

            migrationBuilder.RenameColumn(
                name: "User_language",
                table: "Users",
                newName: "user_language");

            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "Users",
                newName: "user_id");

            migrationBuilder.AddColumn<string>(
                name: "Movies",
                table: "Theaters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Screen_ids",
                table: "Theaters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
