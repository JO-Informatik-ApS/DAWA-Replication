DawaReplication ReadMe
======================
Documentation: See "DAWA Replikerings klient.docx""

Overview
- DAWA data: Should be updated every 5. minute by Windows Scheduler (but not in night)
- DAGI data: Should be loaded every night (full load) by Windows Scheduler
- DAGI data is in tables prefixed with dagi__Xxxx

FixList.csv
======================
Use this file to change values in incomming date that results in a problem, 
e.g. a null being saved in a non-null column in the database.
See more in top of FixList.csv

SQL
======================
See current status in table "entitystate" (see old status in entitystatehistory)

entitystate - Holds info about last DAWA Udtraek, Update or DAGI-load for all entities
---------------------------------------------------------------------------------
txid:		Latest transaction id for entity. Set to null if Udtraek failed.
entity:		Entity name (ake Tabelname).
success:	Entity transaction state. Set to null when starting. Updated when finished with success (1) or failure (0).
successtime:The time success was set to true.
successtimeChange: The time there was an actual change (count <> 0) with success.
starttime:	Transaction start time.
finishtime:	Transaction finishing time. Set to null when starting and updated when finished.
count:		Number of rows processed. Null if transaction didn't succeed.
message:	Error message if any. Null if none.


Find problems: SELECT * FROM entitystate WHERE success <> 1

Datetime format UTC
======================
All tables have datetime fields in UTC except for a few.
The following entities have Datetime fields NOT in UTC, as in the dates are in Danish local time:
Adgangsadresse
(oprettet, ændret, ikrafttrædelsesdato, adressepunktændringsdato)

Adresse
(oprettet, ændret, ikrafttrædelsesdato)

Vejstykke
(oprettet, ændret)