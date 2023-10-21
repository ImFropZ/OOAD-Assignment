using System.Data;
using Npgsql;

namespace server.Services
{
    public class DatabaseService
    {
        NpgsqlConnection _connection;

        public DatabaseService(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }

        public void Open()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void Close()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public ConnectionState State()
        {
            return _connection.State;
        }

        public NpgsqlDataReader ExecuteReader(string query)
        {
            NpgsqlCommand command = new(query, _connection);

            return command.ExecuteReader();
        }

        public int ExecuteNonQuery(string query)
        {
            NpgsqlCommand command = new(query, _connection);

            return command.ExecuteNonQuery();
        }

        public object? ExecuteScalar(string query)
        {
            NpgsqlCommand command = new(query, _connection);

            return command.ExecuteScalar();
        }

        public DataTable ExecuteQuery(string query)
        {
            NpgsqlCommand command = new(query, _connection);
            NpgsqlDataAdapter adapter = new(command);
            DataTable dataTable = new();

            adapter.Fill(dataTable);

            return dataTable;
        }
    }
}
