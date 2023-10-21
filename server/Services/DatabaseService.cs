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

        public NpgsqlConnection Connection
        {
            get { return _connection; }
        }

        public NpgsqlDataReader ExecuteReader(string query)
        {
            NpgsqlCommand command = new(query, _connection);

            return command.ExecuteReader();
        }

        public Task<NpgsqlDataReader> ExecuteReaderAsync(string query)
        {
            NpgsqlCommand command = new(query, _connection);

            return command.ExecuteReaderAsync();
        }

        public int ExecuteNonQuery(string query)
        {
            NpgsqlCommand command = new(query, _connection);

            return command.ExecuteNonQuery();
        }

        public Task<int> ExecuteNonQueryAsync(string query)
        {
            NpgsqlCommand command = new(query, _connection);

            return command.ExecuteNonQueryAsync();
        }

        public object? ExecuteScalar(string query)
        {
            NpgsqlCommand command = new(query, _connection);

            return command.ExecuteScalar();
        }

        public Task<object?> ExecuteScalarAsync(string query)
        {
            NpgsqlCommand command = new(query, _connection);

            return command.ExecuteScalarAsync();
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
