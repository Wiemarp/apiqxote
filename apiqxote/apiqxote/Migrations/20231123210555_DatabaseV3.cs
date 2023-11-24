using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiqxote.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "start_time",
                table: "animal",
                type: "datetime",
                nullable: true,
                defaultValueSql: "'NULL'",
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_time",
                table: "animal",
                type: "datetime",
                nullable: true,
                defaultValueSql: "'NULL'",
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "start_time",
                table: "animal",
                type: "time",
                nullable: true,
                defaultValueSql: "'NULL'",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "end_time",
                table: "animal",
                type: "time",
                nullable: true,
                defaultValueSql: "'NULL'",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");
        }
    }
}
