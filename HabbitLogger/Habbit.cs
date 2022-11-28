namespace HabbitLogger
{
    public class Habbit
    {
        public int ID { get; }
        public string HabbitName { get; }
        public DateTime Date { get; private set; }
        public int Repetiton { get; private set; }

        public Habbit(int iD, string habbitName, DateTime date, int repetiton)
        {
            ID = iD;
            HabbitName = habbitName;
            Date = date;
            Repetiton = repetiton;
        }
    }
}
