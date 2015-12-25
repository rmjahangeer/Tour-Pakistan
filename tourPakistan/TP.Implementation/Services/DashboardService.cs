using TP.Interfaces.IServices;
using TP.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class DashboardService:IDashboardService
    {
        

        public DashboardService()
        {
            
        }

        public DashboardResponseModel GetDashboardData()
        {
            
            return new DashboardResponseModel()
            {
                TodayProfit = 10,
                TodayTopSoldProductId = 286,
                TodayTopSoldProductName = "MAC BOOK",
                TodayTotalSale = 20,
                ShortStockProducts = 15,

            };
        }
    }
}
