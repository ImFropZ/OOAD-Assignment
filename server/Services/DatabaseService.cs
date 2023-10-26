using System.Data;
using Npgsql;

namespace server.Services
{
    public class DatabaseConnection
    {
        public string Host { get; set; } = "localhost";
        public string Port { get; set; } = "5432";
        public string Username { get; set; } = "myusernames";
        public string Password { get; set; } = "mypassword";
        public string Database { get; set; } = "inventory_system";

        public override string ToString()
        {
            return $"Host={Host};Port={Port};Username={Username};Password={Password};Database={Database}";
        }
    }

    public class DatabaseService
    {
        private readonly NpgsqlConnection _connection;

        public DatabaseService(DatabaseConnection dbc)
        {
            _connection = new NpgsqlConnection(dbc.ToString());
            this.OpenAsync();
        }

        public async void OpenAsync()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                await _connection.OpenAsync();

                if (_connection.State == ConnectionState.Open)
                {
                    System.Console.WriteLine("Database connection opened.");
                }
                else if (_connection.State == ConnectionState.Closed)
                {
                    System.Console.WriteLine("Database connection failed to open.");
                    throw new System.Exception("Database connection failed to open.");
                }
            }
        }

        public void Close()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public bool IsOpen()
        {
            return _connection.State == ConnectionState.Open;
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
