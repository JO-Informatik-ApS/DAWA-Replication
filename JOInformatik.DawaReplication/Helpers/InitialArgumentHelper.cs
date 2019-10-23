using JOInformatik.DawaReplication.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace JOInformatik.DawaReplication.Helpers
{
    public static class InitialArgumentHelper
    {

        private const string Update = " Update command updates the initialized and filled database with a delta update for each table.";

        private const string Udtraek = " Udtraek command does an initial load of data into the initialized database.";

        private const string Dagi = " Dagi command initializes the update of DAGI tables circumventing the replication API.";

        private const string Help = " Available commands are \"Udtraek\", \"Update\", \"Dagi\", \"/Update-Database\"." +
            "\n For more information about the different commands type \"?\" and the name of the command.\n For example type \"?Update\" to get more information about the update command.";

        private const string DbUpdateComplete = " The database has been succesfully updated with the latest migration.";

        private const string UpdateDatabaseHelp = " The UpdateDatabase command applies the newest migration to the database.";

        private const string InsertText = " Input your command. Type /help or /h for help and a list of commands, or enter your command.";


        public static EntityProcessMode InitializeProcess(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            string firstArg;
            if (args.Length > 0 && args[0].ToLower() != null)
            {
                firstArg = args[0].ToLower();
            }
            else
            {
                Console.WriteLine(InsertText);
                return ConsoleHelper();
            }

            switch (firstArg)
            {
                case "dagi":
                    return EntityProcessMode.Dagi;
                case "/dagi":
                    return EntityProcessMode.Dagi;
                case "update":
                    return EntityProcessMode.Update;
                case "/update":
                    return EntityProcessMode.Update;
                case "udtraek":
                    return EntityProcessMode.Udtraek;
                case "/udtraek":
                    return EntityProcessMode.Udtraek;
                case "update-database":
                    UpdateDatabase();
                    Console.WriteLine(InsertText);
                    return ConsoleHelper();
                case "/update-database":
                    UpdateDatabase();
                    Console.WriteLine(InsertText);
                    return ConsoleHelper();
                default:
                    Console.WriteLine(InsertText);
                    return ConsoleHelper();
            }

        }

        public static EntityProcessMode ConsoleHelper()
        {
            Console.Write("> ");
            var userInput = Console.ReadLine();

            switch (userInput.ToLower())
            {
                case "dagi":
                case "/dagi":
                    return EntityProcessMode.Dagi;
                case "update":
                case "/update":
                    return EntityProcessMode.Update;
                case "udtraek":
                case "/udtraek":
                    return EntityProcessMode.Udtraek;
                case "/update-database":
                case "update-database":
                    UpdateDatabase();
                    Console.WriteLine(InsertText);
                    return ConsoleHelper();
                case "/h":
                case "/help":
                case "?help":
                case "help":
                case "?":
                    Console.WriteLine(Help);
                    Console.WriteLine(InsertText);
                    return ConsoleHelper();
                case "?update":
                case "-update":
                case "help update":
                case "/help update":
                    Console.WriteLine(Update);
                    Console.WriteLine(InsertText);
                    return ConsoleHelper();
                case "-dagi":
                case "?dagi":
                case "help dagi":
                case "/help dagi":
                    Console.WriteLine(Dagi);
                    Console.WriteLine(InsertText);
                    return ConsoleHelper();
                case "?udtraek":
                case "-udtraek":
                case "help udtraek":
                case "/help udtraek":
                    Console.WriteLine(Udtraek);
                    Console.WriteLine(InsertText);
                    return ConsoleHelper();
                case "help updatedatabase":
                case "/help updatedatabase":
                case "?updatedatabase":
                    Console.WriteLine(UpdateDatabaseHelp);
                    Console.WriteLine(InsertText);
                    return ConsoleHelper();
                case "exit":
                case "/exit":
                case "quit":
                case "/quit":
                    Environment.Exit((int)ReturnCode.Success);
                    return EntityProcessMode.Dagi;
                default:
                    Console.WriteLine("Error: Unrecognized command, please try again. For a list of commands type /help or /h.");
                    return ConsoleHelper();
            }
        }

        public static void UpdateDatabase()
        {
            var logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            using (var dBContext = new DawaReplicationDBContext())
            {
                if (dBContext.Database.CanConnect())
                {
                    try
                    {
                        dBContext.Database.Migrate();
                        Console.WriteLine(DbUpdateComplete);
                    }
                    catch (Exception e)
                    {
                        logger.Error("ERROR!: Could not apply the latest migration.", e);
                        Console.WriteLine("ERROR! Could not apply the latest migration. See error message below.");
                        Console.WriteLine(e);
                    }
                }
                else
                {
                    logger.Error("ERROR!: No migration applied, failed to connect to database.");
                    Console.WriteLine("Error: Failed to connect to the database. Check your connection string.");
                }
            }
        }
    }
}
