namespace TP.Models.ResponseModels
{
    public class DashboardResponseModel
    {
      
        public double TodayTotalSale { get; set; }
      
        public int ShortStockProducts { get; set; }
        public long TodayTopSoldProductId { get; set; }
       
        public string TodayTopSoldProductName { get; set; }
      
        public double TodayProfit { get; set; }

    }
}
