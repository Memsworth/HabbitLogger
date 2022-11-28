namespace HabbitLogger
{
    internal class UiBuilder
    {
        public static void MainMenu()
        {
            Console.WriteLine("MAIN MENU\n\n");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("Type 0 to Close Application.");
            Console.WriteLine("Type 1 to View All Records.");
            Console.WriteLine("Type 2 to Insert Record.");
            Console.WriteLine("Type 3 to Delete Record.");
            Console.WriteLine("Type 4 to Update Record.");
        }

    }
}
