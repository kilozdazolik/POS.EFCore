using System.Globalization;
using PointOfSale.EntityFramework.DTOs;

namespace PointOfSale.EntityFramework;

public class ReportService
{
    internal static void CreateMonthlyReport()
    {
        var orders = OrderController.GetOrders();

        var report = orders.GroupBy(x => new
        {
            x.CreatedDate.Month,
            x.CreatedDate.Year,
        })
        .Select(grp => new MonthlyReportDTO
        {
            Month = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(grp.Key.Month)}/{grp.Key.Year}",
            TotalPrice = grp.Sum(grp => grp.TotalPrice),
            TotalQuantity = grp.Sum(x => x.OrderProducts.Sum(x => x.Quantity))
        }).ToList();
        
        UserInterface.ShowReportByMonth(report);
    }
}