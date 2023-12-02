using Microsoft.EntityFrameworkCore;
using server.Exceptions;
using server.Models;

namespace server.Services
{
    public class ProductService
    {
        private readonly IDbContext _context;

        public ProductService(IDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            var products = _context.Products?.ToList();
            return products ?? new List<Product>();
        }

        public Product? GetProductById(string id)
        {
            var product = _context
                              .Products?
                              .Where(p => p.Id == id)
                              .FirstOrDefault() ??
                          throw new NotFoundException("Product not found");

            return product;
        }

        public async Task<Product> AddProduct(ProductCreated product)
        {
            // Check if supplier exists
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == product.SupplierId);

            if (supplier == null)
                throw new NotFoundException($"Supplier with ID {product.SupplierId} not found");

            var newProduct = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                SupplierId = product.SupplierId,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Categories = product.Categories,
                Supplier = supplier
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges(); // Use asynchronous SaveChanges

            // Delete field supplier's products
            if (newProduct.Supplier != null)
                newProduct.Supplier.Products = null;

            return newProduct;
        }

        public async Task<List<Product>> UpdateProducts(List<ProductUpdated> products)
        {
            var updatedProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.Id == null) continue;

                try
                {
                    var updatedProduct = await this.UpdateProductById(product.Id, product);
                    if (updatedProduct != null)
                        updatedProducts.Add(updatedProduct);

                }
                catch (Exception)
                {
                }
            }

            return updatedProducts;
        }

        public async Task<Product?> UpdateProductById(string id, ProductUpdated product)
        {
            if (product.SupplierId == null &&
                product.Name == null &&
                product.Quantity == null &&
                product.Price == null &&
                product.Categories == null
            ) throw new BadRequestException("No fields to update");


            var updatedProduct = (_context.Products?.FirstOrDefault(p => p.Id == id)) ?? throw new NotFoundException("Product not found");

            if (product.SupplierId != null)
            {
                // Check if supplier exists
                var supplier = _context
                    .Suppliers?
                    .FirstOrDefault(s => s.Id == product.SupplierId);

                // Check if supplier is null and there are no other field left to update
                if (supplier == null &&
                    product.Name == null &&
                    product.Quantity == null &&
                    product.Price == null &&
                    product.Categories == null
                ) throw new BadRequestException("No supplier matches the ID given.");

                if (supplier != null)
                    updatedProduct.SupplierId = product.SupplierId;
            }
            if (product.Name != null) updatedProduct.Name = product.Name;
            if (product.Quantity != null) updatedProduct.Quantity = product.Quantity ?? 0;
            if (product.Price != null) updatedProduct.Price = product.Price ?? 0;
            if (product.Categories != null) updatedProduct.Categories = product.Categories;

            _context.SaveChanges();
            return updatedProduct;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            var product = _context.Products?.FirstOrDefault(p => p.Id == id) ?? throw new NotFoundException("Product not found");

            _context.Products?.Remove(product);
            _context.SaveChanges();
            return true;
        }
    }
}
