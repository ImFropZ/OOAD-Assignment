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
                _databaseService.Open();

                NpgsqlDataReader reader = await _databaseService.ExecuteReaderAsync(
                    "SELECT id, supplier_id, name, quantity, price, categories FROM products"
                );

                while (await reader.ReadAsync())
                {
                    Product product =
                        new(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetDecimal(4),
                            reader.GetString(5)
                        );

                    products.Add(product);
                }

                _databaseService.Close();
            }
            catch (Exception)
            {
                if (_databaseService.IsOpen())
                    _databaseService.Close();
            }

            return products;
        }

        public async Task<Product?> GetProductById(int key)
        {
            Product? product = null;
            try
            {
                _databaseService.Open();

                NpgsqlDataReader reader = await _databaseService.ExecuteReaderAsync(
                    $"SELECT id, supplier_id, name, quantity, price, categories FROM products WHERE id = {key}"
                );

                if (reader.Read())
                {
                    product = new(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetDecimal(4),
                        reader.GetString(5)
                    );
                }

                _databaseService.Close();
            }
            catch (Exception)
            {
                if (_databaseService.IsOpen())
                    _databaseService.Close();
            }

            return product;
        }

        public async Task<Product?> AddProduct(ProductCreated product)
        {
            Product createdProduct;
            try
            {
                _databaseService.Open();

                await _databaseService.ExecuteNonQueryAsync(
                    $"INSERT INTO products (supplier_id, name, quantity, price, categories) VALUES ({product.SupplierID}, '{product.Name}', {product.Quantity}, {product.Price}, '{product.Categories}')"
                );

                var reader = await _databaseService.ExecuteReaderAsync(
                    $"SELECT id, supplier_id, name, quantity, price, categories FROM products WHERE id = (SELECT MAX(id) FROM products)"
                );

                if (!reader.Read())
                {
                    _databaseService.Close();
                    return null;
                }

                createdProduct =
                    new(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetDecimal(4),
                        reader.GetString(5)
                    );

                _databaseService.Close();
            }
            catch (Exception)
            {
                if (_databaseService.IsOpen())
                    _databaseService.Close();
                return null;
            }

            return createdProduct;
        }

        public async Task<List<Product>> UpdateProducts(List<ProductUpdated> products)
        {
            var updatedProducts = new List<Product>();
            try
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

                    var reader = await _databaseService.ExecuteReaderAsync(
                        $"SELECT id, supplier_id, name, quantity, price, categories FROM products WHERE id = {product.ID}"
                    );

                    if (!reader.Read())
                        continue;

                    Product updatedProduct =
                        new(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetDecimal(4),
                            reader.GetString(5)
                        );

                    updatedProducts.Add(updatedProduct);
                }

                _databaseService.Close();
            }
            catch (Exception)
            {
                if (_databaseService.IsOpen())
                    _databaseService.Close();
            }

            return updatedProducts;
        }

        public async Task<Product?> UpdateProductById(int key, ProductUpdated product)
        {
            Product updatedProduct;
            try
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

                var reader = await _databaseService.ExecuteReaderAsync(
                    $"SELECT id, supplier_id, name, quantity, price, categories FROM products WHERE id = {key}"
                );

                if (!reader.Read())
                {
                    _databaseService.Close();
                    return null;
                }

                updatedProduct =
                    new(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetDecimal(4),
                        reader.GetString(5)
                    );

                _databaseService.Close();
            }
            catch (Exception)
            {
                if (_databaseService.IsOpen())
                    _databaseService.Close();
                return null;
            }

            return updatedProduct;
        }

        public Task<bool> DeleteProduct(int key)
        {
            try
            {
                _databaseService.Open();
                _databaseService.ExecuteNonQueryAsync($"DELETE FROM products WHERE id = {key}");
                _databaseService.Close();
            }
            catch (Exception)
            {
                if (_databaseService.IsOpen())
                    _databaseService.Close();
                return Task<bool>.FromResult(false);
            }

            return Task<bool>.FromResult(true);
        }
    }
}
