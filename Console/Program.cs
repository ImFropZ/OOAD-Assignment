using Spectre.Console;

namespace Console;

public static class Program
{
    public static void Main(string[] args)
    {
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
                    "Product", "Vendor", "[red]Exit[/]"
                }));

        switch (mode)
        {
            case ("Product"):
                ProductView();
                break;
            case ("Vendor"):
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
                    "Add", "Remove", "Update", "[green]Back into main menu[/]", "[red]Exit[/]"
                }));

        switch (mode)
        {
            case ("Add"):
                new ProductActions().Add();
                break;
            case ("Remove"):
                new ProductActions().Remove();
                break;
            case ("Update"):
                new ProductActions().Update();
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
                    "Add", "Remove", "Update", "[green]Back into main menu[/]", "[red]Exit[/]"
                }));
        
        switch (mode)
        {
            case ("Add"):
                new SupplierActions().Add();
                break;
            case ("Remove"):
                new SupplierActions().Remove();
                break;
            case ("Update"):
                new SupplierActions().Update();
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