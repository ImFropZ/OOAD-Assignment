using server.Models;
using Spectre.Console;

namespace Console;

public class ProductActions
{
    public void ProductTableGrid(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Supplier Id");
        table.AddColumn("Name");
        table.AddColumn("Price");
        table.AddColumn("Quantity");
        table.AddColumn("Categories");


        foreach (var product in products)
        {
            table.AddRow(product.ID ?? "", product.SupplierID ?? "", product.Name ?? "", product.Price + "",
                product.Quantity + "", product.Categories ?? "");
        }

        AnsiConsole.Write(table);
    }

    public void ProductDetailsView(Product product)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Supplier Id");
        table.AddColumn("Name");
        table.AddColumn("Price");
        table.AddColumn("Quantity");
        table.AddColumn("Categories");

        table.AddRow("Generate" + "", product.SupplierID + "", product.Name, product.Price + "",
            product.Quantity + "", product.Categories);

        AnsiConsole.Write(table);
    }

    public void Add()
    {
        AnsiConsole.MarkupLine("[blue]Add product[/]");

        var name = AnsiConsole.Ask<string>("Products Name?");
        var quantity = AnsiConsole.Ask<int>("Products Quantity?");
        var price = AnsiConsole.Ask<decimal>("Products Price?");
        var categories = AnsiConsole.Ask<string>("Products Categories?[grey]Separate with comma (,)[/]");

        // Select supplier
        var supplierId = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(
                    "[green]Select supplier[/]\n[grey]Navigate with arrow keys up/down and press enter to select.[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "Supplier 1", "Supplier 2", "Supplier 3", "Supplier 4", "Supplier 5", "Supplier 6", "Supplier 7",
                    "Supplier 8", "Supplier 9", "Supplier 10"
                }));

        AnsiConsole.MarkupLine("[green]Preview the product details[/]");

        ProductDetailsView(new Product()
        {
            Name = name,
            Quantity = quantity,
            Price = price,
            Categories = categories,
            SupplierID = supplierId
        });

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");

        System.Console.ReadKey();

        AnsiConsole.Clear();

        Program.ProductView();
    }

    public void Remove()
    {
        AnsiConsole.MarkupLine("[blue]Remove product[/]");
        // TODO:
        var products = new List<Product>();

        for (var i = 0; i < 10; i++)
        {
            products.Add(new Product()
            {
                ID = i + "",
                SupplierID = "SUP-" + i,
                Name = $"Product - {i}", Price = 50,
                Categories = $"Categories - {i}", Quantity = 50
            });
        }

        ProductTableGrid(products);

        var id = AnsiConsole.Ask<string>("Product Id? [grey]Enter -1 to cancel[/]");

        if (id == "-1")
        {
            AnsiConsole.Clear();
            Program.ProductView();
        }

        AnsiConsole.MarkupLine("[green]Preview the product details[/]");

        // TODO: Fake products
        ProductDetailsView(new Product()
        {
            ID = id,
            SupplierID = "Example",
            Name = "Example",
            Categories = "Example",
            Price = 10,
            Quantity = 20
        });

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
        System.Console.ReadKey();

        AnsiConsole.Clear();

        Program.ProductView();
    }

    public void Update()
    {
        AnsiConsole.MarkupLine("[blue]Update product[/]");
        // TODO:
        var products = new List<Product>();

        for (var i = 0; i < 10; i++)
        {
            products.Add(new Product()
            {
                ID = i + "",
                SupplierID = "SUP-" + i,
                Name = $"Product - {i}", Price = 50,
                Categories = $"Categories - {i}", Quantity = 50
            });
        }

        ProductTableGrid(products);

        var id = AnsiConsole.Ask<string>("Product Id? [grey]Enter -1 to cancel[/]");

        if (id == "-1")
        {
            AnsiConsole.Clear();
            Program.ProductView();
        }

        AnsiConsole.MarkupLine("[green]Preview the product details[/]");

        // TODO: Fake products
        ProductDetailsView(new Product()
        {
            ID = id,
            SupplierID = "Example",
            Name = "Example",
            Categories = "Example",
            Price = 10,
            Quantity = 20
        });

        var name = AnsiConsole.Prompt(
            new TextPrompt<string>("[[Optional]] Product Name?").AllowEmpty());
        var categories = AnsiConsole.Prompt(
            new TextPrompt<string>("[[Optional]] Product Categories?[grey]Separate with comma (,)[/]").AllowEmpty());
        var price = AnsiConsole.Prompt(
            new TextPrompt<decimal>("[[Optional]] Product Price? [grey]Input -1 for not update price[/]"));
        var qty = AnsiConsole.Prompt(
            new TextPrompt<int>("[[Optional]] Product Quantity? [grey]Input -1 for not update quantity[/]"));

        var supplierId = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(
                    "[green]Select supplier[/]\n[grey]Navigate with arrow keys up/down and press enter to select.[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "Not Update", "Supplier 1", "Supplier 2", "Supplier 3", "Supplier 4", "Supplier 5", "Supplier 6",
                    "Supplier 7",
                    "Supplier 8", "Supplier 9", "Supplier 10"
                }));

        AnsiConsole.MarkupLine("[green]Preview updated product details[/]");

        ProductDetailsView(new Product()
        {
            ID = id,
            SupplierID = supplierId == "Not Update" ? "Example" : supplierId,
            Name = name == "" ? "Example" : name,
            Price = price == -1 ? 10 : price,
            Quantity = qty == -1 ? 20 : qty,
            Categories = categories == "" ? "Example" : categories
        });

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
        System.Console.ReadKey();
        
        AnsiConsole.Clear();
        Program.ProductView();
    }
}