using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Glx.Data.Migrations {
    /// <inheritdoc />
    public partial class InitialDb : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Episode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Movies", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Climate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diameter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gravity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrbitalPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RotationPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Terrain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterCoverage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Planets", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consumables = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crew = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HyperdriveRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxAtmosphericSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxMegaLightsSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passengers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Starships", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consumables = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crew = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxAtmosphericSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passengers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Vehicles", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EyeColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HairColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkinColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanetId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Characters", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Characters_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movies_Planets",
                columns: table => new {
                    MoviesId = table.Column<long>(type: "bigint", nullable: false),
                    PlanetsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Movies_Planets", x => new { x.MoviesId, x.PlanetsId });
                    table.ForeignKey(
                        name: "FK_Movies_Planets_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_Planets_Planets_PlanetsId",
                        column: x => x.PlanetsId,
                        principalTable: "Planets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageLifespan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EyeColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HairColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkinColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanetId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Species", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Species_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movies_Starships",
                columns: table => new {
                    MoviesId = table.Column<long>(type: "bigint", nullable: false),
                    StarshipsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Movies_Starships", x => new { x.MoviesId, x.StarshipsId });
                    table.ForeignKey(
                        name: "FK_Movies_Starships_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_Starships_Starships_StarshipsId",
                        column: x => x.StarshipsId,
                        principalTable: "Starships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movies_Vehicles",
                columns: table => new {
                    MoviesId = table.Column<long>(type: "bigint", nullable: false),
                    VehiclesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Movies_Vehicles", x => new { x.MoviesId, x.VehiclesId });
                    table.ForeignKey(
                        name: "FK_Movies_Vehicles_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_Vehicles_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Characters_Starships",
                columns: table => new {
                    PilotsId = table.Column<long>(type: "bigint", nullable: false),
                    StarshipsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Characters_Starships", x => new { x.PilotsId, x.StarshipsId });
                    table.ForeignKey(
                        name: "FK_Characters_Starships_Characters_PilotsId",
                        column: x => x.PilotsId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Starships_Starships_StarshipsId",
                        column: x => x.StarshipsId,
                        principalTable: "Starships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Characters_Vehicles",
                columns: table => new {
                    PilotsId = table.Column<long>(type: "bigint", nullable: false),
                    VehiclesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Characters_Vehicles", x => new { x.PilotsId, x.VehiclesId });
                    table.ForeignKey(
                        name: "FK_Characters_Vehicles_Characters_PilotsId",
                        column: x => x.PilotsId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Vehicles_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movies_Characters",
                columns: table => new {
                    CharactersId = table.Column<long>(type: "bigint", nullable: false),
                    MoviesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Movies_Characters", x => new { x.CharactersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_Movies_Characters_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_Characters_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Characters_Species",
                columns: table => new {
                    CharactersId = table.Column<long>(type: "bigint", nullable: false),
                    SpeciesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Characters_Species", x => new { x.CharactersId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_Characters_Species_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Species_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movies_Species",
                columns: table => new {
                    MoviesId = table.Column<long>(type: "bigint", nullable: false),
                    SpeciesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Movies_Species", x => new { x.MoviesId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_Movies_Species_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_Species_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlanetId",
                table: "Characters",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Species_SpeciesId",
                table: "Characters_Species",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Starships_StarshipsId",
                table: "Characters_Starships",
                column: "StarshipsId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Vehicles_VehiclesId",
                table: "Characters_Vehicles",
                column: "VehiclesId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Characters_MoviesId",
                table: "Movies_Characters",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Planets_PlanetsId",
                table: "Movies_Planets",
                column: "PlanetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Species_SpeciesId",
                table: "Movies_Species",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Starships_StarshipsId",
                table: "Movies_Starships",
                column: "StarshipsId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Vehicles_VehiclesId",
                table: "Movies_Vehicles",
                column: "VehiclesId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_PlanetId",
                table: "Species",
                column: "PlanetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Characters_Species");

            migrationBuilder.DropTable(
                name: "Characters_Starships");

            migrationBuilder.DropTable(
                name: "Characters_Vehicles");

            migrationBuilder.DropTable(
                name: "Movies_Characters");

            migrationBuilder.DropTable(
                name: "Movies_Planets");

            migrationBuilder.DropTable(
                name: "Movies_Species");

            migrationBuilder.DropTable(
                name: "Movies_Starships");

            migrationBuilder.DropTable(
                name: "Movies_Vehicles");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Starships");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
