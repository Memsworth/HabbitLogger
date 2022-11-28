namespace HabbitLogger
{
    internal class DatabaseConnection
    {
        public string ConnectionString { get; }

        public DatabaseConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
