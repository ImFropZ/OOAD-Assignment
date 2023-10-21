using System;

namespace server.Models;

public class Product
{
    public int ID { get; set; }
    public int SupplierID { get; set; }
    public String Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public String Categories { get; set; }
}

public class ProductCreated
{
    public int SupplierID { get; set; }
    public String Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public String Categories { get; set; }
}

public class ProductUpdated
{
    public int ID { get; set; }
    public int? SupplierID { get; set; }
    public String? Name { get; set; }
    public int? Quantity { get; set; }
    public decimal? Price { get; set; }
    public String? Categories { get; set; }
}
