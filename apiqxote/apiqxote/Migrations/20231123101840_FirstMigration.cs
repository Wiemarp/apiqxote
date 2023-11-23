using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace apiqxote.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bio_concentration",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    species = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    bcf = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true, defaultValueSql: "'NULL'"),
                    cf = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true, defaultValueSql: "'NULL'"),
                    r = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true, defaultValueSql: "'NULL'"),
                    ctree = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tree_name",
                columns: table => new
                {
                    tree_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    coördinate_count = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tree_name);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "zone",
                columns: table => new
                {
                    zone = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    area = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    classification = table.Column<string>(type: "enum('homogenuis','no_homogenuis','transition')", nullable: true, defaultValueSql: "'NULL'"),
                    plots = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.zone);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "animal",
                columns: table => new
                {
                    animal_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'"),
                    start_time = table.Column<TimeSpan>(type: "time", nullable: true, defaultValueSql: "'NULL'"),
                    end_time = table.Column<TimeSpan>(type: "time", nullable: true, defaultValueSql: "'NULL'"),
                    temperature = table.Column<double>(type: "double", nullable: true, defaultValueSql: "'NULL'"),
                    cloud_cover = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    wind_speed = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    species_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    coordinates = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    abudance = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    coverboards = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    zone_zone = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.animal_id);
                    table.ForeignKey(
                        name: "fk_animal_zone1",
                        column: x => x.zone_zone,
                        principalTable: "zone",
                        principalColumn: "zone");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plant",
                columns: table => new
                {
                    plot_nr = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    zone = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    coordinate = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    species = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    cover = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    @class = table.Column<string>(name: "class", type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    temperature = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    humidity = table.Column<float>(type: "float", nullable: true, defaultValueSql: "'NULL'"),
                    date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.plot_nr);
                    table.ForeignKey(
                        name: "fk_plant_zone1",
                        column: x => x.zone,
                        principalTable: "zone",
                        principalColumn: "zone");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tree",
                columns: table => new
                {
                    tree_nr = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    coördinate = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "'NULL'"),
                    height = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true, defaultValueSql: "'NULL'"),
                    circumference = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true, defaultValueSql: "'NULL'"),
                    volume = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true, defaultValueSql: "'NULL'"),
                    bio_concentration_id = table.Column<int>(type: "int(11)", nullable: false),
                    tree_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    zone = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tree_nr);
                    table.ForeignKey(
                        name: "fk_tree_bio_concentration1",
                        column: x => x.bio_concentration_id,
                        principalTable: "bio_concentration",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tree_tree_name1",
                        column: x => x.tree_name,
                        principalTable: "tree_name",
                        principalColumn: "tree_name");
                    table.ForeignKey(
                        name: "fk_tree_zone1",
                        column: x => x.zone,
                        principalTable: "zone",
                        principalColumn: "zone");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "fk_animal_zone1",
                table: "animal",
                column: "zone_zone");

            migrationBuilder.CreateIndex(
                name: "fk_plant_zone1",
                table: "plant",
                column: "zone");

            migrationBuilder.CreateIndex(
                name: "fk_tree_bio_concentration1",
                table: "tree",
                column: "bio_concentration_id");

            migrationBuilder.CreateIndex(
                name: "fk_tree_tree_name1",
                table: "tree",
                column: "tree_name");

            migrationBuilder.CreateIndex(
                name: "fk_tree_zone1",
                table: "tree",
                column: "zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "animal");

            migrationBuilder.DropTable(
                name: "plant");

            migrationBuilder.DropTable(
                name: "tree");

            migrationBuilder.DropTable(
                name: "bio_concentration");

            migrationBuilder.DropTable(
                name: "tree_name");

            migrationBuilder.DropTable(
                name: "zone");
        }
    }
}
