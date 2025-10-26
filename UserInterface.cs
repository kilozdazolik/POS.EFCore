using Spectre.Console;

namespace PointOfSale.EntityFramework;

static class UserInterface
{
    internal static void ShowProduct(Product product)
    {
        var panel = new Panel($@"Id: {product.Id}
                                    Name: {product.Name}");
        panel.Header = new PanelHeader("Product info");
        panel.Padding = new Padding(2, 2, 2, 2);
        
        AnsiConsole.Write(panel);
        
        AnsiConsole.WriteLine("Press any key to continue...");
        Console.ReadLine();
        AnsiConsole.Clear();
    }
    static internal void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var product in products)
        {
            table.AddRow(product.Id.ToString(), product.Name);
        }
        
        AnsiConsole.Write(table);
        
        AnsiConsole.WriteLine("Press any key to continue...");
        Console.ReadLine();
        AnsiConsole.Clear();
    }
}