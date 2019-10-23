# DAWA Replication for SQL Server

A C# project to initialize a MSSQL database with an initial replication of data from DAWA with the ability to keep your data up to date by getting delta updates.



## Introduction

Danmarks Adressers Web API (DAWA) is a project that exposes Danish address, street, city name, municipality, various geometry, and other data for everyone to search in and download to have their own copy of. DAWA has a couple of API's, one where you can do search queries, and another to replicate data. You can visit their website and read more about them and what kinds of data you have access to via their API's at [http://dawa.aws.dk/](http://dawa.aws.dk/ "Danmarks Adressers Web API").

You can also find DAWA's own client to replicate data via their API, using a Postgres database. You can read more about their implementation at [http://dawa.aws.dk/dok/guide/replikeringsklient](http://dawa.aws.dk/dok/guide/replikeringsklient).

## Getting Started

These instructions will guide you on how to setup and get the program running.

### Prerequisites

You will at the minimum need an SQL Server version 12 paired with the latest security updates running on your system.
You will also need the .NET Framework 3.5 or higher to run this program.

```
SQL Server 12 or higher.
.NET Framework 4.5 or higher.
```

### Installing and preparation

* To install the program, extract or build your executable and move it to a location where you want it to run from.
* Create a new database in your server with collation Danish-Norwegian-CI-AS (Default name DAWA_REPLICATION).
* Add user read/write and DDL-admin rights. If you intend to run as local administrator user you can also skip this step.
* Edit the DawaReplication.exe.config file. Add the server IP and username/password to the connection string. (You can use integrated security if you are not using a SQL user.)
* Configure the ProdTableInfoList.csv and set tables that you do not need replicated to false. Tables will still be created, but no data will be downloaded. The default setting is all tables set to true.
* Finally run the program and initialize the database by entering "/Update-Database" which will create all tables.
```
Starting DawaReplication assembly ver. 1.x.x.x; DataAccess ver. 1.x.x.x ....
 Input your command. Type /help or /h for help and a list of commands, or enter your command.
> /Update-Database
```
If everything goes well you will see a message telling you that the latest migration has been applied to the database.

```
 The database has been succesfully updated with the latest migration.
```

## Running the program

The first time you are running the program, you will need to make a full database load also known as replication. To run the replication start the program and run it with the "/Udtraek" parameter. This will initialize the replication of data from DAWA's servers.  
**PLEASE NOTE:** The initial replication **will** take a while depending on the number of tables that you have enabled.
```
Starting DawaReplication assembly ver. 1.x.x.x; DataAccess ver. 1.x.x.x ....
 Input your command. Type /help or /h for help and a list of commands, or enter your command.
> /Utraek
```

### Updating your local copy data

After the initial replication, start the program with the "/Update" parameter. This will start the updating process and will download delta updates for your tables. It might take a couple of seconds depending on your machine, and how many changes to the data have been made since your last run.
```
Starting DawaReplication assembly ver. 1.x.x.x; DataAccess ver. 1.x.x.x ....
 Input your command. Type /help or /h for help and a list of commands, or enter your command.
> /Update
```
For easy update management, you can set up a scheduled task to run the client at certain intervals.

## Releases

You can find the lastest zipped binaries and source code over in [the release section](https://github.com/JO-Informatik-ApS/DAWA-Replication/releases), where you can download them and give them a try.

## Issues

If you have any problems or difficulties running the client, feel free to [create a new issue here](https://github.com/JO-Informatik-ApS/DAWA-Replication/issues "Create an issue").

## Authors

* **Jakob Lindekilde**
* **Valdas Zabulionis**

Developed at **JO Informatik ApS**  
Website: [**https://jo-informatik.dk/**](https://jo-informatik.dk/)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
