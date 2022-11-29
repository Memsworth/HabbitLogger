using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Data.Sqlite;
using System.Data.Common;



namespace HabbitLogger // Note: actual namespace depends on the project name.
{
    internal static class Program
    {
        static void Main(string[] args)
        {

            CreateDB();
            var database = new DatabaseConnection(LoadConnectionString);
            var data = new DataAccess(database);
            var endApp = false;

            while (endApp != true)
            {
                UiBuilder.MainMenu();
                switch (Console.ReadLine())
                {
                    case "0":
                        endApp = true;
                        break;
                    case "1":
                        UiBuilder.ShowRecords(data.LoadHabbitRecords());
                        break;
                    case "2":
                        data.Insert(CreatePerson());
                        break;
                    case "3":
                        data.Delete(GetId());
                        break;
                    case "4":
                        break;
                    default:
                        break;
                }
            }
        }

        private static int GetId()
        {
            int input;
            do
            {
                Console.Write("Enter the ID you want to delete: ");
                int.TryParse(Console.ReadLine(), out input);
            } while (input <= 0);

            return input;
        }
        private static Habbit CreatePerson()
        {
            var habbitName = GetHabbitName();

            var repetition = GetRepetition();

            return new Habbit(habbitName!, DateOnly.FromDateTime(DateTime.Now), repetition);
        }

        private static int GetRepetition()
        {
            int repetition;
            do
            {
                Console.Write("Enter repetition: ");
                repetition = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException());
            } while (repetition <= 0);

            return repetition;
        }

        private static string GetHabbitName()
        {
            string habbitName;
            do
            {
                Console.Write("Enter a habbit: ");
                habbitName = Console.ReadLine() ?? throw new ArgumentNullException();
            } while (string.IsNullOrEmpty(habbitName));

            return habbitName;
        }

        private static void CreateDB()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\HabbitDatabase.db";
            Console.WriteLine("Just entered to create HabbitDB");
            using (SqliteConnection db = new SqliteConnection("Filename=" + path))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT EXISTS Habbit (  ID INTEGER NOT NULL UNIQUE,  HabbitName TEXT NOT NULL,  Date TEXT NOT NULL,  Repetition INTEGER NOT NULL,  PRIMARY KEY(ID AUTOINCREMENT) )";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                try
                {
                    createTable.ExecuteReader();
                }
                catch (SqliteException e)
                {
                    //Do nothing
                }
            }
        }
        private static string LoadConnectionString => System.Configuration.ConfigurationManager.ConnectionStrings["HabbitDB"].ConnectionString;
    }

}