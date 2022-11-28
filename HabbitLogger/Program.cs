namespace HabbitLogger // Note: actual namespace depends on the project name.
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var database = new DatabaseConnection(LoadConnectionString);
            var data = new DataAccess(database);
            var item = data.LoadHabbitRecords();

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
                        break;
                    case "4":
                        break;
                    default:
                        break;
                }
            }
        }

        private static Habbit CreatePerson()
        {
            string habbitName;
            do
            {
                Console.Write("Enter a habbit: ");
                habbitName = Console.ReadLine() ?? throw new ArgumentNullException();

            } while (string.IsNullOrEmpty(habbitName));

            int repetition;
            do
            {
                Console.Write("Enter repetition: ");
                repetition = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException());

            } while (repetition <= 0);

           return new Habbit(habbitName!, DateOnly.FromDateTime(DateTime.Now), repetition);
        }



        private static string LoadConnectionString => System.Configuration.ConfigurationManager.ConnectionStrings["HabbitDB"].ConnectionString;
    }

}