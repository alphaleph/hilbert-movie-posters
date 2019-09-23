using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace movie_posters.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "MoviePosters",
                columns: table => new
                {
                    MoviePosterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PosterImageUrl = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Artist = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    RatingCount = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePosters", x => x.MoviePosterId);
                    table.ForeignKey(
                        name: "FK_MoviePosters_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PostedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CONVERT(date, GETDATE())"),
                    Rating = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(maxLength: 255, nullable: true),
                    MoviePosterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_MoviePosters_MoviePosterId",
                        column: x => x.MoviePosterId,
                        principalTable: "MoviePosters",
                        principalColumn: "MoviePosterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviePosters_MovieId",
                table: "MoviePosters",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MoviePosterId",
                table: "Reviews",
                column: "MoviePosterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "MoviePosters");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
