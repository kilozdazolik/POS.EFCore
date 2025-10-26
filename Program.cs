using PointOfSale.EntityFramework;
using Spectre.Console;

var isAppRunning = true;
while (isAppRunning)
{
    var option = AnsiConsole.Prompt(new SelectionPrompt<MenuOptions>()
        .Title("What would you like to do?")
        .AddChoices(
            MenuOptions.AddProduct,
            MenuOptions.DeleteProduct,
            MenuOptions.UpdateProduct, 
            MenuOptions.ViewProduct, 
            MenuOptions.ViewAllProducts, 
            MenuOptions.Quit));

    switch (option)
    {
        case MenuOptions.AddProduct:
            ProductService.InsertProduct();
            break;
        case MenuOptions.DeleteProduct:
            ProductService.DeleteProduct();
            break;
        case MenuOptions.UpdateProduct:
            ProductController.UpdateProduct();
            break;
        case MenuOptions.ViewProduct:
            ProductService.GetProduct();
            break;
        case MenuOptions.ViewAllProducts:
            ProductService.GetProducts();
            break;
    
    }
}

enum MenuOptions {
    AddProduct,
    DeleteProduct,
    UpdateProduct,
    ViewProduct,
    ViewAllProducts,
    Quit
}