--EXEC SetExtendedproperty 'MS_Description', 'kolonne beskrivelse', 'DAGI__tabelnavn', 'kolonnenavn';

--dagi_afstemningsomraader
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__afstemningsomraader', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__afstemningsomraader', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__afstemningsomraader', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__afstemningsomraader', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__afstemningsomraader', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__afstemningsomraader', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__afstemningsomraader', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__afstemningsomraader', 'bbox';
-- Felter der ikke er i DagiBase:
EXEC SetExtendedproperty 'MS_Description', 'Unik ID.', 'DAGI__afstemningsomraader', 'Dagi_id';
EXEC SetExtendedproperty 'MS_Description', 'Afstemningsområdets nummer. Heltal.', 'DAGI__afstemningsomraader', 'nummer';
EXEC SetExtendedproperty 'MS_Description', 'Afstemningsområdets navn.', 'DAGI__afstemningsomraader', 'navn';
EXEC SetExtendedproperty 'MS_Description', 'Kommunens valg af afstmemningssted.', 'DAGI__afstemningsomraader', 'afstemningsstednavn';
EXEC SetExtendedproperty 'MS_Description', 'Adgangsadressens unikke ID.', 'DAGI__afstemningsomraader', 'afstemningsstedadresseid';
EXEC SetExtendedproperty 'MS_Description', 'Adressebetegnelse for adgangsadressen.', 'DAGI__afstemningsomraader', 'afstemningsstedadressebetegnelse';
EXEC SetExtendedproperty 'MS_Description', 'Afstemningssteds adgangspunkts x-koordinat.', 'DAGI__afstemningsomraader', 'afstemningssted_adgangspunkt_x';
EXEC SetExtendedproperty 'MS_Description', 'Afstemningssteds adgangspunkts y-koordinat.', 'DAGI__afstemningsomraader', 'afstemningssted_adgangspunkt_y';
EXEC SetExtendedproperty 'MS_Description', 'Kommunekoden. 4 cifre.', 'DAGI__afstemningsomraader', 'kommunekode';
EXEC SetExtendedproperty 'MS_Description', 'Kommunens navn.', 'DAGI__afstemningsomraader', 'kommunenavn';
EXEC SetExtendedproperty 'MS_Description', 'Regionskoden. 4 cifre.', 'DAGI__afstemningsomraader', 'regionskode';
EXEC SetExtendedproperty 'MS_Description', 'Regionens navn.', 'DAGI__afstemningsomraader', 'regionsnavn';
EXEC SetExtendedproperty 'MS_Description', 'Opstillingskredsens unikke nummer.', 'DAGI__afstemningsomraader', 'opstillingskredsnummer';
EXEC SetExtendedproperty 'MS_Description', 'Opstillingskredsens unikke navn.', 'DAGI__afstemningsomraader', 'opstillingskredsnavn';
EXEC SetExtendedproperty 'MS_Description', 'Storkredsens unikke nummer.', 'DAGI__afstemningsomraader', 'storkredsnummer';
EXEC SetExtendedproperty 'MS_Description', 'Storkredsens unikke navn.', 'DAGI__afstemningsomraader', 'storkredsnavn';
EXEC SetExtendedproperty 'MS_Description', 'Valglandsdelens bogstav.', 'DAGI__afstemningsomraader', 'valglandsdelsbogstav';
EXEC SetExtendedproperty 'MS_Description', 'Valglandsdelens navn.', 'DAGI__afstemningsomraader', 'valglandsdelsnavn';


--dagi_kommuner
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__kommuner', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__kommuner', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__kommuner', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__kommuner', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__kommuner', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__kommuner', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__kommuner', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__kommuner', 'bbox';
-- Felter der ikke er i DagiBase:
EXEC SetExtendedproperty 'MS_Description', 'Unik ID.', 'DAGI__kommuner', 'Dagi_id';
EXEC SetExtendedproperty 'MS_Description', 'Kommunens myndighedskode. Er unik for hver kommune. 4 cifre.', 'DAGI__kommuner', 'kode';
EXEC SetExtendedproperty 'MS_Description', 'Kommunens navn.', 'DAGI__kommuner', 'navn';
EXEC SetExtendedproperty 'MS_Description', 'Regionskoden. 4 cifre.', 'DAGI__kommuner', 'regionskode';
EXEC SetExtendedproperty 'MS_Description', 'Falsk angiver at kommunen er en ægte kommune med en folkevalgt forsamling. Sand angiver at området/kommunen hører under Forsvarministeriet.', 'DAGI__kommuner', 'udenforkommuneinddeling';
EXEC SetExtendedproperty 'MS_Description', 'Regionens navn.', 'DAGI__kommuner', 'regionsnavn';


--dagi_menighedsraadsafstemningsomraader
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__menighedsraadsafstemningsomraader', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__menighedsraadsafstemningsomraader', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__menighedsraadsafstemningsomraader', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__menighedsraadsafstemningsomraader', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__menighedsraadsafstemningsomraader', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__menighedsraadsafstemningsomraader', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__menighedsraadsafstemningsomraader', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__menighedsraadsafstemningsomraader', 'bbox';


--dagi_opstillingskredse
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__opstillingskredse', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__opstillingskredse', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__opstillingskredse', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__opstillingskredse', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__opstillingskredse', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__opstillingskredse', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__opstillingskredse', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__opstillingskredse', 'bbox';


--dagi_politikredse
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__politikredse', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__politikredse', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__politikredse', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__politikredse', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__politikredse', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__politikredse', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__politikredse', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__politikredse', 'bbox';


--dagi_postnumre
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__postnumre', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__postnumre', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__postnumre', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__postnumre', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__postnumre', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__postnumre', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__postnumre', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__postnumre', 'bbox';


--dagi_regioner
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__regioner', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__regioner', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__regioner', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__regioner', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__regioner', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__regioner', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__regioner', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__regioner', 'bbox';


--dagi_retskredse
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__retskredse', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__retskredse', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__retskredse', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__retskredse', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__retskredse', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__retskredse', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__retskredse', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__retskredse', 'bbox';


--dagi_sogne
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__sogne', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__sogne', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__sogne', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__sogne', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__sogne', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__sogne', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__sogne', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__sogne', 'bbox';


--dagi_steder
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__steder', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__steder', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__steder', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__steder', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__steder', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__steder', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__steder', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__steder', 'bbox';


--dagi_stednavne
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__stednavne', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__stednavne', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__stednavne', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__stednavne', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__stednavne', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__stednavne', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__stednavne', 'geometry';


--dagi_storkredse
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__storkredse', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__storkredse', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__storkredse', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__storkredse', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__storkredse', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__storkredse', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__storkredse', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__storkredse', 'bbox';


--dagi_supplerendebynavne2
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__supplerendebynavne2', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__supplerendebynavne2', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__supplerendebynavne2', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__supplerendebynavne2', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__supplerendebynavne2', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__supplerendebynavne2', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__supplerendebynavne2', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__supplerendebynavne2', 'bbox';


--dagi_valglandsdele
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__valglandsdele', 'visueltcenter_x';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.', 'DAGI__valglandsdele', 'visueltcenter_y';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).', 'DAGI__valglandsdele', 'ændret';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunkt for seneste ændring af geometrien registreret i DAWA.', 'DAGI__valglandsdele', 'geo_ændret';
EXEC SetExtendedproperty 'MS_Description', 'Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.', 'DAGI__valglandsdele', 'geo_version';
EXEC SetExtendedproperty 'MS_Description', 'Tidspunktet da rækken blev oprettet eller ændret i databasen.', 'DAGI__valglandsdele', 'entity_updated';
EXEC SetExtendedproperty 'MS_Description', 'Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.', 'DAGI__valglandsdele', 'geometry';
EXEC SetExtendedproperty 'MS_Description', 'Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.', 'DAGI__valglandsdele', 'bbox';
