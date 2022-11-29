
using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace HabbitLogger
{
    internal class DataAccess
    {
        private DatabaseConnection Connection { get; }

        public DataAccess(DatabaseConnection DBconnection)
        {
            this.Connection = DBconnection;
        }


        public List<Habbit> LoadHabbitRecords()
        {
            var items = new List<Habbit>();
            using (var connection = new SqliteConnection(Connection.ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"Select * from Habbit";
                var reader = command.ExecuteReader();

                foreach (var item in reader)
                {
                    var dataRecord = item as DbDataRecord;

                    if (dataRecord is null) continue;

                    DateOnly.TryParse(dataRecord["date"].ToString(), out DateOnly date);
                    var record = new Habbit((int)System.Convert.ChangeType(dataRecord["id"], typeof(int)),
                        (string)System.Convert.ChangeType(dataRecord["habbitname"], typeof(string)),
                        date, (int)System.Convert.ChangeType(dataRecord["repetition"], typeof(int)));
                    items.Add(record);
                }
            }
            return items;
        }


        public void Insert(Habbit record)
        {
            using (var connection = new SqliteConnection(Connection.ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"INSERT INTO Habbit (HabbitName, date, Repetition) VALUES (@habbitname, @date, @rep)";
                command.Parameters.AddWithValue(@"@habbitname", record.HabbitName);
                command.Parameters.AddWithValue(@"@date", record.Date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue(@"@rep", record.Repetiton);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int idDelete)
        {
            try
            {
                using (var connection = new SqliteConnection(Connection.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"DELETE FROM Habbit WHERE id = (@id)";
                    command.Parameters.AddWithValue(@"@id", idDelete);
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("It doesn't exist");
            }
            
        }

        public void Update(Habbit record)
        {

        }

    }
}
