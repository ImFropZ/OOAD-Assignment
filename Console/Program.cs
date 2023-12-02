using Console.Models;
using Newtonsoft.Json;
using Spectre.Console;

namespace Console;

public static class Program
{
    public static string URI = "https://localhost:44358/api";

    public static List<Product> Products;
    public static List<Supplier> Suppliers;

    public static HttpClient CreateHttpClient()
    {
        HttpClientHandler handler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };

        HttpClient client = new HttpClient(handler);
        return client;
    }

    static async Task<List<Product>> GetProducts(string apiUrl)
    {
        using var client = CreateHttpClient();
        var response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<Result<List<Product>>>(jsonString);

            // Assuming ApiResponse class has a Data property of type List<Product>
            return apiResponse?.Data ?? new List<Product>();
        }
        else
        {
            throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
        }
    }

    static async Task<List<Supplier>> GetSuppliers(string apiUrl)
    {
        using var client = CreateHttpClient();
        var response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<Result<List<Supplier>>>(jsonString);

            // Assuming ApiResponse class has a Data property of type List<Product>
            return apiResponse?.Data ?? new List<Supplier>();
        }
        else
        {
            throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
        }
    }


    public static async Task FetchData()
    {
        var products = await GetProducts($"{URI}/products");
        var suppliers = await GetSuppliers($"{URI}/suppliers");

        Products = products;
        Suppliers = suppliers;
    }

    public static void Main(string[] args)
    {
        FetchData().Wait();

        AnsiConsole.MarkupLine("[blue]Welcome to the Small Inventory System![/]");
        AnsiConsole.Clear();
        MainMenu();
    }

    public static void MainMenu()
    {
        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(
                    "[green]What do you want to do?[/]\n[grey]Navigate with arrow keys up/down and press enter to select.[/]")
                .AddChoices(new[]
                {
                    "Product", "Supplier", "[red]Exit[/]"
                }));

        switch (mode)
        {
            case ("Product"):
                ProductView();
                break;
            case ("Supplier"):
                SupplierView();
                break;
            case ("Exit"):
                Environment.Exit(0);
                break;
        }
    }

    public static void ProductView()
    {
        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(
                    "[green]What do you want to do?[/]\n[grey]Navigate with arrow keys up/down and press enter to select.[/]")
                .AddChoices(new[]
                {
                    "View", "Add", "Remove", "Update", "[green]Back into main menu[/]", "[red]Exit[/]"
                }));

        switch (mode)
        {
            case ("View"):
                new ProductActions().View();
                break;
            case ("Add"):
                new ProductActions().Add().Wait();
                break;
            case ("Remove"):
                new ProductActions().Remove().Wait();
                break;
            case ("Update"):
                new ProductActions().Update().Wait();
                break;
            case ("[green]Back into main menu[/]"):
                MainMenu();
                break;
            case ("[red]Exit[/]"):
                Environment.Exit(0);
                break;
        }
    }

    public static void SupplierView()
    {
        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(
                    "[green]What do you want to do?[/]\n[grey]Navigate with arrow keys up/down and press enter to select.[/]")
                .AddChoices(new[]
                {
                    "View", "Add", "Remove", "Update", "[green]Back into main menu[/]", "[red]Exit[/]"
                }));

        switch (mode)
        {
            case ("View"):
                new SupplierActions().View();
                break;
            case ("Add"):
                new SupplierActions().Add().Wait();
                break;
            case ("Remove"):
                new SupplierActions().Remove().Wait();
                break;
            case ("Update"):
                new SupplierActions().Update().Wait();
                break;
            case ("[green]Back into main menu[/]"):
                MainMenu();
                break;
            case ("[red]Exit[/]"):
                Environment.Exit(0);
                break;
        }
    }
}
