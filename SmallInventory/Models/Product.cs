namespace WinForm.Models
{
    public class Product
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
        public string? SupplierId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Categories { get; set; }
    }

    public class ProductUpdated
    {
        public string? Id { get; set; }
        public string? SupplierId { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? Categories { get; set; }
    }
}