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

    public Product(
        int id,
        int supplierID,
        String name,
        int quantity,
        decimal price,
        String categories
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
    public int SupplierID { get; set; }
    public String Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public String Categories { get; set; }

    public ProductCreated(
        int supplierID,
        String name,
        int quantity,
        decimal price,
        String categories
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
    public int ID { get; set; }
    public int? SupplierID { get; set; }
    public String? Name { get; set; }
    public int? Quantity { get; set; }
    public decimal? Price { get; set; }
    public String? Categories { get; set; }
}
