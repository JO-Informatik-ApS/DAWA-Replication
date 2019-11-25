using Microsoft.EntityFrameworkCore;

namespace JOInformatik.DawaReplication.DataAccess
{
    public class FixDBProblems
    {
        public static void FixDbProblems(DbContext dBContext)
        {
            var sql = @"
                -- vvvvvvvvvv Delete existing primary key and recreate with Danish_Norwegian_CS_AS. vvvvvvvvvv

                IF EXISTS (SELECT * FROM sys.indexes 
                WHERE name='PK_stednavn' AND object_id = OBJECT_ID('stednavn'))
	                ALTER TABLE stednavn DROP CONSTRAINT PK_stednavn
                
                IF EXISTS (SELECT * FROM sys.columns 
                WHERE name='navn' AND object_id = OBJECT_ID('stednavn'))
                    ALTER TABLE stednavn ALTER COLUMN navn VARCHAR(100) COLLATE Danish_Norwegian_CS_AS NOT NULL

                IF NOT EXISTS (SELECT * FROM sys.indexes 
                WHERE name='PK_stednavn' AND object_id = OBJECT_ID('stednavn'))
                    ALTER TABLE stednavn ADD CONSTRAINT [PK_stednavn] PRIMARY KEY (stedid, navn)

                -- ^^^^^^^^^^ Delete existing primary key and recreate with Danish_Norwegian_CS_AS. ^^^^^^^^^^";

            dBContext.Database.ExecuteSqlCommand(sql);
        }

        public static void RebuildIndices(DbContext dbContext)
        {
            var sql = @"
            
                -- vvvvvvvvvv Rebuild all indices after udtraek. vvvvvvvvvv            

                USE [DAWA_REPLICATION]
                Exec sp_msforeachtable 'SET QUOTED_IDENTIFIER ON; ALTER INDEX ALL ON ? REBUILD'

                -- ^^^^^^^^^^ Rebuild all indices after udtraek. ^^^^^^^^^^";

            dbContext.Database.ExecuteSqlCommandAsync(sql);

        }

        public static void CreateSprocSetExtendedproperty(DbContext dBContext)
        {
            var sql = @"IF OBJECT_ID('dbo.SetExtendedproperty', 'P') IS NULL
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
                END";

            dBContext.Database.ExecuteSqlCommand(sql);
        }


        /// <summary>Check that collate is Danish_Norwegian_CI_AS.</summary>
        public void CheckForDanishNorwegianCollate(DbContext dBContext)
        {
            var sql = @"
                IF NOT EXISTS(SELECT TOP 1 COLLATION_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '__EFMigrationsHistory'  AND COLLATION_NAME = 'Danish_Norwegian_CI_AS')
                    RAISERROR('DawaReplcation expected Danish_Norwegian_CI_AS database collate', /*Severity:*/18, /*State:*/ 1)";
            dBContext.Database.ExecuteSqlCommand(sql);
        }
    }
}
