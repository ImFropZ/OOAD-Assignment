using Npgsql;
using server.Models;

namespace server.Services
{
    public class ProductService
    {
        private readonly DatabaseService _databaseService;

        public ProductService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<Product>> Get()
        {
            List<Product> products = new();

            _databaseService.Open();

            NpgsqlDataReader reader = await _databaseService.ExecuteReaderAsync(
                "SELECT id, supplier_id, name, quantity, price, categories FROM products"
            );

            while (await reader.ReadAsync())
            {
                Product product = new Product()
                {
                    ID = reader.GetInt32(0),
                    SupplierID = reader.GetInt32(1),
                    Name = reader.GetString(2),
                    Quantity = reader.GetInt32(3),
                    Price = reader.GetDecimal(4),
                    Categories = reader.GetString(5)
                };

                products.Add(product);
            }

            _databaseService.Close();

            return products;
        }

        public async Task<Product?> Get(int key)
        {
            Product? product = null;

            _databaseService.Open();

            NpgsqlDataReader reader = await _databaseService.ExecuteReaderAsync(
                $"SELECT id, supplier_id, name, quantity, price, categories FROM products WHERE id = {key}"
            );

            if (reader.Read())
            {
                product = new()
                {
                    ID = reader.GetInt32(0),
                    SupplierID = reader.GetInt32(1),
                    Name = reader.GetString(2),
                    Quantity = reader.GetInt32(3),
                    Price = reader.GetDecimal(4),
                    Categories = reader.GetString(5)
                };
            }

            _databaseService.Close();

            return product;
        }

        public async Task<ProductCreated?> Post(ProductCreated product)
        {
            _databaseService.Open();

            await _databaseService.ExecuteNonQueryAsync(
                $"INSERT INTO products (supplier_id, name, quantity, price, categories) VALUES ({product.SupplierID}, '{product.Name}', {product.Quantity}, {product.Price}, '{product.Categories}')"
            );

            _databaseService.Close();

            return product;
        }

        public async Task<List<ProductUpdated>> Put(List<ProductUpdated> products)
        {
            _databaseService.Open();

            foreach (var product in products)
            {
                String updatedProductQuery = $"UPDATE products SET ";

                if (product.SupplierID != null)
                    updatedProductQuery += $"supplier_id = {product.SupplierID}, ";

                if (product.Name != null)
                    updatedProductQuery += $"name = '{product.Name}', ";

                if (product.Quantity != null)
                    updatedProductQuery += $"quantity = {product.Quantity}, ";

                if (product.Price != null)
                    updatedProductQuery += $"price = {product.Price}, ";

                if (product.Categories != null)
                    updatedProductQuery += $"categories = '{product.Categories}', ";

                updatedProductQuery = updatedProductQuery.Remove(updatedProductQuery.Length - 2);
                updatedProductQuery += $" WHERE id = {product.ID}";

                await _databaseService.ExecuteNonQueryAsync(updatedProductQuery);
            }

            _databaseService.Close();

            return products;
        }

        public async Task<ProductUpdated?> Patch(int key, ProductUpdated product)
        {
            _databaseService.Open();

            String updatedProductQuery = $"UPDATE products SET ";

            if (product.SupplierID != null)
                updatedProductQuery += $"supplier_id = {product.SupplierID}, ";

            if (product.Name != null)
                updatedProductQuery += $"name = '{product.Name}', ";

            if (product.Quantity != null)
                updatedProductQuery += $"quantity = {product.Quantity}, ";

            if (product.Price != null)
                updatedProductQuery += $"price = {product.Price}, ";

            if (product.Categories != null)
                updatedProductQuery += $"categories = '{product.Categories}', ";

            updatedProductQuery = updatedProductQuery.Remove(updatedProductQuery.Length - 2);
            updatedProductQuery += $" WHERE id = {product.ID}";

            await _databaseService.ExecuteNonQueryAsync(updatedProductQuery);

            _databaseService.Close();

            return product;
        }

        public Task<bool> Delete(int key)
        {
            _databaseService.Open();

            _databaseService.ExecuteNonQueryAsync($"DELETE FROM products WHERE id = {key}");

            _databaseService.Close();

            return Task<bool>.FromResult(true);
        }
    }
}
