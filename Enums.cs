namespace PointOfSale.EntityFramework;

internal class Enums
{
    internal enum MainMenuOptions
    {
        ManageCategories,
        ManageProducts,
        ManageOrders,
        GenerateReport,
        Quit
    }

    internal enum CategoryMenu
    {
        AddCategory,
        DeleteCategory,
        UpdateCategory,
        ViewAllCategories,
        ViewCategory,
        Goback,
    }

    internal enum ProductMenu
    {
        AddProduct,
        DeleteProduct,
        UpdateProduct,
        ViewProduct,
        ViewAllProducts,
        Goback,
    }

    internal enum OrderMenu
    {
        AddOrder,
        GetOrders,
        GetOrder,
        Goback
    }
}