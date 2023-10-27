using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Product
    {
        [Required, Key] public string? ID { get; set; }
        [Required, ForeignKey("SupplierID")] public string? SupplierID { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public int Quantity { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")] public decimal Price { get; set; }
        [Required] public string? Categories { get; set; }
    }

    public class ProductCreated
    {
        [Required] public string? SupplierID { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public int Quantity { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")] public decimal Price { get; set; }
        [Required] public string? Categories { get; set; }
    }

    public class ProductUpdated
    {
        public string? ID { get; set; }
        [ForeignKey("SupplierID")] public string? SupplierID { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? Price { get; set; }
        public string? Categories { get; set; }
    }
}