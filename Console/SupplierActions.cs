using Console.Models;
using Newtonsoft.Json;
using Spectre.Console;
using System.Text;

namespace Console;

public class SupplierActions
{
    public void SupplierTableGrid(List<Supplier> suppliers)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Contact Information");

        foreach (var supplier in suppliers)
        {
            table.AddRow(supplier.Id ?? "", supplier.Name ?? "", supplier.ContactInformation ?? "");
        }

        AnsiConsole.Write(table);
    }

    public void SupplierDetailsView(Supplier supplier)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Contact Information");

        table.AddRow(supplier.Id ?? "Generate", supplier.Name ?? "", supplier.ContactInformation ?? "");

        AnsiConsole.Write(table);
    }

    public void View()
    {
        SupplierTableGrid(Program.Suppliers);

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
        System.Console.ReadKey();
        AnsiConsole.Clear();
        Program.SupplierView();
    }

    public async Task Add()
    {
        AnsiConsole.MarkupLine("[blue]Add supplier[/]");

        var name = AnsiConsole.Ask<string>("Supplier Name?");
        var contactInformation = AnsiConsole.Ask<string>("Supplier Contact Information?");

        AnsiConsole.MarkupLine("[green]Preview the supplier details[/]");

        var newSupplier = new Supplier()
        {
            Name = name,
            ContactInformation = contactInformation
        };

        SupplierDetailsView(newSupplier);

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
        System.Console.ReadKey();

        using var client = Program.CreateHttpClient();
        {
            var response = await client.PostAsync($"{Program.URI}/Suppliers",
                new StringContent(JsonConvert.SerializeObject(newSupplier), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                AnsiConsole.MarkupLine("[red]Failed to add supplier.[/]");
                AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
                System.Console.ReadKey();
                AnsiConsole.Clear();
                Program.SupplierView();
            }
        }

        await Program.FetchData();

        AnsiConsole.Clear();
        Program.SupplierView();
    }

    public async Task Remove()
    {
        AnsiConsole.MarkupLine("[blue]Remove supplier[/]");
        SupplierTableGrid(Program.Suppliers);

        var id = AnsiConsole.Ask<string>("Supplier Id? [grey]Enter -1 to cancel[/]");

        if (id == "-1")
        {
            AnsiConsole.Clear();
            Program.SupplierView();
        }

        AnsiConsole.MarkupLine("[green]Preview the supplier details[/]");

        var found = Program.Suppliers.Find(x => x.Id == id);

        if (found == null)
        {
            AnsiConsole.MarkupLine("[red]Supplier not found.[/]");
            AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
            System.Console.ReadKey();
            AnsiConsole.Clear();
            Program.SupplierView();
        }

        SupplierDetailsView(found);

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
        System.Console.ReadKey();

        using var client = Program.CreateHttpClient();
        {
            var response = await client.DeleteAsync($"{Program.URI}/Suppliers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                AnsiConsole.MarkupLine("[red]Failed to remove supplier.[/]");
                AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
                System.Console.ReadKey();
                AnsiConsole.Clear();
                Program.SupplierView();
            }
        }

        await Program.FetchData();

        AnsiConsole.Clear();
        Program.SupplierView();
    }

    public async Task Update()
    {
        AnsiConsole.MarkupLine("[blue]Update supplier[/]");
        SupplierTableGrid(Program.Suppliers);

        var id = AnsiConsole.Ask<string>("Supplier Id? [grey]Enter -1 to cancel[/]");

        if (id == "-1")
        {
            AnsiConsole.Clear();
            Program.ProductView();
        }

        AnsiConsole.MarkupLine("[green]Preview the product details[/]");

        var found = Program.Suppliers.Find(x => x.Id == id);

        if (found == null)
        {
            AnsiConsole.MarkupLine("[red]Supplier not found.[/]");
            AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
            System.Console.ReadKey();
            AnsiConsole.Clear();
            Program.SupplierView();
        }

        SupplierDetailsView(found);

        var name = AnsiConsole.Prompt(
            new TextPrompt<string>("[[Optional]] Supplier Name?").AllowEmpty());
        var contactInformation = AnsiConsole.Prompt(
            new TextPrompt<string>("[[Optional]] Supplier Contact Information?").AllowEmpty());

        AnsiConsole.MarkupLine("[green]Preview update supplier details[/]");

        var updatedSupplier = new SupplierUpdated()
        {
            Name = name == "" ? found.Name : name,
            ContactInformation = contactInformation == "" ? found.ContactInformation : contactInformation
        };

        SupplierDetailsView(new()
        {
            Id = found.Id,
            Name = updatedSupplier.Name,
            ContactInformation = updatedSupplier.ContactInformation
        });

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
        System.Console.ReadKey();

        using var client = Program.CreateHttpClient();
        {
            var response = await client.PatchAsync($"{Program.URI}/Suppliers/{id}",
                new StringContent(JsonConvert.SerializeObject(updatedSupplier), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                AnsiConsole.MarkupLine("[red]Failed to update supplier.[/]");
                AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
                System.Console.ReadKey();
                AnsiConsole.Clear();
                Program.SupplierView();
            }
        }

        await Program.FetchData();

        AnsiConsole.Clear();
        Program.SupplierView();
    }
}