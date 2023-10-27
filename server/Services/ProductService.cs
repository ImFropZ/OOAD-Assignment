using server.Data;
using server.Models;

namespace server.Services
{
    public class ProductService
    {
        private readonly InventoryDbContext _service;

        public ProductService(InventoryDbContext service)
        {
            _service = service;
        }

        public List<Product> GetProducts()
        {
            var products = _service.Products?.ToList();
            return products ?? new List<Product>();
        }

        public Product? GetProductById(string id)
        {
            var product = _service.Products?.Where(p => p.ID == id).FirstOrDefault();
            return product;
        }

        public async Task<Product?> AddProduct(ProductCreated product)
        {
            // Check if supplier exists
            var supplier = _service.Suppliers?.FirstOrDefault(s => s.ID == product.SupplierID);
            if (supplier == null) return null;

            var newProduct = new Product()
            {
                ID = Guid.NewGuid().ToString(),
                SupplierID = product.SupplierID,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Categories = product.Categories
            };

            _service.Products?.Add(newProduct);
            await _service.SaveChangesAsync();
            return newProduct;
        }

        public async Task<List<Product>> UpdateProducts(List<ProductUpdated> products)
        {
            var updatedProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.ID == null) continue;
                var updatedProduct = await this.UpdateProductById(product.ID, product);
                if (updatedProduct != null)
                    updatedProducts.Add(updatedProduct);
            }

            return updatedProducts;
        }

        public async Task<Product?> UpdateProductById(string id, ProductUpdated product)
        {
            var updatedProduct = _service.Products?.FirstOrDefault(p => p.ID == id);

            if (updatedProduct != null)
            {
                if (product.SupplierID != null) updatedProduct.SupplierID = product.SupplierID;
                if (product.Name != null) updatedProduct.Name = product.Name;
                if (product.Quantity != null) updatedProduct.Quantity = product.Quantity ?? 0;
                if (product.Price != null) updatedProduct.Price = product.Price ?? 0;
                if (product.Categories != null) updatedProduct.Categories = product.Categories;

                await _service.SaveChangesAsync();
            }

            return updatedProduct;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            var product = _service.Products?.FirstOrDefault(p => p.ID == id);

            if (product != null)
            {
                _service.Products?.Remove(product);
                await _service.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
