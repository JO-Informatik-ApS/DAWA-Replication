IF OBJECT_ID('dbo.SetExtendedproperty', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SetExtendedproperty
GO

CREATE PROCEDURE dbo.SetExtendedproperty (
    @PropertyName varchar(128),
	@PropertyValue varchar(4000),
	@NameLevel1 varchar(128),
	@NameLevel2 varchar(128) = null,
	@Schema varchar(128) = 'dbo',
	@TypeLevel1 varchar(128) = 'TABLE',
	@TypeLevel2 varchar(128) = 'COLUMN'
)
AS
BEGIN

    SET NOCOUNT ON;

	if @NameLevel2 IS NULL SET @TypeLevel2 = NULL;

	IF EXISTS(SELECT* FROM ::fn_listextendedproperty (@PropertyName, 'SCHEMA', @Schema, @TypeLevel1, @NameLevel1, @TypeLevel2, @NameLevel2))
	BEGIN
        EXEC sp_updateextendedproperty
            @name = @PropertyName, @value = @PropertyValue,
            @level0type = 'SCHEMA', @level0name = @Schema,
            @level1type = @TypeLevel1, @level1name = @NameLevel1,
            @level2type = @TypeLevel2, @level2name = @NameLevel2

    END ELSE BEGIN
        EXEC sp_addextendedproperty
            @name = @PropertyName, @value = @PropertyValue,
            @level0type = 'SCHEMA', @level0name = @Schema,
            @level1type = @TypeLevel1, @level1name = @NameLevel1,
            @level2type = @TypeLevel2, @level2name = @NameLevel2

    END
END
GO


--EXEC SetExtendedproperty 'MS_Description', 'kolonne beskrivelse', 'tabelnavne'

EXEC SetExtendedproperty 'MS_Description', 'En adgangsadresse er en struktureret betegnelse som angiver en særskilt adgang til et areal eller en bygning efter reglerne i adressebekendtgørelsen. Forskellen på en adresse og en adgangsadresse er at adressen rummer eventuel etage- og/eller dørbetegnelse. Det gør adgangsadressen ikke.', 'adgangsadresse';
EXEC SetExtendedproperty 'MS_Description', 'En adresse består af vejnavn, husnummer og postnummer. Ligger adressen i en bygning med flere funktioner (fx flere boliger eller lejemål), kan den være suppleret af en etagebetegnelse og en dørbetegnelse.', 'adresse';
EXEC SetExtendedproperty 'MS_Description', 'Afstemningsområder', 'afstemningsområdetilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Bygninger', 'bygning';
EXEC SetExtendedproperty 'MS_Description', 'Bygningtilknytninger', 'bygningtilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Ejerlav', 'ejerlav';
EXEC SetExtendedproperty 'MS_Description', 'Jordstykker', 'jordstykke';
EXEC SetExtendedproperty 'MS_Description', 'Jordstykketilknytninger', 'jordstykketilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Kommunetilknytninger', 'kommunetilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Menighedsrådsafstemningsområdetilknytninger', 'menighedsrådsafstemningsområdetilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Navngivenveje', 'navngivenvej';
EXEC SetExtendedproperty 'MS_Description', 'Opstillingskredstilknytninger', 'opstillingskredstilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Politikredstilknytninger', 'politikredstilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Postnumre', 'postnummer';
EXEC SetExtendedproperty 'MS_Description', 'Postnummertilknytninger', 'postnummertilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Regionstilknytninger', 'regionstilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Retskredstilknytninger', 'retskredstilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Sognetilknytninger', 'sognetilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Stednavntilknytninger', 'stednavntilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Stedtilknytninger', 'stedtilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Storkredstilknytninger', 'storkredstilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Supplerendebynavntilknytninger', 'supplerendebynavntilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Valglandsdelstilknytninger', 'valglandsdelstilknytning';
EXEC SetExtendedproperty 'MS_Description', 'Vejpunkter', 'vejpunkt';
EXEC SetExtendedproperty 'MS_Description', 'Vejstykker', 'vejstykke';
EXEC SetExtendedproperty 'MS_Description', 'Vejstykkepostnummerrelationer', 'vejstykkepostnummerrelation';
EXEC SetExtendedproperty 'MS_Description', 'Zonetilknytninger', 'zonetilknytning';
EXEC SetExtendedproperty 'MS_Description', 'En struktureret betegnelse som angiver en særskilt adgang til et areal, en bygning eller en del af en bygning, efter reglerne i adressebekendtgørelsen. En adresse fastsættes for at angive en bestemt adgang til et areal, fx. en byggegrund, en bygning eller en del af en bygning, fx en bolig- eller erhvervsenhed i en bygning. Reglerne for fastsættelse af adresser findes i adressebekendtgørelsen.', 'dar_adresse_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'En struktureret betegnelse som angiver en særskilt adgang til et areal, en bygning eller en del af en bygning, efter reglerne i adressebekendtgørelsen. En adresse fastsættes for at angive en bestemt adgang til et areal, fx. en byggegrund, en bygning eller en del af en bygning, fx en bolig- eller erhvervsenhed i en bygning. Reglerne for fastsættelse af adresser findes i adressebekendtgørelsen.', 'dar_adresse_historik';
EXEC SetExtendedproperty 'MS_Description', 'Klasse der samler de fælles egenskaber for et geografisk punkt, som er relevant for en adresse eller for et husnummer', 'dar_adressepunkt_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'Klasse der samler de fælles egenskaber for et geografisk punkt, som er relevant for en adresse eller for et husnummer', 'dar_adressepunkt_historik';
EXEC SetExtendedproperty 'MS_Description', 'Geografisk inddeling af kommunerne i områder, hvor vælgere stemmer til Folketings-, EU- og Kommunevalg, samt til folkeafstemninger. Hver kommune eller del af en kommune i en opstillingskreds er inddelt i afstemningsområder. En kommune eller del af en kommune kan dog udgøre ét afstemningsområde. Hvert afstemningsområde har ét afstemningssted, hvor vælgerne skal afgive deres stemme.', 'dar_darafstemningsområde_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'Geografisk inddeling af kommunerne i områder, hvor vælgere stemmer til Folketings-, EU- og Kommunevalg, samt til folkeafstemninger. Hver kommune eller del af en kommune i en opstillingskreds er inddelt i afstemningsområder. En kommune eller del af en kommune kan dog udgøre ét afstemningsområde. Hvert afstemningsområde har ét afstemningssted, hvor vælgerne skal afgive deres stemme.', 'dar_darafstemningsområde_historik';
EXEC SetExtendedproperty 'MS_Description', 'Den kommunale myndigheds geografiske afgrænsning som fastlagt i loven.', 'dar_darkommuneinddeling_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'Den kommunale myndigheds geografiske afgrænsning som fastlagt i loven.', 'dar_darkommuneinddeling_historik';
EXEC SetExtendedproperty 'MS_Description', 'Afgrænsning af et menighedsrådsafstemningsområde. Ministeriet for Ligestilling og Kirke fastlægger MENIGHEDSRÅDSAFTEMNINGSOMRÅDE, når der er valg til menighedsrådene, i de sogne, hvor der skal være afstemningsvalg til menighedsrådet.', 'dar_darmenighedsrådsafstemningsområde_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'Afgrænsning af et menighedsrådsafstemningsområde. Ministeriet for Ligestilling og Kirke fastlægger MENIGHEDSRÅDSAFTEMNINGSOMRÅDE, når der er valg til menighedsrådene, i de sogne, hvor der skal være afstemningsvalg til menighedsrådet.', 'dar_darmenighedsrådsafstemningsområde_historik';
EXEC SetExtendedproperty 'MS_Description', 'De folkekirkelige sognes geografiske afgrænsning som fastlagt i loven (om Folkekirken). Sognegrænser er fastlagt i matrikelregisteret, og de følger matrikelskel jf. jordstykkernes tilhørsforhold til sogne undtagen der, hvor de falder sammen med kommunegrænsen. Langs kommunegrænser er de topografisk tilpasset på samme måde som kommunegrænser.', 'dar_darsogneinddeling_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'De folkekirkelige sognes geografiske afgrænsning som fastlagt i loven (om Folkekirken). Sognegrænser er fastlagt i matrikelregisteret, og de følger matrikelskel jf. jordstykkernes tilhørsforhold til sogne undtagen der, hvor de falder sammen med kommunegrænsen. Langs kommunegrænser er de topografisk tilpasset på samme måde som kommunegrænser.', 'dar_darsogneinddeling_historik';
EXEC SetExtendedproperty 'MS_Description', 'Betegnelse, som indgår i den samlede adressebetegnelse, idet den identificerer det adgangspunkt, som giver adgang til den eller de pågældende adresser. Når et adgangspunkt giver adgang til en eller flere adresser, indgår husnummeret i den samlede og fuldstændige adressebetegnelse for hver af disse. Reglerne for fastsættelse af Husnumre findes i adressebekendtgørelsen.', 'dar_husnummer_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'Betegnelse, som indgår i den samlede adressebetegnelse, idet den identificerer det adgangspunkt, som giver adgang til den eller de pågældende adresser. Når et adgangspunkt giver adgang til en eller flere adresser, indgår husnummeret i den samlede og fuldstændige adressebetegnelse for hver af disse. Reglerne for fastsættelse af Husnumre findes i adressebekendtgørelsen.', 'dar_husnummer_historik';
EXEC SetExtendedproperty 'MS_Description', 'Et færdselsareal for hvilket der er fastsat et vejnavn efter reglerne i Adressebekendtgørelsen. En navngiven vej repræsenterer en del af færdselsnettet (dvs. vej, torv, sti e.l.) som er tildelt et særskilt vejnavn efter reglerne i adressebekendtgørelsen, uanset om vejen ligger inden for en kommune eller krydser en eller flere kommunegrænser.', 'dar_navngivenvej_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'Et færdselsareal for hvilket der er fastsat et vejnavn efter reglerne i Adressebekendtgørelsen. En navngiven vej repræsenterer en del af færdselsnettet (dvs. vej, torv, sti e.l.) som er tildelt et særskilt vejnavn efter reglerne i adressebekendtgørelsen, uanset om vejen ligger inden for en kommune eller krydser en eller flere kommunegrænser.', 'dar_navngivenvej_historik';
EXEC SetExtendedproperty 'MS_Description', 'Den del af den navngivne vej der berører en bestemt kommune. Navngiven Vej Kommunedel angiver at en navngiven vej berører en bestemt kommune. Objektet indeholder bl.a. de de hidtidige Kommune- og Vejkoder som det, af hensyn til den eksisterende systemmasse, er nødvendigt at bibeholde for at identificere et vejnavn.', 'dar_navngivenvejkommunedel_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'Den del af den navngivne vej der berører en bestemt kommune. Navngiven Vej Kommunedel angiver at en navngiven vej berører en bestemt kommune. Objektet indeholder bl.a. de de hidtidige Kommune- og Vejkoder som det, af hensyn til den eksisterende systemmasse, er nødvendigt at bibeholde for at identificere et vejnavn.', 'dar_navngivenvejkommunedel_historik';
EXEC SetExtendedproperty 'MS_Description', 'DAR navngivenvejpostnummerrelationer - aktuel', 'dar_navngivenvejpostnummerrelation_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'DAR navngivenvejpostnummerrelationer - historik', 'dar_navngivenvejpostnummerrelation_historik';
EXEC SetExtendedproperty 'MS_Description', 'DAR navngivenvejsupplerendebynavnrelationer - aktuel', 'dar_navngivenvejsupplerendebynavnrelation_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'DAR navngivenvejsupplerendebynavnrelationer - historik', 'dar_navngivenvejsupplerendebynavnrelation_historik';
EXEC SetExtendedproperty 'MS_Description', 'Postnummer med tilhørende navn som indgår i det landsdækkende postnummersystem. Efter postloven er det den befordringspligtige postvirksomhed, der administrerer postnummersystemet. Postnumrenes geografiske afgrænsning registreres i DAGI.', 'dar_postnummer_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'Postnummer med tilhørende navn som indgår i det landsdækkende postnummersystem. Efter postloven er det den befordringspligtige postvirksomhed, der administrerer postnummersystemet. Postnumrenes geografiske afgrænsning registreres i DAGI.', 'dar_postnummer_historik';
EXEC SetExtendedproperty 'MS_Description', 'DAR reserveretvejnavne - aktuel', 'dar_reserveretvejnavn_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'DAR reserveretvejnavne - historik', 'dar_reserveretvejnavn_historik';
EXEC SetExtendedproperty 'MS_Description', 'Navn på et supplerende bynavn som præciser en adresses eller et vejnavns beliggenhed inden for postnummret. Det er adressemyndigheden der fastsætter det supplerende bynavn og dettes afgrænsning efter reglerne i adressebekendtgørelsen. Den geografiske afgrænsning registreres i DAGI.', 'dar_supplerendebynavn_aktuel';
EXEC SetExtendedproperty 'MS_Description', 'Navn på et supplerende bynavn som præciser en adresses eller et vejnavns beliggenhed inden for postnummret. Det er adressemyndigheden der fastsætter det supplerende bynavn og dettes afgrænsning efter reglerne i adressebekendtgørelsen. Den geografiske afgrænsning registreres i DAGI.', 'dar_supplerendebynavn_historik';
EXEC SetExtendedproperty 'MS_Description', 'Geografisk inddeling af kommunerne i områder, hvor vælgere stemmer til Folketings-, EU- og Kommunevalg, samt til folkeafstemninger. Hver kommune eller del af en kommune i en opstillingskreds er inddelt i afstemningsområder. En kommune eller del af en kommune kan dog udgøre ét afstemningsområde. Hvert afstemningsområde har ét afstemningssted, hvor vælgerne skal afgive deres stemme.', 'DAGI__afstemningsomraader';
EXEC SetExtendedproperty 'MS_Description', 'Den kommunale myndigheds geografiske afgrænsning som fastlagt i loven. For tiden er der 98 kommuner. Christiansø ligger uden for den kommunale inddeling, men eksisterer af systemtekniske årsager som Kommuneinddeling, men markeret som ”udenfor kommuneinddeling”. Kommuneinddeling er en topografisk tilpasset kommunegrænse, der fastlægges ved tilpasning af de matrikelskel, som afgrænser kommunen. Indmålte skelpunkter respekteres og indgår i Kommuneinddeling. Øvrigt forløb fastlægges på baggrund af FOT-objekter, der tydeligt giver et bud på grænsens fysiske forløb f.eks. vandløb, dige, kystlinje mv. (FOT-specifikationen angiver en prioritering af de topografiske objekter).', 'DAGI__kommuner';
EXEC SetExtendedproperty 'MS_Description', 'Afgrænsning af et menighedsrådsafstemningsområde. Ministeriet for Ligestilling og Kirke fastlægger MENIGHEDSRÅDSAFTEMNINGSOMRÅDE, når der er valg til menighedsrådene, i de sogne, hvor der skal være afstemningsvalg til menighedsrådet.', 'DAGI__menighedsraadsafstemningsomraader';
EXEC SetExtendedproperty 'MS_Description', 'Geografisk inddeling af landet i 92 kredse, hvorfra kandidater opstilles og vælges til Folketinget. Nederste niveau i inddelingen af Danmark i valgkredse jf. valgkredsfortegnelsen, bilag til Lov om valg til Folketinget.', 'DAGI__opstillingskredse';
EXEC SetExtendedproperty 'MS_Description', 'Politimyndighedens geografiske afgrænsning som fastlagt i loven.', 'DAGI__politikredse';
EXEC SetExtendedproperty 'MS_Description', 'Geografisk inddeling af landet i postnumre til brug for den landsdækkende postbefordring. Post Danmark (ifølge koncession den befordringspligtige postvirksomhed i Danmark) vedligeholder det offentlige postnummersystem til brug for den landsdækkende postbetjening og til sikring af den geografiske entydighed af vejnavne og adresser. Postnumrene er anderledes udformet i København K, København V og Frederiksberg C, hvor de er mindre arealer og baserer sig på veje og gader.', 'DAGI__postnumre';
EXEC SetExtendedproperty 'MS_Description', 'Den regionale myndigheds geografiske afgrænsning som fastlagt i loven. For tiden er der 5 regioner. Christiansø ligger uden for den kommunale og regionale inddeling.', 'DAGI__regioner';
EXEC SetExtendedproperty 'MS_Description', 'De lokale domstolsmyndigheders geografiske afgrænsning (byretskredse) som fastlagt i loven. Post Danmark (ifølge koncession den befordringspligtige postvirksomhed i Danmark) vedligeholder det offentlige postnummersystem til brug for den landsdækkende postbetjening og til sikring af den geografiske entydighed af vejnavne og adresser.', 'DAGI__retskredse';
EXEC SetExtendedproperty 'MS_Description', 'De folkekirkelige sognes geografiske afgrænsning som fastlagt i loven (om Folkekirken). Sognegrænser er fastlagt i matrikelregisteret, og de følger matrikelskel jf. jordstykkernes tilhørsforhold til sogne undtagen der, hvor de falder sammen med kommunegrænsen. Langs kommunegrænser er de topografisk tilpasset på samme måde som kommunegrænser.', 'DAGI__sogne';
EXEC SetExtendedproperty 'MS_Description', 'Afgrænsning af en storkreds.', 'DAGI__storkredse';
EXEC SetExtendedproperty 'MS_Description', 'Geografisk afgrænsning af en gruppe af adresser i et bestemt område, for at præcisere beliggenheden af disse. Et supplerende bynavn er et bynavn eller et andet lokalt stednavn som er en underinddeling af et postnummer. Supplerende bynavn er en optionel tilføjelse til postadressen, og det findes i ca. 35% af alle danske adresser.', 'DAGI__supplerendebynavne2';
EXEC SetExtendedproperty 'MS_Description', 'Afgrænsning af en valglandsdel.', 'DAGI__valglandsdele';
EXEC SetExtendedproperty 'MS_Description', 'Steder fra registeret Danske Stednavne', 'DAGI__steder';
EXEC SetExtendedproperty 'MS_Description', 'Stednavne fra registeret Danske Stednavne', 'DAGI__stednavne';
EXEC SetExtendedproperty 'MS_Description', 'System Tabel. Holds info about last DAWA Udtraek, Update or DAGI-load for all entities.', 'entitystate';
EXEC SetExtendedproperty 'MS_Description', 'System Tabel. Holds info about all DAWA and DAGI changes.', 'entitystatehistory';
EXEC SetExtendedproperty 'MS_Description', 'Afstemningsområder', 'Afstemningsområde';
EXEC SetExtendedproperty 'MS_Description', 'Brofasthed', 'Brofasthed';
EXEC SetExtendedproperty 'MS_Description', 'DAGI postnummre', 'Dagi_postnummer';
EXEC SetExtendedproperty 'MS_Description', 'Højder', 'Højde';
EXEC SetExtendedproperty 'MS_Description', 'Kommuner', 'Kommune';
EXEC SetExtendedproperty 'MS_Description', 'Landpostnumre', 'Landpostnummer';
EXEC SetExtendedproperty 'MS_Description', 'Menighedsrådsafstemningsområder', 'Menighedsrådsafstemningsområde';
EXEC SetExtendedproperty 'MS_Description', 'Opstillingskredse', 'Opstillingskreds';
EXEC SetExtendedproperty 'MS_Description', 'Politikreds', 'Politikreds';
EXEC SetExtendedproperty 'MS_Description', 'Regioner', 'Region';
EXEC SetExtendedproperty 'MS_Description', 'Retskredse', 'Retskreds';
EXEC SetExtendedproperty 'MS_Description', 'Sogn', 'Sogn';
EXEC SetExtendedproperty 'MS_Description', 'Steder', 'Sted';
EXEC SetExtendedproperty 'MS_Description', 'Egennavn eller betegnelse på en geografisk lokalitet.', 'Stednavn';
EXEC SetExtendedproperty 'MS_Description', 'Storkredse', 'Storkreds';
EXEC SetExtendedproperty 'MS_Description', 'Et supplerende bynavn knyttes til en gruppe af adresser, når det er hensigtsmæssigt at præcisere deres beliggenhed inden for kommunen eller postdistriktet, som fx ”Smøgen 15, Darup, 4000 Roskilde”. Ca. 30 % af Danmarks adresser er tilknyttet et supplerende bynavn.', 'Supplerendebynavn';
EXEC SetExtendedproperty 'MS_Description', 'Valglandsdele', 'Valglandsdel';
EXEC SetExtendedproperty 'MS_Description', 'Vask adresse historik', 'Vask_adresse_historik';
EXEC SetExtendedproperty 'MS_Description', 'Vask husnummer historik', 'Vask_husnummer_historik';
EXEC SetExtendedproperty 'MS_Description', 'Vejmidte', 'Vejmidte';
EXEC SetExtendedproperty 'MS_Description', 'Zoner', 'Zone';
EXEC SetExtendedproperty 'MS_Description', 'Ikke brofast husnummer', 'ikke_brofast_husnummer';
GO
