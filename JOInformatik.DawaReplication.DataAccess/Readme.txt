TIPS

Entity Framework Commands (in Package Manager Console)

Install EntityFrameworkCore tools (only first time):
PM> Install-Package Microsoft.EntityFrameworkCore.Tools

NOTE: Set Default projet to JOInformatik.DawaReplication.DataAccess!

To create initial migration - see connectionString in app.config
PM> EntityFrameworkCore\Add-Migration InitialCreate -Context JOInformatik.DawaReplication.DataAccess.DawaReplicationDBContext

To create database - see connectionString in app.config
PM> EntityFrameworkCore\Update-Database -Context JOInformatik.DawaReplication.DataAccess.DawaReplicationDBContext

To Update existing database after model change:
PC> EntityFrameworkCore\Add-Migration updateName -Context JOInformatik.DawaReplication.DataAccess.DawaReplicationDBContext

Database must be Danish_Norwegian_CI_AS!