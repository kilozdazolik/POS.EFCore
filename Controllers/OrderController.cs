using Microsoft.EntityFrameworkCore;

namespace PointOfSale.EntityFramework;

public class OrderController
{
    internal static void AddOrder(List<OrderProduct> orders)
    {
        using var db = new ProductsContext();
        db.OrderProducts.AddRange(orders);
        db.SaveChanges();
    }

    internal static List<Order> GetOrders()
    {
        using var db = new ProductsContext();
        var ordersList = db.Orders
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .ThenInclude(p => p.Category)
            .ToList();
        return ordersList;
    }
}