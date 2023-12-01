using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using server.Models;
using Spectre.Console;
using Table = Spectre.Console.Table;

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
            table.AddRow(product.Id ?? "", product.SupplierId ?? "", product.Name ?? "", product.Price + "",
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

        table.AddRow("Generate" + "", product.SupplierId + "", product.Name, product.Price + "",
            product.Quantity + "", product.Categories);

        AnsiConsole.Write(table);
    }

    public void View()
    {
        ProductTableGrid(Program.Products);

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
        System.Console.ReadKey();
        AnsiConsole.Clear();
        Program.ProductView();
    }

    public async Task Add()
    {
        AnsiConsole.MarkupLine("[blue]Add product[/]");

        var name = AnsiConsole.Ask<string>("Products Name?");
        var quantity = AnsiConsole.Ask<int>("Products Quantity?");
        var price = AnsiConsole.Ask<decimal>("Products Price?");
        var categories = AnsiConsole.Ask<string>("Products Categories?[grey]Separate with comma (,)[/]");

        var supplierNames = Program.Suppliers.Select(x => x.Name ?? "").ToArray();

        if (supplierNames.Length == 0)
        {
            AnsiConsole.MarkupLine("[red]No supplier found. Please add supplier first.[/]");
            AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
            System.Console.ReadKey();
            AnsiConsole.Clear();
            Program.ProductView();
        }

        // Select supplier
        var supplierId = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(
                    "[green]Select supplier[/]\n[grey]Navigate with arrow keys up/down and press enter to select.[/]")
                .PageSize(10)
                .AddChoices(supplierNames)
        );

        // Convert from name to id
        supplierId = Program.Suppliers.FirstOrDefault(x => x.Name == supplierId)?.Id ?? "";

        AnsiConsole.MarkupLine("[green]Preview the product details[/]");

        var newProduct = new Product()
        {
            Name = name,
            Quantity = quantity,
            Price = price,
            Categories = categories,
            SupplierId = supplierId
        };

        ProductDetailsView(newProduct);

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");

        System.Console.ReadKey();

        using var client = Program.CreateHttpClient();
        {
            var response = await client.PostAsync("https://localhost:7177/api/products",
                new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                // Log the error message
                System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                
                AnsiConsole.MarkupLine("[red]Failed to add product.[/]");
                AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
                System.Console.ReadKey();
                AnsiConsole.Clear();
                Program.ProductView();
            }
        }

        await Program.FetchData();

        AnsiConsole.Clear();

        Program.ProductView();
    }

    public async Task Remove()
    {
        AnsiConsole.MarkupLine("[blue]Remove product[/]");
        ProductTableGrid(Program.Products);

        var id = AnsiConsole.Ask<string>("Product Id? [grey]Enter -1 to cancel[/]");

        if (id == "-1")
        {
            AnsiConsole.Clear();
            Program.ProductView();
        }

        var product = Program.Products.Find(x => x.Id == id);

        if (product == null)
        {
            AnsiConsole.MarkupLine("[red]Product not found.[/]");
            AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
            System.Console.ReadKey();
            AnsiConsole.Clear();
            Program.ProductView();
        }

        AnsiConsole.MarkupLine("[green]Preview the product details[/]");

        ProductDetailsView(product);

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
        System.Console.ReadKey();

        using var client = Program.CreateHttpClient();
        {
            var response = await client.DeleteAsync($"https://localhost:7177/api/products/{id}");

            if (!response.IsSuccessStatusCode)
            {
                AnsiConsole.MarkupLine("[red]Failed to remove product.[/]");
                AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
                System.Console.ReadKey();
                AnsiConsole.Clear();
                Program.SupplierView();
            }
        }

        await Program.FetchData();

        AnsiConsole.Clear();
        Program.ProductView();
    }

    public async Task Update()
    {
        AnsiConsole.MarkupLine("[blue]Update product[/]");
        ProductTableGrid(Program.Products);

        var id = AnsiConsole.Ask<string>("Product Id? [grey]Enter -1 to cancel[/]");

        if (id == "-1")
        {
            AnsiConsole.Clear();
            Program.ProductView();
        }

        AnsiConsole.MarkupLine("[green]Preview the product details[/]");

        var product = Program.Products.Find(x => x.Id == id);

        if (product == null)
        {
            AnsiConsole.MarkupLine("[red]Product not found.[/]");
            AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
            System.Console.ReadKey();
            AnsiConsole.Clear();
            Program.ProductView();
        }

        ProductDetailsView(product);

        var name = AnsiConsole.Prompt(
            new TextPrompt<string>("[[Optional]] Product Name?").AllowEmpty());
        var categories = AnsiConsole.Prompt(
            new TextPrompt<string>("[[Optional]] Product Categories?[grey]Separate with comma (,)[/]").AllowEmpty());
        var price = AnsiConsole.Prompt(
            new TextPrompt<decimal>("[[Optional]] Product Price? [grey]Input -1 for not update price[/]"));
        var qty = AnsiConsole.Prompt(
            new TextPrompt<int>("[[Optional]] Product Quantity? [grey]Input -1 for not update quantity[/]"));

        var supplierNames = Program.Suppliers.Select(x => x.Name ?? "").ToList();

        if (supplierNames.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No supplier found. Please add supplier first.[/]");
            AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
            System.Console.ReadKey();
            AnsiConsole.Clear();
            Program.ProductView();
        }

        supplierNames.InsertRange(0, new List<string> { "No Update" });

        var supplierId = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(
                    "[green]Select supplier[/]\n[grey]Navigate with arrow keys up/down and press enter to select.[/]")
                .PageSize(10)
                .AddChoices(supplierNames)
        );

        if (supplierId != "No Update")
        {
            supplierId = Program.Suppliers.FirstOrDefault(x => x.Name == supplierId)?.Id ?? "";
        }

        AnsiConsole.MarkupLine("[green]Preview updated product details[/]");

        var updatedProduct = new Product()
        {
            Id = product.Id,
            SupplierId = supplierId == "Not Update" ? product.SupplierId : supplierId,
            Name = name == "" ? product.Name : name,
            Price = price == -1 ? product.Price : price,
            Quantity = qty == -1 ? product.Quantity : qty,
            Categories = categories == "" ? product.Categories : categories
        };

        ProductDetailsView(updatedProduct);

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
        System.Console.ReadKey();

        using (var client = Program.CreateHttpClient())
        {
            var response = await client.PutAsync($"https://localhost:7177/api/products/{id}",
                new StringContent(JsonConvert.SerializeObject(updatedProduct), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                AnsiConsole.MarkupLine("[red]Failed to update product.[/]");
                AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
                System.Console.ReadKey();
                AnsiConsole.Clear();
                Program.SupplierView();
            }
        }

        await Program.FetchData();

        AnsiConsole.Clear();
        Program.ProductView();
    }
}