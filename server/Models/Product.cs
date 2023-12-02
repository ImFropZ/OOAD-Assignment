using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Product
    {
        [Required, Key] public string? Id { get; set; }
        [Required, ForeignKey("SupplierID")] public string? SupplierId { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public int Quantity { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")] public decimal Price { get; set; }
        [Required] public string? Categories { get; set; }
        public Supplier? Supplier { get; set; }
    }

    public class ProductResponse
    {
        public string? Id { get; set; }
        public string? SupplierId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Categories { get; set; }
    }

    public class ProductCreated
    {
        [Required] public string? SupplierId { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public int Quantity { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")] public decimal Price { get; set; }
        [Required] public string? Categories { get; set; }
    }

    public class ProductUpdated
    {
        public string? Id { get; set; }
        [ForeignKey("SupplierID")] public string? SupplierId { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? Price { get; set; }
        public string? Categories { get; set; }
    }
}