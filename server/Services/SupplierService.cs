using Npgsql;
using server.Models;

namespace server.Services
{
    public class SupplierService
    {
        private readonly DatabaseService _databaseService;

        public SupplierService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<Supplier>> GetSuppliers()
        {
            List<Supplier> suppliers = new();

            NpgsqlDataReader reader = await _databaseService.ExecuteReaderAsync(
                "SELECT id, name, contact_information FROM suppliers"
            );

            while (await reader.ReadAsync())
            {
                Supplier supplier =
                    new(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                suppliers.Add(supplier);
            }

            return suppliers;
        }

        public async Task<Supplier?> GetSupplier(int id)
        {
            NpgsqlDataReader reader = await _databaseService.ExecuteReaderAsync(
                $"SELECT id, name, contact_information FROM suppliers WHERE id = {id}"
            );

            if (reader.Read())
            {
                Supplier supplier =
                    new(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                return supplier;
            }

            return null;
        }

        public async Task<Supplier?> AddSupplier(SupplierCreated supplier)
        {
            await _databaseService.ExecuteNonQueryAsync(
                $"INSERT INTO suppliers (id, name, contact_information) VALUES ('{new Utils().GenerateUUID()}', '{supplier.Name}', '{supplier.ContactInformation}') RETURNING id, name, contact_information"
            );

            NpgsqlDataReader reader = await _databaseService.ExecuteReaderAsync(
                $"SELECT id, name, contact_information FROM suppliers WHERE name = '{supplier.Name}' AND contact_information = '{supplier.ContactInformation}'"
            );

            if (reader.Read())
            {
                Supplier createdSupplier =
                    new(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                return createdSupplier;
            }

            return null;
        }

        public async Task<Supplier?> UpdateSupplier(int id, SupplierUpdated supplier)
        {
            string updateQuery = "UPDATE suppliers SET ";
            if (supplier.Name == null && supplier.ContactInformation == null)
                return null;

            if (supplier.Name != null)
                updateQuery += $"name = '{supplier.Name}', ";
            if (supplier.ContactInformation != null)
                updateQuery += $"contact_information = '{supplier.ContactInformation}', ";

            updateQuery = updateQuery.Remove(updateQuery.Length - 2);
            updateQuery += $" WHERE id = {id}";

            await _databaseService.ExecuteNonQueryAsync(updateQuery);

            NpgsqlDataReader reader = await _databaseService.ExecuteReaderAsync(
                $"SELECT id, name, contact_information FROM suppliers WHERE id = {id}"
            );

            if (reader.Read())
            {
                Supplier updatedSupplier =
                    new(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                return updatedSupplier;
            }

            return null;
        }

        public async Task<List<Supplier>> UpdateSuppliers(List<SupplierUpdated> suppliers)
        {
            List<Supplier> updatedSuppliers = new();
            foreach (SupplierUpdated supplier in suppliers)
            {
                Supplier? updatedSupplier = await UpdateSupplier(
                    supplier.ID,
                    new SupplierUpdated(supplier.ID, supplier.Name, supplier.ContactInformation)
                );
                if (updatedSupplier != null)
                {
                    updatedSuppliers.Add(updatedSupplier);
                }
            }
            return updatedSuppliers;
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            await _databaseService.ExecuteNonQueryAsync(
                $"DELETE FROM suppliers WHERE id = {id}"
            );
            return false;
        }
    }
}
