namespace TP.Models.ResponseModels
{
    public sealed class OrderSearchResponse
    {
        public OrderSearchResponse()
        {
            //Orders = new List<Order>();
        }

        //public IEnumerable<Order> Orders { get; set; }

        public int TotalCount { get; set; }

        public int FilteredCount { get; set; }
    }
}
