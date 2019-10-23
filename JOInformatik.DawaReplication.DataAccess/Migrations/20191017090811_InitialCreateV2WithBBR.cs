using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.SqlServer.Types;

namespace JOInformatik.DawaReplication.DataAccess.Migrations
{
    public partial class InitialCreateV2WithBBR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adgangsadresse",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    oprettet = table.Column<DateTime>(nullable: true),
                    ændret = table.Column<DateTime>(nullable: true),
                    ikrafttrædelsesdato = table.Column<DateTime>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    vejkode = table.Column<string>(type: "varchar(4)", nullable: true),
                    husnr = table.Column<string>(type: "varchar(4)", nullable: true),
                    supplerendebynavn = table.Column<string>(type: "varchar(40)", nullable: true),
                    postnr = table.Column<string>(type: "varchar(4)", nullable: true),
                    ejerlavkode = table.Column<int>(nullable: true),
                    matrikelnr = table.Column<string>(type: "varchar(10)", nullable: true),
                    esrejendomsnr = table.Column<string>(type: "varchar(7)", nullable: true),
                    etrs89koordinat_øst = table.Column<double>(nullable: true),
                    etrs89koordinat_nord = table.Column<double>(nullable: true),
                    nøjagtighed = table.Column<string>(type: "varchar(1)", nullable: false),
                    kilde = table.Column<int>(nullable: true),
                    husnummerkilde = table.Column<int>(nullable: true),
                    tekniskstandard = table.Column<string>(type: "varchar(2)", nullable: true),
                    tekstretning = table.Column<double>(nullable: true),
                    adressepunktændringsdato = table.Column<DateTime>(nullable: true),
                    esdhreference = table.Column<string>(type: "varchar(1000)", nullable: true),
                    journalnummer = table.Column<string>(type: "varchar(1000)", nullable: true),
                    højde = table.Column<double>(nullable: true),
                    adgangspunktid = table.Column<Guid>(nullable: true),
                    supplerendebynavn_dagi_id = table.Column<string>(type: "varchar(10)", nullable: true),
                    vejpunkt_id = table.Column<Guid>(nullable: true),
                    navngivenvej_id = table.Column<Guid>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adgangsadresse", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adresse",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    oprettet = table.Column<DateTime>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    ikrafttrædelsesdato = table.Column<DateTime>(nullable: true),
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    etage = table.Column<string>(type: "varchar(3)", nullable: true),
                    dør = table.Column<string>(type: "varchar(6)", nullable: true),
                    kilde = table.Column<int>(nullable: true),
                    esdhreference = table.Column<string>(type: "varchar(1000)", nullable: true),
                    journalnummer = table.Column<string>(type: "varchar(1000)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresse", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "afstemningsområde",
                columns: table => new
                {
                    nummer = table.Column<string>(type: "varchar(4)", nullable: false),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    dagi_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    navn = table.Column<string>(type: "varchar(100)", nullable: false),
                    afstemningsstednavn = table.Column<string>(type: "varchar(100)", nullable: false),
                    afstemningsstedadresse = table.Column<string>(type: "varchar(36)", nullable: false),
                    opstillingskreds_dagi_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_afstemningsområde", x => new { x.kommunekode, x.nummer });
                });

            migrationBuilder.CreateTable(
                name: "afstemningsområdetilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    afstemningsområdenummer = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_afstemningsområdetilknytning", x => new { x.adgangsadresseid, x.kommunekode, x.afstemningsområdenummer });
                });

            migrationBuilder.CreateTable(
                name: "bbr_bygning",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    registreringstart = table.Column<DateTime>(nullable: false),
                    registreringslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    jordstykke = table.Column<int>(nullable: true),
                    husnummer = table.Column<Guid>(nullable: true),
                    ejerlejlighed = table.Column<Guid>(nullable: true),
                    grund = table.Column<Guid>(nullable: true),
                    byg007Bygningsnummer = table.Column<int>(nullable: true),
                    byg021BygningensAnvendelse = table.Column<string>(type: "varchar(3)", nullable: true),
                    byg024AntalLejlighederMedKøkken = table.Column<int>(nullable: true),
                    byg025AntalLejlighederUdenKøkken = table.Column<int>(nullable: true),
                    byg026Opførelsesår = table.Column<int>(nullable: true),
                    byg027OmTilbygningsår = table.Column<int>(nullable: true),
                    byg029DatoForMidlertidigOpførtBygning = table.Column<DateTime>(nullable: true),
                    byg030Vandforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg031Afløbsforhold = table.Column<string>(type: "varchar(3)", nullable: true),
                    byg032YdervæggensMateriale = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg033Tagdækningsmateriale = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg034SupplerendeYdervæggensMateriale = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg035SupplerendeTagdækningsMateriale = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg036AsbestholdigtMateriale = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg037KildeTilBygningensMaterialer = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg038SamletBygningsareal = table.Column<int>(nullable: true),
                    byg039BygningensSamledeBoligAreal = table.Column<int>(nullable: true),
                    byg040BygningensSamledeErhvervsAreal = table.Column<int>(nullable: true),
                    byg041BebyggetAreal = table.Column<int>(nullable: true),
                    byg042ArealIndbyggetGarage = table.Column<int>(nullable: true),
                    byg043ArealIndbyggetCarport = table.Column<int>(nullable: true),
                    byg044ArealIndbyggetUdhus = table.Column<int>(nullable: true),
                    byg045ArealIndbyggetUdestueEllerLign = table.Column<int>(nullable: true),
                    byg046SamletArealAfLukkedeOverdækningerPåBygningen = table.Column<int>(nullable: true),
                    byg047ArealAfAffaldsrumITerrænniveau = table.Column<int>(nullable: true),
                    byg048AndetAreal = table.Column<int>(nullable: true),
                    byg049ArealAfOverdækketAreal = table.Column<int>(nullable: true),
                    byg050ArealÅbneOverdækningerPåBygningenSamlet = table.Column<int>(nullable: true),
                    byg051Adgangsareal = table.Column<int>(nullable: true),
                    byg052BeregningsprincipCarportAreal = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg053BygningsarealerKilde = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg054AntalEtager = table.Column<int>(nullable: true),
                    byg055AfvigendeEtager = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg056Varmeinstallation = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg057Opvarmningsmiddel = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg058SupplerendeVarme = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg069Sikringsrumpladser = table.Column<int>(nullable: true),
                    byg070Fredning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg071BevaringsværdighedReference = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg094Revisionsdato = table.Column<DateTime>(nullable: true),
                    byg111StormrådetsOversvømmelsesSelvrisiko = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg112DatoForRegistreringFraStormrådet = table.Column<DateTime>(nullable: true),
                    byg113Byggeskadeforsikringsselskab = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg114DatoForByggeskadeforsikring = table.Column<DateTime>(nullable: true),
                    byg119Udledningstilladelse = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg121OmfattetAfByggeskadeforsikring = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg122Gyldighedsdato = table.Column<DateTime>(nullable: true),
                    byg123MedlemskabAfSpildevandsforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg124PåbudVedrSpildevandsafledning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg125FristVedrSpildevandsafledning = table.Column<DateTime>(nullable: true),
                    byg126TilladelseTilUdtræden = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg127DatoForTilladelseTilUdtræden = table.Column<DateTime>(nullable: true),
                    byg128TilladelseTilAlternativBortskaffelseEllerAfledning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg129DatoForTilladelseTilAlternativBortskaffelseEllerAfledning = table.Column<DateTime>(nullable: true),
                    byg130ArealAfUdvendigEfterisolering = table.Column<int>(nullable: true),
                    byg131DispensationFritagelseIftKollektivVarmeforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg132DatoForDispensationFritagelseIftKollektivVarmeforsyning = table.Column<DateTime>(nullable: true),
                    byg133KildeTilKoordinatsæt = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg134KvalitetAfKoordinatsæt = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg135SupplerendeOplysningOmKoordinatsæt = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg136PlaceringPåSøterritorie = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg137BanedanmarkBygværksnummer = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg140ServitutForUdlejningsEjendomDato = table.Column<DateTime>(nullable: true),
                    byg150Gulvbelægning = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg151Frihøjde = table.Column<double>(nullable: true),
                    byg152ÅbenLukketKonstruktion = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg153Konstruktionsforhold = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg301TypeAfFlytning = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg302Tilflytterkommune = table.Column<int>(nullable: true),
                    byg403ØvrigeBemærkningerFraStormrådet = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg404Koordinat = table.Column<SqlGeometry>(nullable: true),
                    byg406Koordinatsystem = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_bygning", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_bygning_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    jordstykke = table.Column<int>(nullable: true),
                    husnummer = table.Column<Guid>(nullable: true),
                    ejerlejlighed = table.Column<Guid>(nullable: true),
                    grund = table.Column<Guid>(nullable: true),
                    byg007Bygningsnummer = table.Column<int>(nullable: true),
                    byg021BygningensAnvendelse = table.Column<string>(type: "varchar(3)", nullable: true),
                    byg024AntalLejlighederMedKøkken = table.Column<int>(nullable: true),
                    byg025AntalLejlighederUdenKøkken = table.Column<int>(nullable: true),
                    byg026Opførelsesår = table.Column<int>(nullable: true),
                    byg027OmTilbygningsår = table.Column<int>(nullable: true),
                    byg029DatoForMidlertidigOpførtBygning = table.Column<DateTime>(nullable: true),
                    byg030Vandforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg031Afløbsforhold = table.Column<string>(type: "varchar(3)", nullable: true),
                    byg032YdervæggensMateriale = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg033Tagdækningsmateriale = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg034SupplerendeYdervæggensMateriale = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg035SupplerendeTagdækningsMateriale = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg036AsbestholdigtMateriale = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg037KildeTilBygningensMaterialer = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg038SamletBygningsareal = table.Column<int>(nullable: true),
                    byg039BygningensSamledeBoligAreal = table.Column<int>(nullable: true),
                    byg040BygningensSamledeErhvervsAreal = table.Column<int>(nullable: true),
                    byg041BebyggetAreal = table.Column<int>(nullable: true),
                    byg042ArealIndbyggetGarage = table.Column<int>(nullable: true),
                    byg043ArealIndbyggetCarport = table.Column<int>(nullable: true),
                    byg044ArealIndbyggetUdhus = table.Column<int>(nullable: true),
                    byg045ArealIndbyggetUdestueEllerLign = table.Column<int>(nullable: true),
                    byg046SamletArealAfLukkedeOverdækningerPåBygningen = table.Column<int>(nullable: true),
                    byg047ArealAfAffaldsrumITerrænniveau = table.Column<int>(nullable: true),
                    byg048AndetAreal = table.Column<int>(nullable: true),
                    byg049ArealAfOverdækketAreal = table.Column<int>(nullable: true),
                    byg050ArealÅbneOverdækningerPåBygningenSamlet = table.Column<int>(nullable: true),
                    byg051Adgangsareal = table.Column<int>(nullable: true),
                    byg052BeregningsprincipCarportAreal = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg053BygningsarealerKilde = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg054AntalEtager = table.Column<int>(nullable: true),
                    byg055AfvigendeEtager = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg056Varmeinstallation = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg057Opvarmningsmiddel = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg058SupplerendeVarme = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg069Sikringsrumpladser = table.Column<int>(nullable: true),
                    byg070Fredning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg071BevaringsværdighedReference = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg094Revisionsdato = table.Column<DateTime>(nullable: true),
                    byg111StormrådetsOversvømmelsesSelvrisiko = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg112DatoForRegistreringFraStormrådet = table.Column<DateTime>(nullable: true),
                    byg113Byggeskadeforsikringsselskab = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg114DatoForByggeskadeforsikring = table.Column<DateTime>(nullable: true),
                    byg119Udledningstilladelse = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg121OmfattetAfByggeskadeforsikring = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg122Gyldighedsdato = table.Column<DateTime>(nullable: true),
                    byg123MedlemskabAfSpildevandsforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg124PåbudVedrSpildevandsafledning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg125FristVedrSpildevandsafledning = table.Column<DateTime>(nullable: true),
                    byg126TilladelseTilUdtræden = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg127DatoForTilladelseTilUdtræden = table.Column<DateTime>(nullable: true),
                    byg128TilladelseTilAlternativBortskaffelseEllerAfledning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg129DatoForTilladelseTilAlternativBortskaffelseEllerAfledning = table.Column<DateTime>(nullable: true),
                    byg130ArealAfUdvendigEfterisolering = table.Column<int>(nullable: true),
                    byg131DispensationFritagelseIftKollektivVarmeforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg132DatoForDispensationFritagelseIftKollektivVarmeforsyning = table.Column<DateTime>(nullable: true),
                    byg133KildeTilKoordinatsæt = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg134KvalitetAfKoordinatsæt = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg135SupplerendeOplysningOmKoordinatsæt = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg136PlaceringPåSøterritorie = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg137BanedanmarkBygværksnummer = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg140ServitutForUdlejningsEjendomDato = table.Column<DateTime>(nullable: true),
                    byg150Gulvbelægning = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg151Frihøjde = table.Column<double>(nullable: true),
                    byg152ÅbenLukketKonstruktion = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg153Konstruktionsforhold = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg301TypeAfFlytning = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg302Tilflytterkommune = table.Column<int>(nullable: true),
                    byg403ØvrigeBemærkningerFraStormrådet = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg404Koordinat = table.Column<SqlGeometry>(nullable: true),
                    byg406Koordinatsystem = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_bygning_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bbr_bygning_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    jordstykke = table.Column<int>(nullable: true),
                    husnummer = table.Column<Guid>(nullable: true),
                    ejerlejlighed = table.Column<Guid>(nullable: true),
                    grund = table.Column<Guid>(nullable: true),
                    byg007Bygningsnummer = table.Column<int>(nullable: true),
                    byg021BygningensAnvendelse = table.Column<string>(type: "varchar(3)", nullable: true),
                    byg024AntalLejlighederMedKøkken = table.Column<int>(nullable: true),
                    byg025AntalLejlighederUdenKøkken = table.Column<int>(nullable: true),
                    byg026Opførelsesår = table.Column<int>(nullable: true),
                    byg027OmTilbygningsår = table.Column<int>(nullable: true),
                    byg029DatoForMidlertidigOpførtBygning = table.Column<DateTime>(nullable: true),
                    byg030Vandforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg031Afløbsforhold = table.Column<string>(type: "varchar(3)", nullable: true),
                    byg032YdervæggensMateriale = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg033Tagdækningsmateriale = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg034SupplerendeYdervæggensMateriale = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg035SupplerendeTagdækningsMateriale = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg036AsbestholdigtMateriale = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg037KildeTilBygningensMaterialer = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg038SamletBygningsareal = table.Column<int>(nullable: true),
                    byg039BygningensSamledeBoligAreal = table.Column<int>(nullable: true),
                    byg040BygningensSamledeErhvervsAreal = table.Column<int>(nullable: true),
                    byg041BebyggetAreal = table.Column<int>(nullable: true),
                    byg042ArealIndbyggetGarage = table.Column<int>(nullable: true),
                    byg043ArealIndbyggetCarport = table.Column<int>(nullable: true),
                    byg044ArealIndbyggetUdhus = table.Column<int>(nullable: true),
                    byg045ArealIndbyggetUdestueEllerLign = table.Column<int>(nullable: true),
                    byg046SamletArealAfLukkedeOverdækningerPåBygningen = table.Column<int>(nullable: true),
                    byg047ArealAfAffaldsrumITerrænniveau = table.Column<int>(nullable: true),
                    byg048AndetAreal = table.Column<int>(nullable: true),
                    byg049ArealAfOverdækketAreal = table.Column<int>(nullable: true),
                    byg050ArealÅbneOverdækningerPåBygningenSamlet = table.Column<int>(nullable: true),
                    byg051Adgangsareal = table.Column<int>(nullable: true),
                    byg052BeregningsprincipCarportAreal = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg053BygningsarealerKilde = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg054AntalEtager = table.Column<int>(nullable: true),
                    byg055AfvigendeEtager = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg056Varmeinstallation = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg057Opvarmningsmiddel = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg058SupplerendeVarme = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg069Sikringsrumpladser = table.Column<int>(nullable: true),
                    byg070Fredning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg071BevaringsværdighedReference = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg094Revisionsdato = table.Column<DateTime>(nullable: true),
                    byg111StormrådetsOversvømmelsesSelvrisiko = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg112DatoForRegistreringFraStormrådet = table.Column<DateTime>(nullable: true),
                    byg113Byggeskadeforsikringsselskab = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg114DatoForByggeskadeforsikring = table.Column<DateTime>(nullable: true),
                    byg119Udledningstilladelse = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg121OmfattetAfByggeskadeforsikring = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg122Gyldighedsdato = table.Column<DateTime>(nullable: true),
                    byg123MedlemskabAfSpildevandsforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg124PåbudVedrSpildevandsafledning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg125FristVedrSpildevandsafledning = table.Column<DateTime>(nullable: true),
                    byg126TilladelseTilUdtræden = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg127DatoForTilladelseTilUdtræden = table.Column<DateTime>(nullable: true),
                    byg128TilladelseTilAlternativBortskaffelseEllerAfledning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg129DatoForTilladelseTilAlternativBortskaffelseEllerAfledning = table.Column<DateTime>(nullable: true),
                    byg130ArealAfUdvendigEfterisolering = table.Column<int>(nullable: true),
                    byg131DispensationFritagelseIftKollektivVarmeforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg132DatoForDispensationFritagelseIftKollektivVarmeforsyning = table.Column<DateTime>(nullable: true),
                    byg133KildeTilKoordinatsæt = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg134KvalitetAfKoordinatsæt = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg135SupplerendeOplysningOmKoordinatsæt = table.Column<string>(type: "varchar(2)", nullable: true),
                    byg136PlaceringPåSøterritorie = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg137BanedanmarkBygværksnummer = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg140ServitutForUdlejningsEjendomDato = table.Column<DateTime>(nullable: true),
                    byg150Gulvbelægning = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg151Frihøjde = table.Column<double>(nullable: true),
                    byg152ÅbenLukketKonstruktion = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg153Konstruktionsforhold = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg301TypeAfFlytning = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg302Tilflytterkommune = table.Column<int>(nullable: true),
                    byg403ØvrigeBemærkningerFraStormrådet = table.Column<string>(type: "varchar(200)", nullable: true),
                    byg404Koordinat = table.Column<SqlGeometry>(nullable: true),
                    byg406Koordinatsystem = table.Column<string>(type: "varchar(1)", nullable: true),
                    byg500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_bygning_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_bygningpåfremmedgrund",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    registreringstart = table.Column<DateTime>(nullable: false),
                    registreringslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    bygningPåFremmedGrund = table.Column<Guid>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_bygningpåfremmedgrund", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_bygningpåfremmedgrund_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    bygningPåFremmedGrund = table.Column<Guid>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_bygningpåfremmedgrund_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bbr_bygningpåfremmedgrund_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    bygningPåFremmedGrund = table.Column<Guid>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_bygningpåfremmedgrund_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_ejendomsrelation",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    registreringstart = table.Column<DateTime>(nullable: false),
                    registreringslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    bygningPåFremmedGrund = table.Column<int>(nullable: true),
                    ejerlejlighed = table.Column<int>(nullable: true),
                    samletFastEjendom = table.Column<int>(nullable: true),
                    bfeNummer = table.Column<int>(nullable: true),
                    ejendommensEjerforholdskode = table.Column<string>(type: "varchar(2)", nullable: true),
                    ejendomsnummer = table.Column<int>(nullable: true),
                    ejendomstype = table.Column<string>(type: "varchar(40)", nullable: true),
                    ejerlejlighedsnummer = table.Column<int>(nullable: true),
                    tinglystAreal = table.Column<int>(nullable: true),
                    vurderingsejendomsnummer = table.Column<int>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_ejendomsrelation", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_ejendomsrelation_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    bygningPåFremmedGrund = table.Column<int>(nullable: true),
                    ejerlejlighed = table.Column<int>(nullable: true),
                    samletFastEjendom = table.Column<int>(nullable: true),
                    bfeNummer = table.Column<int>(nullable: true),
                    ejendommensEjerforholdskode = table.Column<string>(type: "varchar(2)", nullable: true),
                    ejendomsnummer = table.Column<int>(nullable: true),
                    ejendomstype = table.Column<string>(type: "varchar(40)", nullable: true),
                    ejerlejlighedsnummer = table.Column<int>(nullable: true),
                    tinglystAreal = table.Column<int>(nullable: true),
                    vurderingsejendomsnummer = table.Column<int>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_ejendomsrelation_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bbr_ejendomsrelation_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    bygningPåFremmedGrund = table.Column<int>(nullable: true),
                    ejerlejlighed = table.Column<int>(nullable: true),
                    samletFastEjendom = table.Column<int>(nullable: true),
                    bfeNummer = table.Column<int>(nullable: true),
                    ejendommensEjerforholdskode = table.Column<string>(type: "varchar(2)", nullable: true),
                    ejendomsnummer = table.Column<int>(nullable: true),
                    ejendomstype = table.Column<string>(type: "varchar(40)", nullable: true),
                    ejerlejlighedsnummer = table.Column<int>(nullable: true),
                    tinglystAreal = table.Column<int>(nullable: true),
                    vurderingsejendomsnummer = table.Column<int>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_ejendomsrelation_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_enhed",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    registreringstart = table.Column<DateTime>(nullable: false),
                    registreringslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    adresseIdentificerer = table.Column<Guid>(nullable: true),
                    etage = table.Column<Guid>(nullable: true),
                    opgang = table.Column<Guid>(nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    enh020EnhedensAnvendelse = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh023Boligtype = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh024KondemneretBoligenhed = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh025OprettelsesdatoForEnhedensIdentifikation = table.Column<DateTime>(nullable: true),
                    enh026EnhedensSamledeAreal = table.Column<int>(nullable: true),
                    enh027ArealTilBeboelse = table.Column<int>(nullable: true),
                    enh028ArealTilErhverv = table.Column<int>(nullable: true),
                    enh030KildeTilEnhedensArealer = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh031AntalVærelser = table.Column<int>(nullable: true),
                    enh032Toiletforhold = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh033Badeforhold = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh034Køkkenforhold = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh035Energiforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh039AndetAreal = table.Column<int>(nullable: true),
                    enh041LovligAnvendelse = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh042DatoForTidsbegrænsetDispensation = table.Column<DateTime>(nullable: true),
                    enh044DatoForDelvisIbrugtagningsTilladelse = table.Column<DateTime>(nullable: true),
                    enh045Udlejningsforhold = table.Column<string>(type: "varchar(200)", nullable: true),
                    enh046OffentligStøtte = table.Column<string>(type: "varchar(2)", nullable: true),
                    enh047IndflytningDato = table.Column<DateTime>(nullable: true),
                    enh048GodkendtTomBolig = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh051Varmeinstallation = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh052Opvarmningsmiddel = table.Column<string>(type: "varchar(200)", nullable: true),
                    enh053SupplerendeVarme = table.Column<string>(type: "varchar(2)", nullable: true),
                    enh060EnhedensAndelFællesAdgangsareal = table.Column<int>(nullable: true),
                    enh061ArealAfÅbenOverdækning = table.Column<int>(nullable: true),
                    enh062ArealAfLukketOverdækningUdestue = table.Column<int>(nullable: true),
                    enh063AntalVærelserTilErhverv = table.Column<int>(nullable: true),
                    enh065AntalVandskylledeToiletter = table.Column<int>(nullable: true),
                    enh066AntalBadeværelser = table.Column<int>(nullable: true),
                    enh067Støjisolering = table.Column<int>(nullable: true),
                    enh068FlexboligTilladelsesart = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh069FlexboligOphørsdato = table.Column<DateTime>(nullable: true),
                    enh070ÅbenAltanTagterrasseAreal = table.Column<int>(nullable: true),
                    enh071AdresseFunktion = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh101Gyldighedsdato = table.Column<DateTime>(nullable: true),
                    enh102HerafAreal1 = table.Column<int>(nullable: true),
                    enh103HerafAreal2 = table.Column<int>(nullable: true),
                    enh104HerafAreal3 = table.Column<int>(nullable: true),
                    enh105SupplerendeAnvendelseskode1 = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh106SupplerendeAnvendelseskode2 = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh107SupplerendeAnvendelseskode3 = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh127FysiskArealTilBeboelse = table.Column<int>(nullable: true),
                    enh128FysiskArealTilErhverv = table.Column<int>(nullable: true),
                    enh500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_enhed", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_enhed_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    adresseIdentificerer = table.Column<Guid>(nullable: true),
                    etage = table.Column<Guid>(nullable: true),
                    opgang = table.Column<Guid>(nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    enh020EnhedensAnvendelse = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh023Boligtype = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh024KondemneretBoligenhed = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh025OprettelsesdatoForEnhedensIdentifikation = table.Column<DateTime>(nullable: true),
                    enh026EnhedensSamledeAreal = table.Column<int>(nullable: true),
                    enh027ArealTilBeboelse = table.Column<int>(nullable: true),
                    enh028ArealTilErhverv = table.Column<int>(nullable: true),
                    enh030KildeTilEnhedensArealer = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh031AntalVærelser = table.Column<int>(nullable: true),
                    enh032Toiletforhold = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh033Badeforhold = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh034Køkkenforhold = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh035Energiforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh039AndetAreal = table.Column<int>(nullable: true),
                    enh041LovligAnvendelse = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh042DatoForTidsbegrænsetDispensation = table.Column<DateTime>(nullable: true),
                    enh044DatoForDelvisIbrugtagningsTilladelse = table.Column<DateTime>(nullable: true),
                    enh045Udlejningsforhold = table.Column<string>(type: "varchar(200)", nullable: true),
                    enh046OffentligStøtte = table.Column<string>(type: "varchar(2)", nullable: true),
                    enh047IndflytningDato = table.Column<DateTime>(nullable: true),
                    enh048GodkendtTomBolig = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh051Varmeinstallation = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh052Opvarmningsmiddel = table.Column<string>(type: "varchar(200)", nullable: true),
                    enh053SupplerendeVarme = table.Column<string>(type: "varchar(2)", nullable: true),
                    enh060EnhedensAndelFællesAdgangsareal = table.Column<int>(nullable: true),
                    enh061ArealAfÅbenOverdækning = table.Column<int>(nullable: true),
                    enh062ArealAfLukketOverdækningUdestue = table.Column<int>(nullable: true),
                    enh063AntalVærelserTilErhverv = table.Column<int>(nullable: true),
                    enh065AntalVandskylledeToiletter = table.Column<int>(nullable: true),
                    enh066AntalBadeværelser = table.Column<int>(nullable: true),
                    enh067Støjisolering = table.Column<int>(nullable: true),
                    enh068FlexboligTilladelsesart = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh069FlexboligOphørsdato = table.Column<DateTime>(nullable: true),
                    enh070ÅbenAltanTagterrasseAreal = table.Column<int>(nullable: true),
                    enh071AdresseFunktion = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh101Gyldighedsdato = table.Column<DateTime>(nullable: true),
                    enh102HerafAreal1 = table.Column<int>(nullable: true),
                    enh103HerafAreal2 = table.Column<int>(nullable: true),
                    enh104HerafAreal3 = table.Column<int>(nullable: true),
                    enh105SupplerendeAnvendelseskode1 = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh106SupplerendeAnvendelseskode2 = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh107SupplerendeAnvendelseskode3 = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh127FysiskArealTilBeboelse = table.Column<int>(nullable: true),
                    enh128FysiskArealTilErhverv = table.Column<int>(nullable: true),
                    enh500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_enhed_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bbr_enhed_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    adresseIdentificerer = table.Column<Guid>(nullable: true),
                    etage = table.Column<Guid>(nullable: true),
                    opgang = table.Column<Guid>(nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    enh020EnhedensAnvendelse = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh023Boligtype = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh024KondemneretBoligenhed = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh025OprettelsesdatoForEnhedensIdentifikation = table.Column<DateTime>(nullable: true),
                    enh026EnhedensSamledeAreal = table.Column<int>(nullable: true),
                    enh027ArealTilBeboelse = table.Column<int>(nullable: true),
                    enh028ArealTilErhverv = table.Column<int>(nullable: true),
                    enh030KildeTilEnhedensArealer = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh031AntalVærelser = table.Column<int>(nullable: true),
                    enh032Toiletforhold = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh033Badeforhold = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh034Køkkenforhold = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh035Energiforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh039AndetAreal = table.Column<int>(nullable: true),
                    enh041LovligAnvendelse = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh042DatoForTidsbegrænsetDispensation = table.Column<DateTime>(nullable: true),
                    enh044DatoForDelvisIbrugtagningsTilladelse = table.Column<DateTime>(nullable: true),
                    enh045Udlejningsforhold = table.Column<string>(type: "varchar(200)", nullable: true),
                    enh046OffentligStøtte = table.Column<string>(type: "varchar(2)", nullable: true),
                    enh047IndflytningDato = table.Column<DateTime>(nullable: true),
                    enh048GodkendtTomBolig = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh051Varmeinstallation = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh052Opvarmningsmiddel = table.Column<string>(type: "varchar(200)", nullable: true),
                    enh053SupplerendeVarme = table.Column<string>(type: "varchar(2)", nullable: true),
                    enh060EnhedensAndelFællesAdgangsareal = table.Column<int>(nullable: true),
                    enh061ArealAfÅbenOverdækning = table.Column<int>(nullable: true),
                    enh062ArealAfLukketOverdækningUdestue = table.Column<int>(nullable: true),
                    enh063AntalVærelserTilErhverv = table.Column<int>(nullable: true),
                    enh065AntalVandskylledeToiletter = table.Column<int>(nullable: true),
                    enh066AntalBadeværelser = table.Column<int>(nullable: true),
                    enh067Støjisolering = table.Column<int>(nullable: true),
                    enh068FlexboligTilladelsesart = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh069FlexboligOphørsdato = table.Column<DateTime>(nullable: true),
                    enh070ÅbenAltanTagterrasseAreal = table.Column<int>(nullable: true),
                    enh071AdresseFunktion = table.Column<string>(type: "varchar(1)", nullable: true),
                    enh101Gyldighedsdato = table.Column<DateTime>(nullable: true),
                    enh102HerafAreal1 = table.Column<int>(nullable: true),
                    enh103HerafAreal2 = table.Column<int>(nullable: true),
                    enh104HerafAreal3 = table.Column<int>(nullable: true),
                    enh105SupplerendeAnvendelseskode1 = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh106SupplerendeAnvendelseskode2 = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh107SupplerendeAnvendelseskode3 = table.Column<string>(type: "varchar(3)", nullable: true),
                    enh127FysiskArealTilBeboelse = table.Column<int>(nullable: true),
                    enh128FysiskArealTilErhverv = table.Column<int>(nullable: true),
                    enh500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_enhed_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_enhedejerlejlighed",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    registreringstart = table.Column<DateTime>(nullable: false),
                    registreringslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    ejerlejlighed = table.Column<Guid>(nullable: true),
                    enhed = table.Column<Guid>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_enhedejerlejlighed", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_enhedejerlejlighed_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    ejerlejlighed = table.Column<Guid>(nullable: true),
                    enhed = table.Column<Guid>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_enhedejerlejlighed_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bbr_enhedejerlejlighed_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    ejerlejlighed = table.Column<Guid>(nullable: true),
                    enhed = table.Column<Guid>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_enhedejerlejlighed_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_etage",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    registreringstart = table.Column<DateTime>(nullable: false),
                    registreringslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    eta006BygningensEtagebetegnelse = table.Column<string>(type: "varchar(2)", nullable: true),
                    eta020SamletArealAfEtage = table.Column<int>(nullable: true),
                    eta021ArealAfUdnyttetDelAfTagetage = table.Column<int>(nullable: true),
                    eta022Kælderareal = table.Column<int>(nullable: true),
                    eta023ArealAfLovligBeboelseIKælder = table.Column<int>(nullable: true),
                    eta024EtagensAdgangsareal = table.Column<int>(nullable: true),
                    eta025Etagetype = table.Column<string>(type: "varchar(1)", nullable: true),
                    eta026ErhvervIKælder = table.Column<int>(nullable: true),
                    eta500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_etage", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_etage_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    eta006BygningensEtagebetegnelse = table.Column<string>(type: "varchar(2)", nullable: true),
                    eta020SamletArealAfEtage = table.Column<int>(nullable: true),
                    eta021ArealAfUdnyttetDelAfTagetage = table.Column<int>(nullable: true),
                    eta022Kælderareal = table.Column<int>(nullable: true),
                    eta023ArealAfLovligBeboelseIKælder = table.Column<int>(nullable: true),
                    eta024EtagensAdgangsareal = table.Column<int>(nullable: true),
                    eta025Etagetype = table.Column<string>(type: "varchar(1)", nullable: true),
                    eta026ErhvervIKælder = table.Column<int>(nullable: true),
                    eta500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_etage_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bbr_etage_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    eta006BygningensEtagebetegnelse = table.Column<string>(type: "varchar(2)", nullable: true),
                    eta020SamletArealAfEtage = table.Column<int>(nullable: true),
                    eta021ArealAfUdnyttetDelAfTagetage = table.Column<int>(nullable: true),
                    eta022Kælderareal = table.Column<int>(nullable: true),
                    eta023ArealAfLovligBeboelseIKælder = table.Column<int>(nullable: true),
                    eta024EtagensAdgangsareal = table.Column<int>(nullable: true),
                    eta025Etagetype = table.Column<string>(type: "varchar(1)", nullable: true),
                    eta026ErhvervIKælder = table.Column<int>(nullable: true),
                    eta500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_etage_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_fordelingaffordelingsareal",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    registreringstart = table.Column<DateTime>(nullable: false),
                    registreringslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    enhed = table.Column<Guid>(nullable: true),
                    fordelingsareal = table.Column<Guid>(nullable: true),
                    beboelsesArealFordeltTilEnhed = table.Column<int>(nullable: true),
                    erhvervsArealFordeltTilEnhed = table.Column<int>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_fordelingaffordelingsareal", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_fordelingaffordelingsareal_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    enhed = table.Column<Guid>(nullable: true),
                    fordelingsareal = table.Column<Guid>(nullable: true),
                    beboelsesArealFordeltTilEnhed = table.Column<int>(nullable: true),
                    erhvervsArealFordeltTilEnhed = table.Column<int>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_fordelingaffordelingsareal_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bbr_fordelingaffordelingsareal_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    enhed = table.Column<Guid>(nullable: true),
                    fordelingsareal = table.Column<Guid>(nullable: true),
                    beboelsesArealFordeltTilEnhed = table.Column<int>(nullable: true),
                    erhvervsArealFordeltTilEnhed = table.Column<int>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_fordelingaffordelingsareal_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_fordelingsareal",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    registreringstart = table.Column<DateTime>(nullable: false),
                    registreringslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    for002Fordelingsarealnummer = table.Column<int>(nullable: true),
                    for003ArealTilFordeling = table.Column<int>(nullable: true),
                    for004FordelingsNøgle = table.Column<string>(type: "varchar(90)", nullable: true),
                    for005Navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    for006Rest = table.Column<int>(nullable: true),
                    for500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_fordelingsareal", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_fordelingsareal_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    for002Fordelingsarealnummer = table.Column<int>(nullable: true),
                    for003ArealTilFordeling = table.Column<int>(nullable: true),
                    for004FordelingsNøgle = table.Column<string>(type: "varchar(90)", nullable: true),
                    for005Navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    for006Rest = table.Column<int>(nullable: true),
                    for500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_fordelingsareal_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bbr_fordelingsareal_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    for002Fordelingsarealnummer = table.Column<int>(nullable: true),
                    for003ArealTilFordeling = table.Column<int>(nullable: true),
                    for004FordelingsNøgle = table.Column<string>(type: "varchar(90)", nullable: true),
                    for005Navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    for006Rest = table.Column<int>(nullable: true),
                    for500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_fordelingsareal_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_grund",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    registreringstart = table.Column<DateTime>(nullable: false),
                    registreringslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    husnummer = table.Column<Guid>(nullable: true),
                    bestemtFastEjendom = table.Column<Guid>(nullable: true),
                    gru009Vandforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru010Afløbsforhold = table.Column<string>(type: "varchar(3)", nullable: true),
                    gru021Udledningstilladelse = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru022MedlemskabAfSpildevandsforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru023PåbudVedrSpildevandsafledning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru024FristVedrSpildevandsafledning = table.Column<DateTime>(nullable: true),
                    gru025TilladelseTilUdtræden = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru026DatoForTilladelseTilUdtræden = table.Column<DateTime>(nullable: true),
                    gru027TilladelseTilAlternativBortskaffelseEllerAfledning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru028DatoForTilladelseTilAlternativBortskaffelseEllerAfledning = table.Column<DateTime>(nullable: true),
                    gru029DispensationFritagelseIftKollektivVarmeforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru030DatoForDispensationFritagelseIftKollektivVarmeforsyning = table.Column<DateTime>(nullable: true),
                    gru500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_grund", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_grund_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    husnummer = table.Column<Guid>(nullable: true),
                    bestemtFastEjendom = table.Column<Guid>(nullable: true),
                    gru009Vandforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru010Afløbsforhold = table.Column<string>(type: "varchar(3)", nullable: true),
                    gru021Udledningstilladelse = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru022MedlemskabAfSpildevandsforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru023PåbudVedrSpildevandsafledning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru024FristVedrSpildevandsafledning = table.Column<DateTime>(nullable: true),
                    gru025TilladelseTilUdtræden = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru026DatoForTilladelseTilUdtræden = table.Column<DateTime>(nullable: true),
                    gru027TilladelseTilAlternativBortskaffelseEllerAfledning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru028DatoForTilladelseTilAlternativBortskaffelseEllerAfledning = table.Column<DateTime>(nullable: true),
                    gru029DispensationFritagelseIftKollektivVarmeforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru030DatoForDispensationFritagelseIftKollektivVarmeforsyning = table.Column<DateTime>(nullable: true),
                    gru500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_grund_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bbr_grund_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    husnummer = table.Column<Guid>(nullable: true),
                    bestemtFastEjendom = table.Column<Guid>(nullable: true),
                    gru009Vandforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru010Afløbsforhold = table.Column<string>(type: "varchar(3)", nullable: true),
                    gru021Udledningstilladelse = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru022MedlemskabAfSpildevandsforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru023PåbudVedrSpildevandsafledning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru024FristVedrSpildevandsafledning = table.Column<DateTime>(nullable: true),
                    gru025TilladelseTilUdtræden = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru026DatoForTilladelseTilUdtræden = table.Column<DateTime>(nullable: true),
                    gru027TilladelseTilAlternativBortskaffelseEllerAfledning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru028DatoForTilladelseTilAlternativBortskaffelseEllerAfledning = table.Column<DateTime>(nullable: true),
                    gru029DispensationFritagelseIftKollektivVarmeforsyning = table.Column<string>(type: "varchar(1)", nullable: true),
                    gru030DatoForDispensationFritagelseIftKollektivVarmeforsyning = table.Column<DateTime>(nullable: true),
                    gru500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_grund_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_grundjordstykke",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    registreringstart = table.Column<DateTime>(nullable: false),
                    registreringslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    grund = table.Column<Guid>(nullable: true),
                    jordstykke = table.Column<int>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_grundjordstykke", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_grundjordstykke_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    grund = table.Column<Guid>(nullable: true),
                    jordstykke = table.Column<int>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_grundjordstykke_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bbr_grundjordstykke_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    grund = table.Column<Guid>(nullable: true),
                    jordstykke = table.Column<int>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_grundjordstykke_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_opgang",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    registreringstart = table.Column<DateTime>(nullable: false),
                    registreringslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    adgangFraHusnummer = table.Column<Guid>(nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    opg020Elevator = table.Column<string>(type: "varchar(10)", nullable: true),
                    opg021HusnummerFunktion = table.Column<string>(type: "varchar(2)", nullable: true),
                    opg500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_opgang", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_opgang_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    adgangFraHusnummer = table.Column<Guid>(nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    opg020Elevator = table.Column<string>(type: "varchar(10)", nullable: true),
                    opg021HusnummerFunktion = table.Column<string>(type: "varchar(2)", nullable: true),
                    opg500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_opgang_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bbr_opgang_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    adgangFraHusnummer = table.Column<Guid>(nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    opg020Elevator = table.Column<string>(type: "varchar(10)", nullable: true),
                    opg021HusnummerFunktion = table.Column<string>(type: "varchar(2)", nullable: true),
                    opg500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_opgang_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_tekniskanlæg",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    registreringstart = table.Column<DateTime>(nullable: false),
                    registreringslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    jordstykke = table.Column<int>(nullable: true),
                    husnummer = table.Column<Guid>(nullable: true),
                    enhed = table.Column<Guid>(nullable: true),
                    ejerlejlighed = table.Column<Guid>(nullable: true),
                    bygningPåFremmedGrund = table.Column<Guid>(nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    grund = table.Column<Guid>(nullable: true),
                    tek007Anlægsnummer = table.Column<int>(nullable: true),
                    tek020Klassifikation = table.Column<string>(type: "varchar(4)", nullable: true),
                    tek021FabrikatType = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek022EksternDatabase = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek023EksternNøgle = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek024Etableringsår = table.Column<int>(nullable: true),
                    tek025TilOmbygningsår = table.Column<int>(nullable: true),
                    tek026StørrelsesklasseOlietank = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek027Placering = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek028SløjfningOlietank = table.Column<string>(type: "varchar(2)", nullable: true),
                    tek030Fabrikationsnummer = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek031Typegodkendelsesnummer = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek032Størrelse = table.Column<int>(nullable: true),
                    tek033Type = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek034IndholdOlietank = table.Column<string>(type: "varchar(2)", nullable: true),
                    tek035SløjfningsfristOlietank = table.Column<DateTime>(nullable: true),
                    tek036Rumfang = table.Column<int>(nullable: true),
                    tek037Areal = table.Column<int>(nullable: true),
                    tek038Højde = table.Column<int>(nullable: true),
                    tek039Effekt = table.Column<int>(nullable: true),
                    tek040Fredning = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek042Revisionsdato = table.Column<DateTime>(nullable: true),
                    tek045Koordinatsystem = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek067Fabrikationsår = table.Column<int>(nullable: true),
                    tek068Materiale = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek069SupplerendeIndvendigKorrosionsbeskyttelse = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek070DatoForSenestUdførteSupplerendeIndvendigKorrosionsbeskyttelse = table.Column<DateTime>(nullable: true),
                    tek072Sløjfningsår = table.Column<int>(nullable: true),
                    tek073Navhøjde = table.Column<double>(nullable: true),
                    tek074Vindmøllenummer = table.Column<string>(type: "varchar(40)", nullable: true),
                    tek075Rotordiameter = table.Column<double>(nullable: true),
                    tek076KildeTilKoordinatsæt = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek077KvalitetAfKoordinatsæt = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek078SupplerendeOplysningOmKoordinatsæt = table.Column<string>(type: "varchar(2)", nullable: true),
                    tek101Gyldighedsdato = table.Column<DateTime>(nullable: true),
                    tek102FabrikatVindmølle = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek103FabrikatOliefyr = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek104FabrikatSolcelleanlægSolvarme = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek105OverdækningTank = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek106InspektionsdatoTank = table.Column<DateTime>(nullable: true),
                    tek107PlaceringPåSøterritorie = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek109Koordinat = table.Column<SqlGeometry>(nullable: true),
                    tek110Driftstatus = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek111DatoForSenesteInspektion = table.Column<DateTime>(nullable: true),
                    tek112InspicerendeVirksomhed = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_tekniskanlæg", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "bbr_tekniskanlæg_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    jordstykke = table.Column<int>(nullable: true),
                    husnummer = table.Column<Guid>(nullable: true),
                    enhed = table.Column<Guid>(nullable: true),
                    ejerlejlighed = table.Column<Guid>(nullable: true),
                    bygningPåFremmedGrund = table.Column<Guid>(nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    grund = table.Column<Guid>(nullable: true),
                    tek007Anlægsnummer = table.Column<int>(nullable: true),
                    tek020Klassifikation = table.Column<string>(type: "varchar(4)", nullable: true),
                    tek021FabrikatType = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek022EksternDatabase = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek023EksternNøgle = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek024Etableringsår = table.Column<int>(nullable: true),
                    tek025TilOmbygningsår = table.Column<int>(nullable: true),
                    tek026StørrelsesklasseOlietank = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek027Placering = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek028SløjfningOlietank = table.Column<string>(type: "varchar(2)", nullable: true),
                    tek030Fabrikationsnummer = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek031Typegodkendelsesnummer = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek032Størrelse = table.Column<int>(nullable: true),
                    tek033Type = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek034IndholdOlietank = table.Column<string>(type: "varchar(2)", nullable: true),
                    tek035SløjfningsfristOlietank = table.Column<DateTime>(nullable: true),
                    tek036Rumfang = table.Column<int>(nullable: true),
                    tek037Areal = table.Column<int>(nullable: true),
                    tek038Højde = table.Column<int>(nullable: true),
                    tek039Effekt = table.Column<int>(nullable: true),
                    tek040Fredning = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek042Revisionsdato = table.Column<DateTime>(nullable: true),
                    tek045Koordinatsystem = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek067Fabrikationsår = table.Column<int>(nullable: true),
                    tek068Materiale = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek069SupplerendeIndvendigKorrosionsbeskyttelse = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek070DatoForSenestUdførteSupplerendeIndvendigKorrosionsbeskyttelse = table.Column<DateTime>(nullable: true),
                    tek072Sløjfningsår = table.Column<int>(nullable: true),
                    tek073Navhøjde = table.Column<double>(nullable: true),
                    tek074Vindmøllenummer = table.Column<string>(type: "varchar(40)", nullable: true),
                    tek075Rotordiameter = table.Column<double>(nullable: true),
                    tek076KildeTilKoordinatsæt = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek077KvalitetAfKoordinatsæt = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek078SupplerendeOplysningOmKoordinatsæt = table.Column<string>(type: "varchar(2)", nullable: true),
                    tek101Gyldighedsdato = table.Column<DateTime>(nullable: true),
                    tek102FabrikatVindmølle = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek103FabrikatOliefyr = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek104FabrikatSolcelleanlægSolvarme = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek105OverdækningTank = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek106InspektionsdatoTank = table.Column<DateTime>(nullable: true),
                    tek107PlaceringPåSøterritorie = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek109Koordinat = table.Column<SqlGeometry>(nullable: true),
                    tek110Driftstatus = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek111DatoForSenesteInspektion = table.Column<DateTime>(nullable: true),
                    tek112InspicerendeVirksomhed = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_tekniskanlæg_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bbr_tekniskanlæg_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    forretningshændelse = table.Column<string>(type: "varchar(50)", nullable: true),
                    forretningsområde = table.Column<string>(type: "varchar(15)", nullable: true),
                    forretningsproces = table.Column<string>(type: "varchar(2)", nullable: true),
                    id = table.Column<Guid>(nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    registreringsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    status = table.Column<string>(type: "varchar(2)", nullable: true),
                    virkningsaktør = table.Column<string>(type: "varchar(90)", nullable: true),
                    jordstykke = table.Column<int>(nullable: true),
                    husnummer = table.Column<Guid>(nullable: true),
                    enhed = table.Column<Guid>(nullable: true),
                    ejerlejlighed = table.Column<Guid>(nullable: true),
                    bygningPåFremmedGrund = table.Column<Guid>(nullable: true),
                    bygning = table.Column<Guid>(nullable: true),
                    grund = table.Column<Guid>(nullable: true),
                    tek007Anlægsnummer = table.Column<int>(nullable: true),
                    tek020Klassifikation = table.Column<string>(type: "varchar(4)", nullable: true),
                    tek021FabrikatType = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek022EksternDatabase = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek023EksternNøgle = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek024Etableringsår = table.Column<int>(nullable: true),
                    tek025TilOmbygningsår = table.Column<int>(nullable: true),
                    tek026StørrelsesklasseOlietank = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek027Placering = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek028SløjfningOlietank = table.Column<string>(type: "varchar(2)", nullable: true),
                    tek030Fabrikationsnummer = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek031Typegodkendelsesnummer = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek032Størrelse = table.Column<int>(nullable: true),
                    tek033Type = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek034IndholdOlietank = table.Column<string>(type: "varchar(2)", nullable: true),
                    tek035SløjfningsfristOlietank = table.Column<DateTime>(nullable: true),
                    tek036Rumfang = table.Column<int>(nullable: true),
                    tek037Areal = table.Column<int>(nullable: true),
                    tek038Højde = table.Column<int>(nullable: true),
                    tek039Effekt = table.Column<int>(nullable: true),
                    tek040Fredning = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek042Revisionsdato = table.Column<DateTime>(nullable: true),
                    tek045Koordinatsystem = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek067Fabrikationsår = table.Column<int>(nullable: true),
                    tek068Materiale = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek069SupplerendeIndvendigKorrosionsbeskyttelse = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek070DatoForSenestUdførteSupplerendeIndvendigKorrosionsbeskyttelse = table.Column<DateTime>(nullable: true),
                    tek072Sløjfningsår = table.Column<int>(nullable: true),
                    tek073Navhøjde = table.Column<double>(nullable: true),
                    tek074Vindmøllenummer = table.Column<string>(type: "varchar(40)", nullable: true),
                    tek075Rotordiameter = table.Column<double>(nullable: true),
                    tek076KildeTilKoordinatsæt = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek077KvalitetAfKoordinatsæt = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek078SupplerendeOplysningOmKoordinatsæt = table.Column<string>(type: "varchar(2)", nullable: true),
                    tek101Gyldighedsdato = table.Column<DateTime>(nullable: true),
                    tek102FabrikatVindmølle = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek103FabrikatOliefyr = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek104FabrikatSolcelleanlægSolvarme = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek105OverdækningTank = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek106InspektionsdatoTank = table.Column<DateTime>(nullable: true),
                    tek107PlaceringPåSøterritorie = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek109Koordinat = table.Column<SqlGeometry>(nullable: true),
                    tek110Driftstatus = table.Column<string>(type: "varchar(1)", nullable: true),
                    tek111DatoForSenesteInspektion = table.Column<DateTime>(nullable: true),
                    tek112InspicerendeVirksomhed = table.Column<string>(type: "varchar(200)", nullable: true),
                    tek500Notatlinjer = table.Column<string>(type: "varchar(max)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bbr_tekniskanlæg_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "brofasthed",
                columns: table => new
                {
                    stedid = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    brofast = table.Column<bool>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brofasthed", x => x.stedid);
                });

            migrationBuilder.CreateTable(
                name: "bygning",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(10)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    bygningstype = table.Column<string>(type: "varchar(40)", nullable: false),
                    metode3d = table.Column<string>(type: "varchar(20)", nullable: false),
                    målested = table.Column<string>(type: "varchar(20)", nullable: false),
                    bbrbygning_id = table.Column<Guid>(nullable: true),
                    synlig = table.Column<bool>(nullable: false),
                    overlap = table.Column<bool>(nullable: false),
                    geometri = table.Column<SqlGeometry>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bygning", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bygningtilknytning",
                columns: table => new
                {
                    bygningid = table.Column<int>(nullable: false),
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bygningtilknytning", x => new { x.bygningid, x.adgangsadresseid });
                });

            migrationBuilder.CreateTable(
                name: "dagi__afstemningsomraader",
                columns: table => new
                {
                    dagi_id = table.Column<string>(type: "varchar(10)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    nummer = table.Column<string>(type: "varchar(4)", nullable: false),
                    navn = table.Column<string>(type: "varchar(100)", nullable: false),
                    afstemningsstednavn = table.Column<string>(type: "varchar(100)", nullable: false),
                    afstemningsstedadresseid = table.Column<string>(type: "varchar(36)", nullable: false),
                    afstemningsstedadressebetegnelse = table.Column<string>(type: "varchar(100)", nullable: false),
                    afstemningssted_adgangspunkt_x = table.Column<double>(nullable: false),
                    afstemningssted_adgangspunkt_y = table.Column<double>(nullable: false),
                    afstemningssted_adgangspunkt = table.Column<SqlGeometry>(nullable: false),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    kommunenavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    regionskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    regionsnavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    opstillingskredsnummer = table.Column<string>(type: "varchar(4)", nullable: false),
                    opstillingskredsnavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    storkredsnummer = table.Column<string>(type: "varchar(4)", nullable: false),
                    storkredsnavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    valglandsdelsbogstav = table.Column<string>(type: "varchar(1)", nullable: false),
                    valglandsdelsnavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__afstemningsomraader", x => x.dagi_id);
                });

            migrationBuilder.CreateTable(
                name: "dagi__kommuner",
                columns: table => new
                {
                    dagi_id = table.Column<string>(type: "varchar(10)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    regionskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    udenforkommuneinddeling = table.Column<bool>(nullable: false),
                    regionsnavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__kommuner", x => x.dagi_id);
                });

            migrationBuilder.CreateTable(
                name: "dagi__landsdele",
                columns: table => new
                {
                    dagi_id = table.Column<string>(type: "varchar(10)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    navn = table.Column<string>(type: "varchar(100)", nullable: false),
                    nuts3 = table.Column<string>(type: "varchar(5)", nullable: false),
                    regionskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    regionsnavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__landsdele", x => x.dagi_id);
                });

            migrationBuilder.CreateTable(
                name: "dagi__menighedsraadsafstemningsomraader",
                columns: table => new
                {
                    dagi_id = table.Column<string>(type: "varchar(10)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    nummer = table.Column<string>(type: "varchar(10)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    kommunenavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    sognekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    sognenavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__menighedsraadsafstemningsomraader", x => x.dagi_id);
                });

            migrationBuilder.CreateTable(
                name: "dagi__opstillingskredse",
                columns: table => new
                {
                    dagi_id = table.Column<string>(type: "varchar(10)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    nummer = table.Column<string>(type: "varchar(10)", nullable: false),
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    regionskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    regionsnavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    kredskommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    kredskommunenavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    storkredsnummer = table.Column<string>(type: "varchar(10)", nullable: false),
                    storkredsnavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    valglandsdelsbogstav = table.Column<string>(type: "varchar(1)", nullable: false),
                    valglandsdelsnavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__opstillingskredse", x => x.dagi_id);
                });

            migrationBuilder.CreateTable(
                name: "dagi__politikredse",
                columns: table => new
                {
                    dagi_id = table.Column<string>(type: "varchar(10)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__politikredse", x => x.dagi_id);
                });

            migrationBuilder.CreateTable(
                name: "dagi__postnumre",
                columns: table => new
                {
                    nr = table.Column<string>(type: "varchar(4)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    navn = table.Column<string>(type: "varchar(20)", nullable: false),
                    stormodtager = table.Column<bool>(nullable: false),
                    dagi_id = table.Column<int>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__postnumre", x => x.nr);
                });

            migrationBuilder.CreateTable(
                name: "dagi__regioner",
                columns: table => new
                {
                    dagi_id = table.Column<string>(type: "varchar(10)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__regioner", x => x.dagi_id);
                });

            migrationBuilder.CreateTable(
                name: "dagi__retskredse",
                columns: table => new
                {
                    dagi_id = table.Column<string>(type: "varchar(10)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__retskredse", x => x.dagi_id);
                });

            migrationBuilder.CreateTable(
                name: "dagi__sogne",
                columns: table => new
                {
                    dagi_id = table.Column<string>(type: "varchar(10)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__sogne", x => x.dagi_id);
                });

            migrationBuilder.CreateTable(
                name: "dagi__steder",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    hovedtype = table.Column<string>(type: "varchar(50)", nullable: false),
                    undertype = table.Column<string>(type: "varchar(50)", nullable: false),
                    indbyggerantal = table.Column<int>(nullable: true),
                    bebyggelseskode = table.Column<string>(type: "varchar(50)", nullable: true),
                    primærtnavn = table.Column<string>(type: "varchar(100)", nullable: true),
                    primærnavnestatus = table.Column<string>(type: "varchar(20)", nullable: true),
                    brofast = table.Column<bool>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__steder", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dagi__stednavne",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    hovedtype = table.Column<string>(type: "varchar(50)", nullable: false),
                    undertype = table.Column<string>(type: "varchar(50)", nullable: false),
                    navn = table.Column<string>(type: "varchar(100)", nullable: false),
                    navnestatus = table.Column<string>(type: "varchar(20)", nullable: true),
                    bebyggelseskode = table.Column<string>(type: "varchar(50)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__stednavne", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dagi__storkredse",
                columns: table => new
                {
                    nummer = table.Column<string>(type: "varchar(10)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    regionskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    regionsnavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    valglandsdelsbogstav = table.Column<string>(type: "varchar(1)", nullable: false),
                    valglandsdelsnavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__storkredse", x => x.nummer);
                });

            migrationBuilder.CreateTable(
                name: "dagi__supplerendebynavne2",
                columns: table => new
                {
                    dagi_id = table.Column<string>(type: "varchar(10)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    kommunenavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__supplerendebynavne2", x => x.dagi_id);
                });

            migrationBuilder.CreateTable(
                name: "dagi__valglandsdele",
                columns: table => new
                {
                    bogstav = table.Column<string>(type: "varchar(1)", nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter_x = table.Column<double>(nullable: false),
                    visueltcenter_y = table.Column<double>(nullable: false),
                    geometry = table.Column<SqlGeometry>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi__valglandsdele", x => x.bogstav);
                });

            migrationBuilder.CreateTable(
                name: "dagi_postnummer",
                columns: table => new
                {
                    nr = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    dagi_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    navn = table.Column<string>(type: "varchar(20)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dagi_postnummer", x => x.nr);
                });

            migrationBuilder.CreateTable(
                name: "dar_adresse_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    dørbetegnelse = table.Column<string>(type: "varchar(6)", nullable: true),
                    dørpunkt_id = table.Column<Guid>(nullable: true),
                    etagebetegnelse = table.Column<string>(type: "varchar(3)", nullable: true),
                    fk_bbr_bygning_bygning = table.Column<Guid>(nullable: true),
                    husnummer_id = table.Column<Guid>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_adresse_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_adresse_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    dørbetegnelse = table.Column<string>(type: "varchar(6)", nullable: true),
                    dørpunkt_id = table.Column<Guid>(nullable: true),
                    etagebetegnelse = table.Column<string>(type: "varchar(3)", nullable: true),
                    fk_bbr_bygning_bygning = table.Column<Guid>(nullable: true),
                    husnummer_id = table.Column<Guid>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_adresse_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_adressepunkt_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    oprindelse_kilde = table.Column<string>(type: "varchar(40)", nullable: true),
                    oprindelse_nøjagtighedsklasse = table.Column<string>(type: "varchar(1)", nullable: true),
                    oprindelse_registrering = table.Column<DateTime>(nullable: false),
                    oprindelse_tekniskstandard = table.Column<string>(type: "varchar(40)", nullable: true),
                    position = table.Column<SqlGeometry>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_adressepunkt_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_adressepunkt_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    oprindelse_kilde = table.Column<string>(type: "varchar(40)", nullable: true),
                    oprindelse_nøjagtighedsklasse = table.Column<string>(type: "varchar(1)", nullable: true),
                    oprindelse_registrering = table.Column<DateTime>(nullable: false),
                    oprindelse_tekniskstandard = table.Column<string>(type: "varchar(40)", nullable: true),
                    position = table.Column<SqlGeometry>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_adressepunkt_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_darafstemningsområde_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    afstemningsområde = table.Column<string>(type: "varchar(200)", nullable: true),
                    afstemningsområdenummer = table.Column<int>(nullable: true),
                    navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_darafstemningsområde_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_darafstemningsområde_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    afstemningsområde = table.Column<string>(type: "varchar(200)", nullable: true),
                    afstemningsområdenummer = table.Column<int>(nullable: true),
                    navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_darafstemningsområde_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_darkommuneinddeling_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    kommuneinddeling = table.Column<string>(type: "varchar(200)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_darkommuneinddeling_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_darkommuneinddeling_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    kommuneinddeling = table.Column<string>(type: "varchar(200)", nullable: true),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_darkommuneinddeling_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_darmenighedsrådsafstemningsområde_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    mrafstemningsområde = table.Column<string>(type: "varchar(200)", nullable: true),
                    mrafstemningsområdenummer = table.Column<int>(nullable: true),
                    navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_darmenighedsrådsafstemningsområde_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_darmenighedsrådsafstemningsområde_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    mrafstemningsområde = table.Column<string>(type: "varchar(200)", nullable: true),
                    mrafstemningsområdenummer = table.Column<int>(nullable: true),
                    navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_darmenighedsrådsafstemningsområde_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_darsogneinddeling_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    sogneinddeling = table.Column<string>(type: "varchar(200)", nullable: true),
                    sognekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_darsogneinddeling_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_darsogneinddeling_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    sogneinddeling = table.Column<string>(type: "varchar(200)", nullable: true),
                    sognekode = table.Column<string>(type: "varchar(4)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_darsogneinddeling_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_husnummer_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    adgangspunkt_id = table.Column<Guid>(nullable: false),
                    darafstemningsområde_id = table.Column<Guid>(nullable: false),
                    darkommune_id = table.Column<Guid>(nullable: false),
                    darmenighedsrådsafstemningsområde_id = table.Column<Guid>(nullable: true),
                    darsogneinddeling_id = table.Column<Guid>(nullable: false),
                    fk_bbr_bygning_adgangtilbygning = table.Column<string>(type: "varchar(36)", nullable: true),
                    fk_bbr_tekniskanlæg_adgangtiltekniskanlæg = table.Column<string>(type: "varchar(36)", nullable: true),
                    fk_geodk_bygning_geodanmarkbygning = table.Column<string>(type: "varchar(200)", nullable: true),
                    fk_geodk_vejmidte_vejmidte = table.Column<string>(type: "varchar(200)", nullable: true),
                    fk_mu_jordstykke_foreløbigtplaceretpåjordstykke = table.Column<string>(type: "varchar(200)", nullable: true),
                    fk_mu_jordstykke_jordstykke = table.Column<string>(type: "varchar(200)", nullable: true),
                    husnummerretning = table.Column<SqlGeometry>(nullable: true),
                    husnummertekst = table.Column<string>(type: "varchar(200)", nullable: true),
                    navngivenvej_id = table.Column<Guid>(nullable: true),
                    postnummer_id = table.Column<Guid>(nullable: false),
                    supplerendebynavn_id = table.Column<Guid>(nullable: true),
                    vejpunkt_id = table.Column<Guid>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_husnummer_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_husnummer_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    adgangspunkt_id = table.Column<Guid>(nullable: false),
                    darafstemningsområde_id = table.Column<Guid>(nullable: false),
                    darkommune_id = table.Column<Guid>(nullable: false),
                    darmenighedsrådsafstemningsområde_id = table.Column<Guid>(nullable: true),
                    darsogneinddeling_id = table.Column<Guid>(nullable: false),
                    fk_bbr_bygning_adgangtilbygning = table.Column<string>(type: "varchar(36)", nullable: true),
                    fk_bbr_tekniskanlæg_adgangtiltekniskanlæg = table.Column<string>(type: "varchar(36)", nullable: true),
                    fk_geodk_bygning_geodanmarkbygning = table.Column<string>(type: "varchar(200)", nullable: true),
                    fk_geodk_vejmidte_vejmidte = table.Column<string>(type: "varchar(200)", nullable: true),
                    fk_mu_jordstykke_foreløbigtplaceretpåjordstykke = table.Column<string>(type: "varchar(200)", nullable: true),
                    fk_mu_jordstykke_jordstykke = table.Column<string>(type: "varchar(200)", nullable: true),
                    husnummerretning = table.Column<SqlGeometry>(nullable: true),
                    husnummertekst = table.Column<string>(type: "varchar(200)", nullable: true),
                    navngivenvej_id = table.Column<Guid>(nullable: true),
                    postnummer_id = table.Column<Guid>(nullable: false),
                    supplerendebynavn_id = table.Column<Guid>(nullable: true),
                    vejpunkt_id = table.Column<Guid>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_husnummer_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_navngivenvej_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    administreresafkommune = table.Column<string>(type: "varchar(4)", nullable: true),
                    beskrivelse = table.Column<string>(type: "varchar(1000)", nullable: true),
                    retskrivningskontrol = table.Column<string>(type: "varchar(40)", nullable: true),
                    udtaltvejnavn = table.Column<string>(type: "varchar(80)", nullable: true),
                    vejadresseringsnavn = table.Column<string>(type: "varchar(20)", nullable: true),
                    vejnavn = table.Column<string>(type: "varchar(40)", nullable: true),
                    vejnavnebeliggenhed_oprindelse_kilde = table.Column<string>(type: "varchar(20)", nullable: true),
                    vejnavnebeliggenhed_oprindelse_nøjagtighedsklasse = table.Column<string>(type: "varchar(1)", nullable: true),
                    vejnavnebeliggenhed_oprindelse_registrering = table.Column<DateTime>(nullable: false),
                    vejnavnebeliggenhed_oprindelse_tekniskstandard = table.Column<string>(type: "varchar(20)", nullable: true),
                    vejnavnebeliggenhed_vejnavnelinje = table.Column<SqlGeometry>(nullable: true),
                    vejnavnebeliggenhed_vejnavneområde = table.Column<SqlGeometry>(nullable: true),
                    vejnavnebeliggenhed_vejtilslutningspunkter = table.Column<SqlGeometry>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_navngivenvej_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_navngivenvej_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    administreresafkommune = table.Column<string>(type: "varchar(4)", nullable: true),
                    beskrivelse = table.Column<string>(type: "varchar(1000)", nullable: true),
                    retskrivningskontrol = table.Column<string>(type: "varchar(40)", nullable: true),
                    udtaltvejnavn = table.Column<string>(type: "varchar(80)", nullable: true),
                    vejadresseringsnavn = table.Column<string>(type: "varchar(20)", nullable: true),
                    vejnavn = table.Column<string>(type: "varchar(40)", nullable: true),
                    vejnavnebeliggenhed_oprindelse_kilde = table.Column<string>(type: "varchar(20)", nullable: true),
                    vejnavnebeliggenhed_oprindelse_nøjagtighedsklasse = table.Column<string>(type: "varchar(1)", nullable: true),
                    vejnavnebeliggenhed_oprindelse_registrering = table.Column<DateTime>(nullable: false),
                    vejnavnebeliggenhed_oprindelse_tekniskstandard = table.Column<string>(type: "varchar(20)", nullable: true),
                    vejnavnebeliggenhed_vejnavnelinje = table.Column<SqlGeometry>(nullable: true),
                    vejnavnebeliggenhed_vejnavneområde = table.Column<SqlGeometry>(nullable: true),
                    vejnavnebeliggenhed_vejtilslutningspunkter = table.Column<SqlGeometry>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_navngivenvej_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_navngivenvejkommunedel_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    kommune = table.Column<string>(type: "varchar(4)", nullable: true),
                    navngivenvej_id = table.Column<Guid>(nullable: false),
                    vejkode = table.Column<string>(type: "varchar(200)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_navngivenvejkommunedel_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_navngivenvejkommunedel_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    kommune = table.Column<string>(type: "varchar(4)", nullable: true),
                    navngivenvej_id = table.Column<Guid>(nullable: false),
                    vejkode = table.Column<string>(type: "varchar(200)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_navngivenvejkommunedel_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_navngivenvejpostnummerrelation_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    navngivenvej_id = table.Column<Guid>(nullable: false),
                    postnummer_id = table.Column<Guid>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_navngivenvejpostnummerrelation_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_navngivenvejpostnummerrelation_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    navngivenvej_id = table.Column<Guid>(nullable: false),
                    postnummer_id = table.Column<Guid>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_navngivenvejpostnummerrelation_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_navngivenvejsupplerendebynavnrelation_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    navngivenvej_id = table.Column<Guid>(nullable: false),
                    supplerendebynavn_id = table.Column<Guid>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_navngivenvejsupplerendebynavnrelation_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_navngivenvejsupplerendebynavnrelation_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    navngivenvej_id = table.Column<Guid>(nullable: false),
                    supplerendebynavn_id = table.Column<Guid>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_navngivenvejsupplerendebynavnrelation_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_postnummer_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    navn = table.Column<string>(type: "varchar(20)", nullable: true),
                    postnr = table.Column<int>(nullable: true),
                    postnummerinddeling = table.Column<int>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_postnummer_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_postnummer_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    navn = table.Column<string>(type: "varchar(20)", nullable: true),
                    postnr = table.Column<int>(nullable: true),
                    postnummerinddeling = table.Column<int>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_postnummer_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_reserveretvejnavn_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    navneområde = table.Column<string>(type: "varchar(2000)", nullable: true),
                    reservationudløbsdato = table.Column<DateTime>(nullable: false),
                    reserveretafkommune = table.Column<string>(type: "varchar(4)", nullable: true),
                    reserveretnavn = table.Column<string>(type: "varchar(200)", nullable: true),
                    reserveretudtaltnavn = table.Column<string>(type: "varchar(200)", nullable: true),
                    reserveretvejadresseringsnavn = table.Column<string>(type: "varchar(200)", nullable: true),
                    retskrivningskontrol = table.Column<string>(type: "varchar(200)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_reserveretvejnavn_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_reserveretvejnavn_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    navneområde = table.Column<string>(type: "varchar(2000)", nullable: true),
                    reservationudløbsdato = table.Column<DateTime>(nullable: false),
                    reserveretafkommune = table.Column<string>(type: "varchar(4)", nullable: true),
                    reserveretnavn = table.Column<string>(type: "varchar(200)", nullable: true),
                    reserveretudtaltnavn = table.Column<string>(type: "varchar(200)", nullable: true),
                    reserveretvejadresseringsnavn = table.Column<string>(type: "varchar(200)", nullable: true),
                    retskrivningskontrol = table.Column<string>(type: "varchar(200)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_reserveretvejnavn_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "dar_supplerendebynavn_aktuel",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    supplerendebynavn1 = table.Column<string>(type: "varchar(200)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_supplerendebynavn_aktuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dar_supplerendebynavn_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    navn = table.Column<string>(type: "varchar(200)", nullable: true),
                    supplerendebynavn1 = table.Column<string>(type: "varchar(200)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dar_supplerendebynavn_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "ejerlav",
                columns: table => new
                {
                    kode = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ejerlav", x => x.kode);
                });

            migrationBuilder.CreateTable(
                name: "entitystate",
                columns: table => new
                {
                    entity = table.Column<string>(type: "varchar(200)", nullable: false),
                    txid = table.Column<long>(nullable: true),
                    success = table.Column<bool>(nullable: true),
                    successtime = table.Column<DateTime>(nullable: true),
                    successtimeChange = table.Column<DateTime>(nullable: true),
                    starttime = table.Column<DateTime>(nullable: true),
                    finishtime = table.Column<DateTime>(nullable: true),
                    count = table.Column<int>(nullable: true),
                    message = table.Column<string>(type: "varchar(max)", nullable: true),
                    monitoringIgnoreError = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entitystate", x => x.entity);
                });

            migrationBuilder.CreateTable(
                name: "entitystatehistory",
                columns: table => new
                {
                    entity = table.Column<string>(type: "varchar(200)", nullable: false),
                    starttime = table.Column<DateTime>(nullable: false),
                    txidFra = table.Column<long>(nullable: true),
                    txidTil = table.Column<long>(nullable: true),
                    success = table.Column<bool>(nullable: true),
                    finishtime = table.Column<DateTime>(nullable: true),
                    insertupdatecount = table.Column<int>(nullable: true),
                    deletecount = table.Column<int>(nullable: true),
                    message = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entitystatehistory", x => new { x.entity, x.starttime });
                });

            migrationBuilder.CreateTable(
                name: "højde",
                columns: table => new
                {
                    husnummerid = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    højde = table.Column<double>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_højde", x => x.husnummerid);
                });

            migrationBuilder.CreateTable(
                name: "ikke_brofast_husnummer",
                columns: table => new
                {
                    husnummerid = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ikke_brofast_husnummer", x => x.husnummerid);
                });

            migrationBuilder.CreateTable(
                name: "jordstykke",
                columns: table => new
                {
                    ejerlavkode = table.Column<int>(nullable: false),
                    matrikelnr = table.Column<string>(type: "varchar(10)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    regionskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    sognekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    retskredskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    esrejendomsnr = table.Column<string>(type: "varchar(7)", nullable: true),
                    udvidet_esrejendomsnr = table.Column<string>(type: "varchar(10)", nullable: true),
                    sfeejendomsnr = table.Column<string>(type: "varchar(20)", nullable: true),
                    bfenummer = table.Column<int>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: false),
                    featureid = table.Column<string>(type: "varchar(20)", nullable: false),
                    fælleslod = table.Column<bool>(nullable: false),
                    moderjordstykke = table.Column<int>(nullable: true),
                    registreretareal = table.Column<int>(nullable: false),
                    arealberegningsmetode = table.Column<string>(type: "varchar(1)", nullable: false),
                    vejareal = table.Column<int>(nullable: false),
                    vejarealberegningsmetode = table.Column<string>(type: "varchar(1)", nullable: false),
                    vandarealberegningsmetode = table.Column<string>(type: "varchar(6)", nullable: false),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jordstykke", x => new { x.ejerlavkode, x.matrikelnr });
                });

            migrationBuilder.CreateTable(
                name: "jordstykketilknytning",
                columns: table => new
                {
                    ejerlavkode = table.Column<int>(nullable: false),
                    matrikelnr = table.Column<string>(type: "varchar(10)", nullable: false),
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jordstykketilknytning", x => new { x.ejerlavkode, x.matrikelnr, x.adgangsadresseid });
                });

            migrationBuilder.CreateTable(
                name: "kommune",
                columns: table => new
                {
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    dagi_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    regionskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    udenforkommuneinddeling = table.Column<bool>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kommune", x => x.kode);
                });

            migrationBuilder.CreateTable(
                name: "kommunetilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kommunetilknytning", x => new { x.adgangsadresseid, x.kommunekode });
                });

            migrationBuilder.CreateTable(
                name: "landpostnummer",
                columns: table => new
                {
                    nr = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    navn = table.Column<string>(type: "varchar(20)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_landpostnummer", x => x.nr);
                });

            migrationBuilder.CreateTable(
                name: "menighedsrådsafstemningsområde",
                columns: table => new
                {
                    nummer = table.Column<string>(type: "varchar(10)", nullable: false),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    dagi_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    afstemningsstednavn = table.Column<string>(type: "varchar(50)", nullable: false),
                    sognekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menighedsrådsafstemningsområde", x => new { x.kommunekode, x.nummer });
                });

            migrationBuilder.CreateTable(
                name: "menighedsrådsafstemningsområdetilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    menighedsrådsafstemningsområdenummer = table.Column<string>(type: "varchar(2)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menighedsrådsafstemningsområdetilknytning", x => new { x.adgangsadresseid, x.kommunekode, x.menighedsrådsafstemningsområdenummer });
                });

            migrationBuilder.CreateTable(
                name: "navngivenvej",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    darstatus = table.Column<string>(type: "varchar(9)", nullable: false),
                    oprettet = table.Column<DateTime>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    navn = table.Column<string>(type: "varchar(40)", nullable: false),
                    adresseringsnavn = table.Column<string>(type: "varchar(20)", nullable: true),
                    administrerendekommune = table.Column<string>(type: "varchar(4)", nullable: true),
                    beskrivelse = table.Column<string>(type: "varchar(1000)", nullable: true),
                    retskrivningskontrol = table.Column<string>(type: "varchar(40)", nullable: true),
                    udtaltvejnavn = table.Column<string>(type: "varchar(80)", nullable: true),
                    beliggenhed_oprindelse_kilde = table.Column<string>(type: "varchar(20)", nullable: true),
                    beliggenhed_oprindelse_nøjagtighedsklasse = table.Column<string>(type: "varchar(1)", nullable: true),
                    beliggenhed_oprindelse_registrering = table.Column<DateTime>(nullable: true),
                    beliggenhed_oprindelse_tekniskstandard = table.Column<string>(type: "varchar(20)", nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_navngivenvej", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "opstillingskreds",
                columns: table => new
                {
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    dagi_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    nummer = table.Column<string>(type: "varchar(40)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    valgkredsnummer = table.Column<string>(type: "varchar(10)", nullable: false),
                    storkredsnummer = table.Column<string>(type: "varchar(10)", nullable: false),
                    kredskommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opstillingskreds", x => x.kode);
                });

            migrationBuilder.CreateTable(
                name: "opstillingskredstilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    opstillingskredskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opstillingskredstilknytning", x => new { x.adgangsadresseid, x.opstillingskredskode });
                });

            migrationBuilder.CreateTable(
                name: "politikreds",
                columns: table => new
                {
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    dagi_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_politikreds", x => x.kode);
                });

            migrationBuilder.CreateTable(
                name: "politikredstilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    politikredskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_politikredstilknytning", x => new { x.adgangsadresseid, x.politikredskode });
                });

            migrationBuilder.CreateTable(
                name: "postnummer",
                columns: table => new
                {
                    nr = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    navn = table.Column<string>(type: "varchar(20)", nullable: false),
                    stormodtager = table.Column<bool>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postnummer", x => x.nr);
                });

            migrationBuilder.CreateTable(
                name: "postnummertilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    postnummer = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postnummertilknytning", x => new { x.adgangsadresseid, x.postnummer });
                });

            migrationBuilder.CreateTable(
                name: "region",
                columns: table => new
                {
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    dagi_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    nuts2 = table.Column<string>(type: "varchar(5)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_region", x => x.kode);
                });

            migrationBuilder.CreateTable(
                name: "regionstilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    regionskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regionstilknytning", x => new { x.adgangsadresseid, x.regionskode });
                });

            migrationBuilder.CreateTable(
                name: "retskreds",
                columns: table => new
                {
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    dagi_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retskreds", x => x.kode);
                });

            migrationBuilder.CreateTable(
                name: "retskredstilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    retskredskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retskredstilknytning", x => new { x.adgangsadresseid, x.retskredskode });
                });

            migrationBuilder.CreateTable(
                name: "sogn",
                columns: table => new
                {
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    dagi_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sogn", x => x.kode);
                });

            migrationBuilder.CreateTable(
                name: "sognetilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    sognekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sognetilknytning", x => new { x.adgangsadresseid, x.sognekode });
                });

            migrationBuilder.CreateTable(
                name: "sted",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    hovedtype = table.Column<string>(type: "varchar(50)", nullable: false),
                    undertype = table.Column<string>(type: "varchar(50)", nullable: false),
                    bebyggelseskode = table.Column<int>(nullable: true),
                    indbyggerantal = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: false),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sted", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stednavn",
                columns: table => new
                {
                    stedid = table.Column<Guid>(nullable: false),
                    navn = table.Column<string>(type: "varchar(100)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    navnestatus = table.Column<string>(type: "varchar(50)", nullable: false),
                    brugsprioritet = table.Column<string>(type: "varchar(20)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stednavn", x => new { x.stedid, x.navn });
                });

            migrationBuilder.CreateTable(
                name: "stednavntilknytning",
                columns: table => new
                {
                    stednavn_id = table.Column<Guid>(nullable: false),
                    adgangsadresse_id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stednavntilknytning", x => new { x.stednavn_id, x.adgangsadresse_id });
                });

            migrationBuilder.CreateTable(
                name: "stedtilknytning",
                columns: table => new
                {
                    stedid = table.Column<Guid>(nullable: false),
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stedtilknytning", x => new { x.stedid, x.adgangsadresseid });
                });

            migrationBuilder.CreateTable(
                name: "storkreds",
                columns: table => new
                {
                    nummer = table.Column<string>(type: "varchar(10)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    regionskode = table.Column<string>(type: "varchar(4)", nullable: false),
                    valglandsdelsbogstav = table.Column<string>(type: "varchar(1)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storkreds", x => x.nummer);
                });

            migrationBuilder.CreateTable(
                name: "storkredstilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    storkredsnummer = table.Column<string>(type: "varchar(2)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storkredstilknytning", x => new { x.adgangsadresseid, x.storkredsnummer });
                });

            migrationBuilder.CreateTable(
                name: "supplerendebynavn",
                columns: table => new
                {
                    dagi_id = table.Column<string>(type: "varchar(36)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplerendebynavn", x => x.dagi_id);
                });

            migrationBuilder.CreateTable(
                name: "supplerendebynavntilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    dagi_id = table.Column<string>(type: "varchar(7)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplerendebynavntilknytning", x => new { x.adgangsadresseid, x.dagi_id });
                });

            migrationBuilder.CreateTable(
                name: "valglandsdel",
                columns: table => new
                {
                    bogstav = table.Column<string>(type: "varchar(1)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    navn = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valglandsdel", x => x.bogstav);
                });

            migrationBuilder.CreateTable(
                name: "valglandsdelstilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    valglandsdelsbogstav = table.Column<string>(type: "varchar(1)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valglandsdelstilknytning", x => new { x.adgangsadresseid, x.valglandsdelsbogstav });
                });

            migrationBuilder.CreateTable(
                name: "vask_adresse_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    husnummerid = table.Column<Guid>(nullable: false),
                    etage = table.Column<string>(type: "varchar(3)", nullable: true),
                    dør = table.Column<string>(type: "varchar(6)", nullable: true),
                    id = table.Column<Guid>(nullable: false),
                    adgangspunkt_status = table.Column<int>(nullable: true),
                    husnummer_status = table.Column<int>(nullable: false),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    vejkode = table.Column<string>(type: "varchar(4)", nullable: false),
                    vejnavn = table.Column<string>(type: "varchar(40)", nullable: false),
                    adresseringsvejnavn = table.Column<string>(type: "varchar(20)", nullable: false),
                    husnr = table.Column<string>(type: "varchar(4)", nullable: false),
                    supplerendebynavn = table.Column<string>(type: "varchar(50)", nullable: true),
                    postnr = table.Column<string>(type: "varchar(4)", nullable: false),
                    postnrnavn = table.Column<string>(type: "varchar(20)", nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vask_adresse_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "vask_husnummer_historik",
                columns: table => new
                {
                    rowkey = table.Column<int>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    id = table.Column<Guid>(nullable: false),
                    adgangspunkt_status = table.Column<int>(nullable: true),
                    husnummer_status = table.Column<int>(nullable: false),
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    vejkode = table.Column<string>(type: "varchar(4)", nullable: false),
                    vejnavn = table.Column<string>(type: "varchar(40)", nullable: false),
                    adresseringsvejnavn = table.Column<string>(type: "varchar(20)", nullable: false),
                    husnr = table.Column<string>(type: "varchar(4)", nullable: false),
                    supplerendebynavn = table.Column<string>(type: "varchar(50)", nullable: true),
                    postnr = table.Column<string>(type: "varchar(4)", nullable: false),
                    postnrnavn = table.Column<string>(type: "varchar(20)", nullable: false),
                    virkningstart = table.Column<DateTime>(nullable: false),
                    virkningslut = table.Column<DateTime>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vask_husnummer_historik", x => x.rowkey);
                });

            migrationBuilder.CreateTable(
                name: "vejmidte",
                columns: table => new
                {
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    vejkode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    geometri = table.Column<SqlGeometry>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vejmidte", x => new { x.kommunekode, x.vejkode });
                });

            migrationBuilder.CreateTable(
                name: "vejpunkt",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    kilde = table.Column<string>(type: "varchar(10)", nullable: false),
                    tekniskstandard = table.Column<string>(type: "varchar(2)", nullable: false),
                    nøjagtighedsklasse = table.Column<string>(type: "varchar(1)", nullable: false),
                    position = table.Column<SqlGeometry>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vejpunkt", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vejstykke",
                columns: table => new
                {
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    kode = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    id = table.Column<string>(type: "varchar(38)", nullable: false),
                    oprettet = table.Column<DateTime>(nullable: true),
                    ændret = table.Column<DateTime>(nullable: true),
                    navn = table.Column<string>(type: "varchar(40)", nullable: true),
                    adresseringsnavn = table.Column<string>(type: "varchar(30)", nullable: true),
                    navngivenvej_id = table.Column<Guid>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vejstykke", x => new { x.kommunekode, x.kode });
                });

            migrationBuilder.CreateTable(
                name: "vejstykkepostnummerrelation",
                columns: table => new
                {
                    kommunekode = table.Column<string>(type: "varchar(4)", nullable: false),
                    vejkode = table.Column<string>(type: "varchar(4)", nullable: false),
                    postnr = table.Column<string>(type: "varchar(4)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vejstykkepostnummerrelation", x => new { x.kommunekode, x.vejkode, x.postnr });
                });

            migrationBuilder.CreateTable(
                name: "zone",
                columns: table => new
                {
                    zone = table.Column<string>(type: "varchar(50)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    ændret = table.Column<DateTime>(nullable: false),
                    geo_ændret = table.Column<DateTime>(nullable: false),
                    geo_version = table.Column<int>(nullable: true),
                    visueltcenter = table.Column<SqlGeometry>(nullable: true),
                    bbox = table.Column<SqlGeometry>(nullable: true),
                    geometri = table.Column<SqlGeometry>(nullable: true),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zone", x => x.zone);
                });

            migrationBuilder.CreateTable(
                name: "zonetilknytning",
                columns: table => new
                {
                    adgangsadresseid = table.Column<Guid>(nullable: false),
                    zone = table.Column<string>(type: "varchar(20)", nullable: false),
                    entity_txid = table.Column<long>(nullable: false),
                    entity_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zonetilknytning", x => new { x.adgangsadresseid, x.zone });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adgangsadresse");

            migrationBuilder.DropTable(
                name: "adresse");

            migrationBuilder.DropTable(
                name: "afstemningsområde");

            migrationBuilder.DropTable(
                name: "afstemningsområdetilknytning");

            migrationBuilder.DropTable(
                name: "bbr_bygning");

            migrationBuilder.DropTable(
                name: "bbr_bygning_aktuel");

            migrationBuilder.DropTable(
                name: "bbr_bygning_historik");

            migrationBuilder.DropTable(
                name: "bbr_bygningpåfremmedgrund");

            migrationBuilder.DropTable(
                name: "bbr_bygningpåfremmedgrund_aktuel");

            migrationBuilder.DropTable(
                name: "bbr_bygningpåfremmedgrund_historik");

            migrationBuilder.DropTable(
                name: "bbr_ejendomsrelation");

            migrationBuilder.DropTable(
                name: "bbr_ejendomsrelation_aktuel");

            migrationBuilder.DropTable(
                name: "bbr_ejendomsrelation_historik");

            migrationBuilder.DropTable(
                name: "bbr_enhed");

            migrationBuilder.DropTable(
                name: "bbr_enhed_aktuel");

            migrationBuilder.DropTable(
                name: "bbr_enhed_historik");

            migrationBuilder.DropTable(
                name: "bbr_enhedejerlejlighed");

            migrationBuilder.DropTable(
                name: "bbr_enhedejerlejlighed_aktuel");

            migrationBuilder.DropTable(
                name: "bbr_enhedejerlejlighed_historik");

            migrationBuilder.DropTable(
                name: "bbr_etage");

            migrationBuilder.DropTable(
                name: "bbr_etage_aktuel");

            migrationBuilder.DropTable(
                name: "bbr_etage_historik");

            migrationBuilder.DropTable(
                name: "bbr_fordelingaffordelingsareal");

            migrationBuilder.DropTable(
                name: "bbr_fordelingaffordelingsareal_aktuel");

            migrationBuilder.DropTable(
                name: "bbr_fordelingaffordelingsareal_historik");

            migrationBuilder.DropTable(
                name: "bbr_fordelingsareal");

            migrationBuilder.DropTable(
                name: "bbr_fordelingsareal_aktuel");

            migrationBuilder.DropTable(
                name: "bbr_fordelingsareal_historik");

            migrationBuilder.DropTable(
                name: "bbr_grund");

            migrationBuilder.DropTable(
                name: "bbr_grund_aktuel");

            migrationBuilder.DropTable(
                name: "bbr_grund_historik");

            migrationBuilder.DropTable(
                name: "bbr_grundjordstykke");

            migrationBuilder.DropTable(
                name: "bbr_grundjordstykke_aktuel");

            migrationBuilder.DropTable(
                name: "bbr_grundjordstykke_historik");

            migrationBuilder.DropTable(
                name: "bbr_opgang");

            migrationBuilder.DropTable(
                name: "bbr_opgang_aktuel");

            migrationBuilder.DropTable(
                name: "bbr_opgang_historik");

            migrationBuilder.DropTable(
                name: "bbr_tekniskanlæg");

            migrationBuilder.DropTable(
                name: "bbr_tekniskanlæg_aktuel");

            migrationBuilder.DropTable(
                name: "bbr_tekniskanlæg_historik");

            migrationBuilder.DropTable(
                name: "brofasthed");

            migrationBuilder.DropTable(
                name: "bygning");

            migrationBuilder.DropTable(
                name: "bygningtilknytning");

            migrationBuilder.DropTable(
                name: "dagi__afstemningsomraader");

            migrationBuilder.DropTable(
                name: "dagi__kommuner");

            migrationBuilder.DropTable(
                name: "dagi__landsdele");

            migrationBuilder.DropTable(
                name: "dagi__menighedsraadsafstemningsomraader");

            migrationBuilder.DropTable(
                name: "dagi__opstillingskredse");

            migrationBuilder.DropTable(
                name: "dagi__politikredse");

            migrationBuilder.DropTable(
                name: "dagi__postnumre");

            migrationBuilder.DropTable(
                name: "dagi__regioner");

            migrationBuilder.DropTable(
                name: "dagi__retskredse");

            migrationBuilder.DropTable(
                name: "dagi__sogne");

            migrationBuilder.DropTable(
                name: "dagi__steder");

            migrationBuilder.DropTable(
                name: "dagi__stednavne");

            migrationBuilder.DropTable(
                name: "dagi__storkredse");

            migrationBuilder.DropTable(
                name: "dagi__supplerendebynavne2");

            migrationBuilder.DropTable(
                name: "dagi__valglandsdele");

            migrationBuilder.DropTable(
                name: "dagi_postnummer");

            migrationBuilder.DropTable(
                name: "dar_adresse_aktuel");

            migrationBuilder.DropTable(
                name: "dar_adresse_historik");

            migrationBuilder.DropTable(
                name: "dar_adressepunkt_aktuel");

            migrationBuilder.DropTable(
                name: "dar_adressepunkt_historik");

            migrationBuilder.DropTable(
                name: "dar_darafstemningsområde_aktuel");

            migrationBuilder.DropTable(
                name: "dar_darafstemningsområde_historik");

            migrationBuilder.DropTable(
                name: "dar_darkommuneinddeling_aktuel");

            migrationBuilder.DropTable(
                name: "dar_darkommuneinddeling_historik");

            migrationBuilder.DropTable(
                name: "dar_darmenighedsrådsafstemningsområde_aktuel");

            migrationBuilder.DropTable(
                name: "dar_darmenighedsrådsafstemningsområde_historik");

            migrationBuilder.DropTable(
                name: "dar_darsogneinddeling_aktuel");

            migrationBuilder.DropTable(
                name: "dar_darsogneinddeling_historik");

            migrationBuilder.DropTable(
                name: "dar_husnummer_aktuel");

            migrationBuilder.DropTable(
                name: "dar_husnummer_historik");

            migrationBuilder.DropTable(
                name: "dar_navngivenvej_aktuel");

            migrationBuilder.DropTable(
                name: "dar_navngivenvej_historik");

            migrationBuilder.DropTable(
                name: "dar_navngivenvejkommunedel_aktuel");

            migrationBuilder.DropTable(
                name: "dar_navngivenvejkommunedel_historik");

            migrationBuilder.DropTable(
                name: "dar_navngivenvejpostnummerrelation_aktuel");

            migrationBuilder.DropTable(
                name: "dar_navngivenvejpostnummerrelation_historik");

            migrationBuilder.DropTable(
                name: "dar_navngivenvejsupplerendebynavnrelation_aktuel");

            migrationBuilder.DropTable(
                name: "dar_navngivenvejsupplerendebynavnrelation_historik");

            migrationBuilder.DropTable(
                name: "dar_postnummer_aktuel");

            migrationBuilder.DropTable(
                name: "dar_postnummer_historik");

            migrationBuilder.DropTable(
                name: "dar_reserveretvejnavn_aktuel");

            migrationBuilder.DropTable(
                name: "dar_reserveretvejnavn_historik");

            migrationBuilder.DropTable(
                name: "dar_supplerendebynavn_aktuel");

            migrationBuilder.DropTable(
                name: "dar_supplerendebynavn_historik");

            migrationBuilder.DropTable(
                name: "ejerlav");

            migrationBuilder.DropTable(
                name: "entitystate");

            migrationBuilder.DropTable(
                name: "entitystatehistory");

            migrationBuilder.DropTable(
                name: "højde");

            migrationBuilder.DropTable(
                name: "ikke_brofast_husnummer");

            migrationBuilder.DropTable(
                name: "jordstykke");

            migrationBuilder.DropTable(
                name: "jordstykketilknytning");

            migrationBuilder.DropTable(
                name: "kommune");

            migrationBuilder.DropTable(
                name: "kommunetilknytning");

            migrationBuilder.DropTable(
                name: "landpostnummer");

            migrationBuilder.DropTable(
                name: "menighedsrådsafstemningsområde");

            migrationBuilder.DropTable(
                name: "menighedsrådsafstemningsområdetilknytning");

            migrationBuilder.DropTable(
                name: "navngivenvej");

            migrationBuilder.DropTable(
                name: "opstillingskreds");

            migrationBuilder.DropTable(
                name: "opstillingskredstilknytning");

            migrationBuilder.DropTable(
                name: "politikreds");

            migrationBuilder.DropTable(
                name: "politikredstilknytning");

            migrationBuilder.DropTable(
                name: "postnummer");

            migrationBuilder.DropTable(
                name: "postnummertilknytning");

            migrationBuilder.DropTable(
                name: "region");

            migrationBuilder.DropTable(
                name: "regionstilknytning");

            migrationBuilder.DropTable(
                name: "retskreds");

            migrationBuilder.DropTable(
                name: "retskredstilknytning");

            migrationBuilder.DropTable(
                name: "sogn");

            migrationBuilder.DropTable(
                name: "sognetilknytning");

            migrationBuilder.DropTable(
                name: "sted");

            migrationBuilder.DropTable(
                name: "stednavn");

            migrationBuilder.DropTable(
                name: "stednavntilknytning");

            migrationBuilder.DropTable(
                name: "stedtilknytning");

            migrationBuilder.DropTable(
                name: "storkreds");

            migrationBuilder.DropTable(
                name: "storkredstilknytning");

            migrationBuilder.DropTable(
                name: "supplerendebynavn");

            migrationBuilder.DropTable(
                name: "supplerendebynavntilknytning");

            migrationBuilder.DropTable(
                name: "valglandsdel");

            migrationBuilder.DropTable(
                name: "valglandsdelstilknytning");

            migrationBuilder.DropTable(
                name: "vask_adresse_historik");

            migrationBuilder.DropTable(
                name: "vask_husnummer_historik");

            migrationBuilder.DropTable(
                name: "vejmidte");

            migrationBuilder.DropTable(
                name: "vejpunkt");

            migrationBuilder.DropTable(
                name: "vejstykke");

            migrationBuilder.DropTable(
                name: "vejstykkepostnummerrelation");

            migrationBuilder.DropTable(
                name: "zone");

            migrationBuilder.DropTable(
                name: "zonetilknytning");
        }
    }
}
