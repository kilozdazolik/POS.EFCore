using Spectre.Console;

namespace PointOfSale.EntityFramework;

public class CategoryService
{
    internal static void InsertCategory()
    {
        var category = new Category();
        category.Name = AnsiConsole.Ask<string>("Enter category name:");
        
        CategoryController.AddCategory(category);
    }

    internal static void GetCategories()
    {
        var categories =  CategoryController.GetCategories();
        UserInterface.ShowCategoryTable(categories);
    }
}