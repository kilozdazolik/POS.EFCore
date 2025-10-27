using Microsoft.EntityFrameworkCore;

namespace PointOfSale.EntityFramework;

public class CategoryController
{
    internal static void AddCategory(Category category)
    {
        using var db = new ProductsContext();
        db.Add(category);
        db.SaveChanges();
    }

    internal static void DeleteCategory(Category category)
    {
        using var db = new ProductsContext();
        db.Remove(category);
        db.SaveChanges();
    }

    internal static List<Category> GetCategories()
    {
        using var db = new ProductsContext();
        var categories = db.Categories.Include(x => x.Products).ToList();
        return categories;
    }
    
    
    public static void UpdateCategory(Category category)
    { 
        using var db = new ProductsContext();
        db.Update(category);
        db.SaveChanges();
    }
}