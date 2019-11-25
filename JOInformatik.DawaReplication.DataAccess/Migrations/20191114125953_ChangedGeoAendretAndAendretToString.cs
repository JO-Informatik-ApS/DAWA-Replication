using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JOInformatik.DawaReplication.DataAccess.Migrations
{
    public partial class ChangedGeoAendretAndAendretToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "zone",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "zone",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "valglandsdel",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "valglandsdel",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "supplerendebynavn",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "supplerendebynavn",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "storkreds",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "storkreds",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "sogn",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "sogn",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "retskreds",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "retskreds",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "region",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "region",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "politikreds",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "politikreds",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "opstillingskreds",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "opstillingskreds",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "menighedsrådsafstemningsområde",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "menighedsrådsafstemningsområde",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "landpostnummer",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "landpostnummer",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "kommune",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "kommune",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "dagi_postnummer",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "dagi_postnummer",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ændret",
                table: "afstemningsområde",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "geo_ændret",
                table: "afstemningsområde",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "valglandsdel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "valglandsdel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "supplerendebynavn",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "supplerendebynavn",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "storkreds",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "storkreds",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "sogn",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "sogn",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "retskreds",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "retskreds",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "region",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "region",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "politikreds",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "politikreds",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "opstillingskreds",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "opstillingskreds",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "menighedsrådsafstemningsområde",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "menighedsrådsafstemningsområde",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "landpostnummer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "landpostnummer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "kommune",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "kommune",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "dagi_postnummer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "dagi_postnummer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ændret",
                table: "afstemningsområde",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "geo_ændret",
                table: "afstemningsområde",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");
        }
    }
}
