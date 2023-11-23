using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace apiqxote.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "tree");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "plant");

            migrationBuilder.DropColumn(
                name: "coördinate_count",
                table: "tree_name");

            migrationBuilder.DropColumn(
                name: "coördinate",
                table: "tree");

            migrationBuilder.DropColumn(
                name: "class",
                table: "plant");

            migrationBuilder.RenameColumn(
                name: "zone_zone",
                table: "animal",
                newName: "zone");

            migrationBuilder.AddColumn<int>(
                name: "coordinate_count",
                table: "tree_name",
                type: "int(11)",
                nullable: true,
                defaultValueSql: "'NULL'");

            migrationBuilder.AddColumn<string>(
                name: "coordinate",
                table: "tree",
                type: "varchar(90)",
                maxLength: 90,
                nullable: true,
                defaultValueSql: "'NULL'");

            migrationBuilder.AlterColumn<string>(
                name: "coordinate",
                table: "plant",
                type: "varchar(90)",
                maxLength: 90,
                nullable: true,
                defaultValueSql: "'NULL'",
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");

            migrationBuilder.AlterColumn<string>(
                name: "plot_nr",
                table: "plant",
                type: "varchar(4)",
                maxLength: 4,
                nullable: true,
                defaultValueSql: "'NULL'",
                oldClrType: typeof(string),
                oldType: "varchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AddColumn<int>(
                name: "plant_id",
                table: "plant",
                type: "int(11)",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "coordinates",
                table: "animal",
                type: "varchar(90)",
                maxLength: 90,
                nullable: true,
                defaultValueSql: "'NULL'",
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45,
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "tree",
                columns: new[] { "tree_nr", "zone" });

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "plant",
                column: "plant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "tree");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "plant");

            migrationBuilder.DropColumn(
                name: "coordinate_count",
                table: "tree_name");

            migrationBuilder.DropColumn(
                name: "coordinate",
                table: "tree");

            migrationBuilder.DropColumn(
                name: "plant_id",
                table: "plant");

            migrationBuilder.RenameColumn(
                name: "zone",
                table: "animal",
                newName: "zone_zone");

            migrationBuilder.AddColumn<string>(
                name: "coördinate_count",
                table: "tree_name",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                defaultValueSql: "'NULL'");

            migrationBuilder.AddColumn<string>(
                name: "coördinate",
                table: "tree",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                defaultValueSql: "'NULL'");

            migrationBuilder.AlterColumn<string>(
                name: "plot_nr",
                table: "plant",
                type: "varchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(4)",
                oldMaxLength: 4,
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");

            migrationBuilder.AlterColumn<string>(
                name: "coordinate",
                table: "plant",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                defaultValueSql: "'NULL'",
                oldClrType: typeof(string),
                oldType: "varchar(90)",
                oldMaxLength: 90,
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");

            migrationBuilder.AddColumn<string>(
                name: "class",
                table: "plant",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                defaultValueSql: "'NULL'");

            migrationBuilder.AlterColumn<string>(
                name: "coordinates",
                table: "animal",
                type: "varchar(45)",
                maxLength: 45,
                nullable: true,
                defaultValueSql: "'NULL'",
                oldClrType: typeof(string),
                oldType: "varchar(90)",
                oldMaxLength: 90,
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "tree",
                column: "tree_nr");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "plant",
                column: "plot_nr");
        }
    }
}
