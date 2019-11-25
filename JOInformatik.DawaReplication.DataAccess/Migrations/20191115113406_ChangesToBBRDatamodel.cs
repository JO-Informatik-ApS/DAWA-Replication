using Microsoft.EntityFrameworkCore.Migrations;

namespace JOInformatik.DawaReplication.DataAccess.Migrations
{
    public partial class ChangesToBBRDatamodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bygningPåFremmedGrund",
                table: "bbr_ejendomsrelation_historik");

            migrationBuilder.DropColumn(
                name: "ejerlejlighed",
                table: "bbr_ejendomsrelation_historik");

            migrationBuilder.DropColumn(
                name: "samletFastEjendom",
                table: "bbr_ejendomsrelation_historik");

            migrationBuilder.DropColumn(
                name: "bygningPåFremmedGrund",
                table: "bbr_ejendomsrelation_aktuel");

            migrationBuilder.DropColumn(
                name: "ejerlejlighed",
                table: "bbr_ejendomsrelation_aktuel");

            migrationBuilder.DropColumn(
                name: "samletFastEjendom",
                table: "bbr_ejendomsrelation_aktuel");

            migrationBuilder.DropColumn(
                name: "bygningPåFremmedGrund",
                table: "bbr_ejendomsrelation");

            migrationBuilder.DropColumn(
                name: "ejerlejlighed",
                table: "bbr_ejendomsrelation");

            migrationBuilder.DropColumn(
                name: "samletFastEjendom",
                table: "bbr_ejendomsrelation");

            migrationBuilder.DropColumn(
                name: "byg301TypeAfFlytning",
                table: "bbr_bygning_historik");

            migrationBuilder.DropColumn(
                name: "byg406Koordinatsystem",
                table: "bbr_bygning_historik");

            migrationBuilder.DropColumn(
                name: "byg301TypeAfFlytning",
                table: "bbr_bygning_aktuel");

            migrationBuilder.DropColumn(
                name: "byg406Koordinatsystem",
                table: "bbr_bygning_aktuel");

            migrationBuilder.DropColumn(
                name: "byg301TypeAfFlytning",
                table: "bbr_bygning");

            migrationBuilder.DropColumn(
                name: "byg406Koordinatsystem",
                table: "bbr_bygning");

            migrationBuilder.RenameColumn(
                name: "adgangFraHusnummer",
                table: "bbr_opgang_historik",
                newName: "husnummer");

            migrationBuilder.RenameColumn(
                name: "adgangFraHusnummer",
                table: "bbr_opgang_aktuel",
                newName: "husnummer");

            migrationBuilder.RenameColumn(
                name: "adgangFraHusnummer",
                table: "bbr_opgang",
                newName: "husnummer");

            migrationBuilder.RenameColumn(
                name: "adresseIdentificerer",
                table: "bbr_enhed_historik",
                newName: "adresse");

            migrationBuilder.RenameColumn(
                name: "adresseIdentificerer",
                table: "bbr_enhed_aktuel",
                newName: "adresse");

            migrationBuilder.RenameColumn(
                name: "adresseIdentificerer",
                table: "bbr_enhed",
                newName: "adresse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "husnummer",
                table: "bbr_opgang_historik",
                newName: "adgangFraHusnummer");

            migrationBuilder.RenameColumn(
                name: "husnummer",
                table: "bbr_opgang_aktuel",
                newName: "adgangFraHusnummer");

            migrationBuilder.RenameColumn(
                name: "husnummer",
                table: "bbr_opgang",
                newName: "adgangFraHusnummer");

            migrationBuilder.RenameColumn(
                name: "adresse",
                table: "bbr_enhed_historik",
                newName: "adresseIdentificerer");

            migrationBuilder.RenameColumn(
                name: "adresse",
                table: "bbr_enhed_aktuel",
                newName: "adresseIdentificerer");

            migrationBuilder.RenameColumn(
                name: "adresse",
                table: "bbr_enhed",
                newName: "adresseIdentificerer");

            migrationBuilder.AddColumn<int>(
                name: "bygningPåFremmedGrund",
                table: "bbr_ejendomsrelation_historik",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ejerlejlighed",
                table: "bbr_ejendomsrelation_historik",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "samletFastEjendom",
                table: "bbr_ejendomsrelation_historik",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "bygningPåFremmedGrund",
                table: "bbr_ejendomsrelation_aktuel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ejerlejlighed",
                table: "bbr_ejendomsrelation_aktuel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "samletFastEjendom",
                table: "bbr_ejendomsrelation_aktuel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "bygningPåFremmedGrund",
                table: "bbr_ejendomsrelation",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ejerlejlighed",
                table: "bbr_ejendomsrelation",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "samletFastEjendom",
                table: "bbr_ejendomsrelation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "byg301TypeAfFlytning",
                table: "bbr_bygning_historik",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "byg406Koordinatsystem",
                table: "bbr_bygning_historik",
                type: "varchar(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "byg301TypeAfFlytning",
                table: "bbr_bygning_aktuel",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "byg406Koordinatsystem",
                table: "bbr_bygning_aktuel",
                type: "varchar(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "byg301TypeAfFlytning",
                table: "bbr_bygning",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "byg406Koordinatsystem",
                table: "bbr_bygning",
                type: "varchar(1)",
                nullable: true);
        }
    }
}
