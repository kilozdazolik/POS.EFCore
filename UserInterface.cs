﻿using Spectre.Console;

namespace PointOfSale.EntityFramework;

static class UserInterface
{
    static internal void MainMenu()
    {
        var isAppRunning = true;
        while (isAppRunning)
        {
            var option = AnsiConsole.Prompt(new SelectionPrompt<Enums.MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    Enums.MenuOptions.AddCategory,
                    Enums.MenuOptions.ViewAllCategories,
                    Enums.MenuOptions.AddProduct,
                    Enums.MenuOptions.DeleteProduct,
                    Enums.MenuOptions.UpdateProduct, 
                    Enums.MenuOptions.ViewProduct,  
                    Enums.MenuOptions.ViewAllProducts, 
                    Enums.MenuOptions.Quit));

            switch (option)
            {
                case Enums.MenuOptions.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case Enums.MenuOptions.ViewAllCategories:
                    CategoryService.GetCategories();
                    break;
                case Enums.MenuOptions.AddProduct:
                    ProductService.InsertProduct();
                    break;
                case Enums.MenuOptions.DeleteProduct:
                    ProductService.DeleteProduct();
                    break;
                case Enums.MenuOptions.UpdateProduct:
                    ProductService.UpdateProduct();
                    break;
                case Enums.MenuOptions.ViewProduct:
                    ProductService.GetProduct();
                    break;
                case Enums.MenuOptions.ViewAllProducts:
                    ProductService.GetProducts();
                    break;
    
            }
        }
    }
    internal static void ShowProduct(Product product)
    {
        var panel = new Panel($@"Id: {product.ProductId}
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
        table.AddColumn("Price");

        foreach (var product in products)
        {
            table.AddRow(product.ProductId.ToString(), product.Name, product.Price.ToString());
        }
        
        AnsiConsole.Write(table);
        
        AnsiConsole.WriteLine("Press any key to continue...");
        Console.ReadLine();
        AnsiConsole.Clear();
    }
    
    static internal void ShowCategoryTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var category in categories)
        {
            table.AddRow(category.CategoryId.ToString(), category.Name);
        }
        
        AnsiConsole.Write(table);
        
        AnsiConsole.WriteLine("Press any key to continue...");
        Console.ReadLine();
        AnsiConsole.Clear();
    }
}