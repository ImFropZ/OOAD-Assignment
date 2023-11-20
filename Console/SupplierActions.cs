using server.Models;
using Spectre.Console;

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
            table.AddRow(supplier.ID ?? "", supplier.Name ?? "", supplier.ContactInformation ?? "");
        }

        AnsiConsole.Write(table);
    }

    public void SupplierDetailsView(Supplier supplier)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Contact Information");

        table.AddRow(supplier.ID ?? "Generate", supplier.Name ?? "", supplier.ContactInformation ?? "");

        AnsiConsole.Write(table);
    }

    public void Add()
    {
        AnsiConsole.MarkupLine("[blue]Add supplier[/]");

        var name = AnsiConsole.Ask<string>("Supplier Name?");
        var contactInformation = AnsiConsole.Ask<string>("Supplier Contact Information?");

        AnsiConsole.MarkupLine("[green]Preview the supplier details[/]");

        SupplierDetailsView(new Supplier()
        {
            Name = name,
            ContactInformation = contactInformation
        });

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");

        System.Console.ReadKey();

        AnsiConsole.Clear();

        Program.SupplierView();
    }

    public void Remove()
    {
        AnsiConsole.MarkupLine("[blue]Remove supplier[/]");
        var suppliers = new List<Supplier>();

        // TODO: Supplier api
        for (var i = 0; i < 10; i++)
        {
            suppliers.Add(new Supplier()
            {
                ID = i + "",
                Name = $"Example Name - {i}",
                ContactInformation = $"Example Contact Information - {i}"
            });
        }

        SupplierTableGrid(suppliers);

        var id = AnsiConsole.Ask<string>("Supplier Id? [grey]Enter -1 to cancel[/]");

        if (id == "-1")
        {
            AnsiConsole.Clear();
            Program.SupplierView();
        }

        AnsiConsole.MarkupLine("[green]Preview the supplier details[/]");

        // TODO: Fake Supplier
        SupplierDetailsView(new Supplier()
        {
            ID = id,
            Name = "Example",
            ContactInformation = "Example Information"
        });

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
        System.Console.ReadKey();

        AnsiConsole.Clear();

        Program.SupplierView();
    }

    public void Update()
    {
        AnsiConsole.MarkupLine("[blue]Update supplier[/]");
        // TODO:
        var suppliers = new List<Supplier>();

        for (var i = 0; i < 10; i++)
        {
            suppliers.Add(new Supplier()
            {
                ID = i + "",
                Name = $"Product - {i}",
                ContactInformation = $"Contact Information - {i}"
            });
        }

        SupplierTableGrid(suppliers);

        var id = AnsiConsole.Ask<string>("Supplier Id? [grey]Enter -1 to cancel[/]");

        if (id == "-1")
        {
            AnsiConsole.Clear();
            Program.ProductView();
        }

        AnsiConsole.MarkupLine("[green]Preview the product details[/]");

        // TODO: Fake products
        SupplierDetailsView(new Supplier()
        {
            ID = id,
            Name = "Example",
            ContactInformation = "Example Info"
        });

        var name = AnsiConsole.Prompt(
            new TextPrompt<string>("[[Optional]] Supplier Name?").AllowEmpty());
        var contactInformation = AnsiConsole.Prompt(
            new TextPrompt<string>("[[Optional]] Supplier Contact Information?").AllowEmpty());

        AnsiConsole.MarkupLine("[green]Preview update supplier details[/]");

        SupplierDetailsView(new Supplier()
        {
            ID = id,
            Name = name == "" ? "Example" : name,
            ContactInformation = contactInformation == "" ? "Example Info" : contactInformation
        });

        AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
        System.Console.ReadKey();

        AnsiConsole.Clear();
        Program.SupplierView();
    }
}