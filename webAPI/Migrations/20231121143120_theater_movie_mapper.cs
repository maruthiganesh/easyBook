using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class theater_movie_mapper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Theater_Movie_Mappers",
                columns: table => new
                {
                    TM_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theater_id = table.Column<int>(type: "int", nullable: false),
                    Movie_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theater_Movie_Mappers", x => x.TM_id);
                    table.ForeignKey(
                        name: "FK_Theater_Movie_Mappers_Movies_Movie_id",
                        column: x => x.Movie_id,
                        principalTable: "Movies",
                        principalColumn: "Movie_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Theater_Movie_Mappers_Theaters_Theater_id",
                        column: x => x.Theater_id,
                        principalTable: "Theaters",
                        principalColumn: "Theater_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Theater_Movie_Mappers_Movie_id",
                table: "Theater_Movie_Mappers",
                column: "Movie_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Theater_Movie_Mappers_Theater_id",
                table: "Theater_Movie_Mappers",
                column: "Theater_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Theater_Movie_Mappers");
        }
    }
}
