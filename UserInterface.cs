using PointOfSale.EntityFramework.DTOs;
using Spectre.Console;

namespace PointOfSale.EntityFramework;

static class UserInterface
{
    static internal void MainMenu()
    {
        var isAppRunning = true;
        while (isAppRunning)
        {
            //AnsiConsole.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.MainMenuOptions>()
                    .Title("What would you like to do?").AddChoices(Enums.MainMenuOptions.ManageCategories,
                        Enums.MainMenuOptions.ManageProducts, Enums.MainMenuOptions.ManageOrders, Enums.MainMenuOptions.GenerateReport,Enums.MainMenuOptions.Quit));
            switch (option)
            {
                case Enums.MainMenuOptions.ManageCategories:
                    CategoriesMenu();
                    break;
                case Enums.MainMenuOptions.ManageProducts:
                    ProductsMenu();
                    break;
                case Enums.MainMenuOptions.ManageOrders:
                    OrdersMenu();
                    break;
                case Enums.MainMenuOptions.GenerateReport:
                    ReportService.CreateMonthlyReport();
                    break;
                case Enums.MainMenuOptions.Quit:
                    AnsiConsole.WriteLine("Goodbye!");
                    isAppRunning = false;
                    break;
            }
        }
    }

    private static void OrdersMenu()
    {
        var isOrderMenuRunning = true;
        while (isOrderMenuRunning)
        {
            //AnsiConsole.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.OrderMenu>().Title("Order Menu").AddChoices(Enums.OrderMenu.AddOrder, Enums.OrderMenu.GetOrders,Enums.OrderMenu.GetOrder,Enums.OrderMenu.Goback)
            );

            switch (option)
            {
                case Enums.OrderMenu.AddOrder:
                    OrderService.InsertOrder();
                    break;
                case Enums.OrderMenu.GetOrders:
                    OrderService.GetOrders();
                    break;
                case Enums.OrderMenu.GetOrder:
                    OrderService.GetOrder();
                    break;
                case Enums.OrderMenu.Goback:
                    isOrderMenuRunning = false;
                    break;
            }
        }
    }

    static internal void CategoriesMenu()
    {
        var isCategoriesMenuRunning = true;
        while (isCategoriesMenuRunning)
        {
            //AnsiConsole.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.CategoryMenu>().Title("Categories Menu").AddChoices(
                    Enums.CategoryMenu.AddCategory, Enums.CategoryMenu.DeleteCategory,
                    Enums.CategoryMenu.UpdateCategory, Enums.CategoryMenu.ViewAllCategories,
                    Enums.CategoryMenu.ViewCategory, Enums.CategoryMenu.Goback)
            );

            switch (option)
            {
                case Enums.CategoryMenu.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case Enums.CategoryMenu.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case Enums.CategoryMenu.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case Enums.CategoryMenu.ViewAllCategories:
                    CategoryService.GetCategories();
                    break;
                case Enums.CategoryMenu.ViewCategory:
                    CategoryService.GetCategory();
                    break;
                case Enums.CategoryMenu.Goback:
                    isCategoriesMenuRunning = false;
                    break;
            }
        }
    }

    static internal void ProductsMenu()
    {
        var isProductsMenuRunning = true;
        while (isProductsMenuRunning)
        {
            //AnsiConsole.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.ProductMenu>().Title("Products Menu").AddChoices(Enums.ProductMenu.AddProduct,
                    Enums.ProductMenu.DeleteProduct, Enums.ProductMenu.UpdateProduct, Enums.ProductMenu.ViewAllProducts,
                    Enums.ProductMenu.ViewProduct, Enums.ProductMenu.Goback)
            );

            switch (option)
            {
                case Enums.ProductMenu.AddProduct:
                    ProductService.InsertProduct();
                    break;
                case Enums.ProductMenu.DeleteProduct:
                    ProductService.DeleteProduct();

                    break;
                case Enums.ProductMenu.UpdateProduct:
                    ProductService.UpdateProduct();

                    break;
                case Enums.ProductMenu.ViewAllProducts:
                    ProductService.GetProducts();

                    break;
                case Enums.ProductMenu.ViewProduct:
                    ProductService.GetProduct();
                    break;
                case Enums.ProductMenu.Goback:
                    isProductsMenuRunning = false;
                    break;
            }
        }
    }

    internal static void ShowProduct(Product product)
    {
        var panel = new Panel($@"Id: {product.ProductId}
                                    Name: {product.Name}
                                    Category: {product.Category.Name}");
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
        table.AddColumn("Category");

        foreach (var product in products)
        {
            table.AddRow(product.ProductId.ToString(), product.Name, product.Price.ToString(), product.Category.Name);
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

    public static void ShowCategory(Category category)
    {
        var panel = new Panel($@"Id: {category.CategoryId}
                                    Name: {category.Name}
                                    Product Count: {category.Products.Count}");
        panel.Header = new PanelHeader(category.Name);
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        ShowProductTable(category.Products);

        AnsiConsole.WriteLine("Press any key to continue...");
        Console.ReadLine();
        AnsiConsole.Clear();
    }

    public static void ShowOrderTable(List<Order> orders)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Date");
        table.AddColumn("Count");
        table.AddColumn("Total Price");

        foreach (var order in orders)
        {
            table.AddRow(
                order.OrderId.ToString(),
                order.CreatedDate.ToString(),
                order.OrderProducts.Sum(x => x.Quantity).ToString(),
                order.TotalPrice.ToString());
        }

        AnsiConsole.Write(table);

        AnsiConsole.WriteLine("Press any key to continue...");
        Console.ReadLine();
        AnsiConsole.Clear();
    }

    public static void ShowProductForOrderTable(List<ProductForOrderViewDTO> products)
    {
        var table = new  Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Category");
        table.AddColumn("Price");
        table.AddColumn("Quantity");
        table.AddColumn("Total Price");

        foreach (var product in products)
        {
            table.AddRow(
                product.Id.ToString(),
                product.Name,
                product.CategoryName,
                product.Price.ToString(),
                product.Quantity.ToString(),
                product.TotalPrice.ToString()
            );
        }
        
        AnsiConsole.Write(table);

        AnsiConsole.WriteLine("Press any key to continue...");
        Console.ReadLine();
        AnsiConsole.Clear();
    }

    public static void ShowOrder(Order order)
    {
        var panel = new Panel($@"Id: {order.OrderId}
                                    Date: {order.CreatedDate}
                                    Product Count: {order.OrderProducts.Count}");
        panel.Header = new PanelHeader($"Order #{order.OrderId}");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);
    }

    public static void ShowReportByMonth(List<MonthlyReportDTO> report)
    {
        var table = new  Table();
        table.AddColumn("Month");
        table.AddColumn("Total Quantity");
        table.AddColumn("Total Sales");

        foreach (var item in report)
        {
            table.AddRow(
                item.Month,
                item.TotalQuantity.ToString(),
                item.TotalPrice.ToString()
            );
        }
        
        AnsiConsole.Write(table);
    }
}