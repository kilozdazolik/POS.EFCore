using Spectre.Console;

namespace PointOfSale.EntityFramework;

public class ProductController
{
    public static void AddProduct(string name)
    {
        using var db = new ProductsContext();
        db.Add(new Product{ Name = name });
        db.SaveChanges();
    }

    public static void DeleteProduct(Product product)
    {
        using var db = new ProductsContext();
        db.Remove(product);
        db.SaveChanges();
    }

    public static void UpdateProduct()
    {
        throw new NotImplementedException();
    }

    public static Product GetProductById(int id)
    {
        using var db = new ProductsContext();
        var product = db.Products.SingleOrDefault(x => x.Id == id);
        return product;
    }

    public static List<Product> GetProducts()
    {
        using var db = new ProductsContext();
        var products = db.Products.ToList();
        return products;
    }
}