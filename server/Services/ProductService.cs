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

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = new();

            try
            {
                await _databaseService.OpenAsync();

                NpgsqlDataReader reader = await _databaseService.ExecuteReaderAsync(
                    "SELECT id, supplier_id, name, quantity, price, categories FROM products"
                );

                while (await reader.ReadAsync())
                {
                    Product product =
                        new(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetDecimal(4),
                            reader.GetString(5)
                        );

                    products.Add(product);
                }

                _databaseService.CloseAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _databaseService.DisposeAsync();
            }
            return products;
        }

        public async Task<Product?> GetProductById(string id)
        {
            Product? product = null;

            try
            {
                await _databaseService.OpenAsync();

                NpgsqlDataReader reader = await _databaseService.ExecuteReaderAsync(
                    $"SELECT id, supplier_id, name, quantity, price, categories FROM products WHERE id = '{id}'"
                );

                if (reader.Read())
                {
                    product = new(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetDecimal(4),
                        reader.GetString(5)
                    );
                }

                _databaseService.CloseAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _databaseService.DisposeAsync();
            }

            return product;
        }

        public async Task<Product?> AddProduct(ProductCreated product)
        {
            Product? createdProduct = null;

            try
            {
                await _databaseService.OpenAsync();

                string uid = new Utils().GenerateUUID();

                await _databaseService.ExecuteNonQueryAsync(
                    $"INSERT INTO products (id, supplier_id, name, quantity, price, categories) VALUES ('{uid}', {product.SupplierID}, '{product.Name}', {product.Quantity}, {product.Price}, '{product.Categories}')"
                );

                var reader = await _databaseService.ExecuteReaderAsync(
                    $"SELECT id, supplier_id, name, quantity, price, categories FROM products WHERE id = '{uid}'"
                );

                if (!reader.Read())
                {
                    _databaseService.CloseAsync();
                    return null;
                }

                createdProduct =
                    new(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetDecimal(4),
                        reader.GetString(5)
                    );

                _databaseService.CloseAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _databaseService.DisposeAsync();
            }

            return createdProduct;
        }

        public async Task<List<Product>> UpdateProducts(List<ProductUpdated> products)
        {
            var updatedProducts = new List<Product>();
            foreach (var product in products)
            {
                String updatedProductQuery = $"UPDATE products SET ";

                if (product.SupplierID != null)
                    updatedProductQuery += $"supplier_id = '{product.SupplierID}', ";
                if (product.Name != null)
                    updatedProductQuery += $"name = '{product.Name}', ";
                if (product.Quantity != null)
                    updatedProductQuery += $"quantity = {product.Quantity}, ";
                if (product.Price != null)
                    updatedProductQuery += $"price = {product.Price}, ";
                if (product.Categories != null)
                    updatedProductQuery += $"categories = '{product.Categories}', ";

                updatedProductQuery = updatedProductQuery.Remove(updatedProductQuery.Length - 2);
                updatedProductQuery += $" WHERE id = '{product.ID}'";

                try
                {
                    await _databaseService.OpenAsync();

                    await _databaseService.ExecuteNonQueryAsync(updatedProductQuery);
                    var reader = await _databaseService.ExecuteReaderAsync(
                        $"SELECT id, supplier_id, name, quantity, price, categories FROM products WHERE id = '{product.ID}'"
                    );

                    if (!reader.Read())
                        continue;

                    Product updatedProduct =
                        new(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetDecimal(4),
                            reader.GetString(5)
                        );

                    _databaseService.CloseAsync();
                    updatedProducts.Add(updatedProduct);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _databaseService.DisposeAsync();
                }
            }

            return updatedProducts;
        }

        public async Task<Product?> UpdateProductById(string id, ProductUpdated product)
        {
            Product? updatedProduct = null;

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
            updatedProductQuery += $" WHERE id = '{id}'";

            try
            {
                await _databaseService.OpenAsync();

                await _databaseService.ExecuteNonQueryAsync(updatedProductQuery);

                var reader = await _databaseService.ExecuteReaderAsync(
                    $"SELECT id, supplier_id, name, quantity, price, categories FROM products WHERE id = '{id}'"
                );

                if (!reader.Read())
                    return null;

                updatedProduct =
                    new(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetDecimal(4),
                        reader.GetString(5)
                    );

                _databaseService.CloseAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _databaseService.DisposeAsync();
            }
            return updatedProduct;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            try
            {
                await _databaseService.OpenAsync();
                await _databaseService.ExecuteNonQueryAsync($"DELETE FROM products WHERE id = '{id}'");
                _databaseService.CloseAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _databaseService.DisposeAsync();
            }

            return true;
        }
    }
}
