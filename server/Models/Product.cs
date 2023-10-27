namespace server.Models
{
    public class Product
    {
        public string ID { get; set; }
        public string SupplierID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Categories { get; set; }

        public Product(
            string id,
            string supplierID,
            string name,
            int quantity,
            decimal price,
            string categories
        )
        {
            ID = id;
            SupplierID = supplierID;
            Name = name;
            Quantity = quantity;
            Price = price;
            Categories = categories;
        }
    }

    public class ProductCreated
    {
        public string SupplierID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Categories { get; set; }

        public ProductCreated(
            string supplierID,
            string name,
            int quantity,
            decimal price,
            string categories
        )
        {
            SupplierID = supplierID;
            Name = name;
            Quantity = quantity;
            Price = price;
            Categories = categories;
        }
    }

    public class ProductUpdated
    {
        public string? ID { get; set; }
        public string? SupplierID { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? Categories { get; set; }
    }
}