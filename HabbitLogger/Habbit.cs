namespace HabbitLogger
{
    public class Habbit
    {
        public int ID { get; }
        public string HabbitName { get; }
        public DateOnly Date { get; private set; }
        public int Repetiton { get; private set; }

        public Habbit(int iD, string habbitName, DateOnly date, int repetiton) : this (habbitName, date, repetiton)
        {
            ID = iD;
        }

        public Habbit(string habbitName, DateOnly date, int repetiton)
        {
            HabbitName = habbitName;
            Date = date;
            Repetiton = repetiton;
        }

        public override string ToString() => $" ID: {ID,-5} Habbit: {HabbitName,-15} Date: {Date}  " +
            $"Repetition:{Repetiton}";
    }
}
